using MassTransit;
using Users.Bus.Contracts.Activities;
using Users.Model;
using Users.Services.Contracts;

namespace Users.WorkerService.Activities
{
    public class CreateUserActivity : IActivity<CreateUserActivityArgs, CreateUserActivityLog>
    {
        private readonly ILogger<CreateUserActivity> _logger;
        private readonly IUsersRepository _repository;

        public CreateUserActivity(ILogger<CreateUserActivity> logger, IUsersRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<ExecutionResult> Execute(ExecuteContext<CreateUserActivityArgs> context)
        {
            try
            {
                var model = await _repository.CreateAsync(context.Arguments.Name);
                
                context.Message.Variables.Add(nameof(User), model);
                context.Message.Variables.Add("ParentId", model.Id);

                return context.CompletedWithVariables(new { model.Id });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while create activity execute {RequestName}. RequestId: {RequestId}", nameof(CreateUserActivity), context.RequestId);
                return context.Faulted(e);
            }
        }

        public async Task<CompensationResult> Compensate(CompensateContext<CreateUserActivityLog> context)
        {
            try
            {
                await _repository.DeleteAsync(context.Log.Id, true);

                return context.Compensated();
            }
            catch (Exception e)
            {
                _logger.LogError("Error occured while compensate {RequestName}. RequestId: {RequestId}", nameof(CreateUserActivity), context.RequestId);
                throw;
            }
        }
    }
}
