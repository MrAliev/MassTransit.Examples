using MassTransit;
using Users.Bus.Contracts.Requests;

namespace Users.WorkerService.Consumers
{
    public class CreateAggregateUserConsumer : IConsumer<CreateUserRequest>
    {
        private readonly ILogger<CreateAggregateUserConsumer> _logger;
        private readonly IEndpointNameFormatter _formatter;

        public CreateAggregateUserConsumer(ILogger<CreateAggregateUserConsumer> logger, IEndpointNameFormatter formatter)
        {
            _logger = logger;
            _formatter = formatter;
        }

        public Task Consume(ConsumeContext<CreateUserRequest> context)
        {

            throw new NotImplementedException();
        }
    }
}
