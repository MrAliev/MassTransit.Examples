using MassTransit;
using Masstransit.Common.Responses;
using Wallets.Bus.Contracts.Requests;
using Wallets.Bus.Contracts.Responses;
using Wallets.Service.Contracts;

namespace Wallets.WorkerService.Consumers;

public class DeleteWalletsRequestConsumer : IConsumer<DeleteWalletRequest>
{
    private readonly ILogger<CreateWalletsRequestConsumer> _logger;
    private readonly IWalletsRepository _repository;

    public DeleteWalletsRequestConsumer(ILogger<CreateWalletsRequestConsumer> logger, IWalletsRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<DeleteWalletRequest> context)
    {
        try
        {
            await _repository.DeleteAsync(context.Message.Id);
            await context.RespondAsync<DeleteWalletResponse>(new DeleteWalletResponse
            {
                Success = true
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