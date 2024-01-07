using MassTransit;
using Masstransit.Common.Responses;
using Users.Bus.Contracts.Requests;
using Users.Bus.Contracts.Responses;
using Users.Services.Contracts;

namespace Users.WorkerService.Consumers;

public class DeleteUserRequestConsumer : IConsumer<DeleteUserRequest>
{
    private readonly ILogger<CreateUserRequestConsumer> _logger;
    private readonly IUsersRepository _repository;

    public DeleteUserRequestConsumer(ILogger<CreateUserRequestConsumer> logger, IUsersRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<DeleteUserRequest> context)
    {
        try
        {
            await _repository.DeleteAsync(context.Message.Id);
            await context.RespondAsync<DeleteUserResponse>(new DeleteUserResponse
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