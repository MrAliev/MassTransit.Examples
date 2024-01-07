using MassTransit;
using Wallets.Bus.Contracts.Activities;
using Wallets.Service.Contracts;

namespace Wallets.WorkerService.Activities
{
    public class CreateWalletActivity  : IActivity<CreateWalletActivityArgs, CreateWalletActivityLog>
    {
        private readonly ILogger<CreateWalletActivity> _logger;
        private readonly IWalletsRepository _repository;

        public CreateWalletActivity(ILogger<CreateWalletActivity> logger, IWalletsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<ExecutionResult> Execute(ExecuteContext<CreateWalletActivityArgs> context)
        {
            try
            {
                var model = await _repository.CreateAsync(context.Arguments.ParentId);
                
                context.Message.Variables.Add(nameof(Wallet), model);

                return context.CompletedWithVariables(new { model.Id });
            }
            catch (Exception e)
            {
                return context.Faulted(e);
            }
        }

        public async Task<CompensationResult> Compensate(CompensateContext<CreateWalletActivityLog> context)
        {
            try
            {
                await _repository.DeleteAsync(context.Log.Id, true);

                return context.Compensated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
