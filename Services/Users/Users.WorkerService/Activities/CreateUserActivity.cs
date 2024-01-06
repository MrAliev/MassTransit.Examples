using MassTransit;
using Users.Bus.Contracts.Requests;
using Users.Services.Contracts;

namespace Users.WorkerService.Activities
{
    public class CreateUserActivity : IActivity<CreateUserActivityArgs, CreateUserRequestLog>
    {
        private readonly ICompositeUsersRepository _repository;
        private readonly ILogger<CreateUserActivity> _logger;

        public CreateUserActivity(ICompositeUsersRepository repository, ILogger<CreateUserActivity> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ExecutionResult> Execute(ExecuteContext<CreateUserActivityArgs> context)
        {
            try
            {
                var model = await _repository.CreateAsync(context.Arguments.FirstProperty);
                return context.CompletedWithVariables(new { model });
            }
            catch (Exception e)
            {
                _logger.LogWarning(e,"Create error!");
                return context.Faulted(e);
            }
        }

        public async Task<CompensationResult> Compensate(CompensateContext<CreateUserRequestLog> context)
        {
            try
            {
                var id = context.Log.Id;
                _logger.LogWarning("Run compensate logic. Request Id:{requestId}", context.RequestId);
                await Task.Delay(1000); //some compensate logic

                return context.Compensated();

            }
            catch (Exception e)
            {
                _logger.LogWarning(e,"Create error!");
                return context.Failed(e);
            }
        }
    }
}
