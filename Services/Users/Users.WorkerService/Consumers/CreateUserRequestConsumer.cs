using Masstransit.Common.Responses;
using MassTransit;
using Users.Bus.Contracts.Requests;
using Users.Bus.Contracts.Responses;
using Users.Services.Contracts;

namespace Users.WorkerService.Consumers
{
    public class CreateUserRequestConsumer : IConsumer<CreateUserRequest>
    {
        private readonly ILogger<CreateUserRequestConsumer> _logger;
        private readonly IUsersRepository _repository;

        public CreateUserRequestConsumer(ILogger<CreateUserRequestConsumer> logger, IUsersRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<CreateUserRequest> context)
        {
            try
            {
                var model = await _repository.CreateAsync(context.Message.Name);
                await context.RespondAsync<CreateUserResponse>(new CreateUserResponse
                {
                    User = model
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
