using Masstransit.Common.Responses;
using MassTransit;
using Users.Bus.Contracts.Requests;
using Users.Bus.Contracts.Responses;
using Users.Model;
using Users.Services.Contracts;

namespace Gateway.API.Services
{
    public class UsersService  : IUsersService
    {
        private readonly IBus _bus;
        private readonly ILogger<UsersService> _logger;

        public UsersService(IBus bus, ILogger<UsersService> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public User Create(string name)
        {
            var client = _bus.CreateRequestClient<CreateUserRequest>();
            var request = new CreateUserRequest { Name = name };

            Response response = client.GetResponse<CreateUserResponse, ExceptionResponse>(request).GetAwaiter().GetResult();

            return response switch
            {
                (_, CreateUserResponse success) => success.User,
                (_, ExceptionResponse exception) => throw exception.Exception,
                _ => throw new InvalidCastException(nameof(Response))
            };
        }

        public Task<User> CreateAsync(string name)
        {
            return Task.FromResult(Create(name));
        }

        public void Delete(Guid id)
        {
            var client = _bus.CreateRequestClient<DeleteUserRequest>();
            var request = new DeleteUserRequest { Id = id};

            Response response = client.GetResponse<DeleteUserResponse, ExceptionResponse>(request).GetAwaiter().GetResult();

            switch (response)
            {
                case (_, DeleteUserResponse success):
                    return;
                case (_, ExceptionResponse exception):
                    throw exception.Exception;
                default:
                    throw new InvalidCastException(nameof(Response));
            }
        }

        public Task DeleteAsync(Guid id)
        {
            Delete(id);
            return Task.CompletedTask;
        }
    }
}
