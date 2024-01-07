using MassTransit;
using Masstransit.Common.Responses;
using Wallets.Bus.Contracts.Requests;
using Wallets.Bus.Contracts.Responses;
using Wallets.Service.Contracts;

namespace Wallets.WorkerService.Consumers
{
    public class CreateWalletsRequestConsumer : IConsumer<CreateWalletRequest>
    {
        private readonly ILogger<CreateWalletsRequestConsumer> _logger;
        private readonly IWalletsRepository _repository;

        public CreateWalletsRequestConsumer(ILogger<CreateWalletsRequestConsumer> logger, IWalletsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<CreateWalletRequest> context)
        {
            try
            {
                var model = await _repository.CreateAsync(context.Message.ParentId);
                await context.RespondAsync<CreateWalletResponse>(new CreateWalletResponse
                {
                    Wallet = model
                });
            }
            catch (Exception e)
            {
                await context.RespondAsync<ExceptionResponse>(new ExceptionResponse
                {
                    Exception = e
                });
            }
        }
    }
}
