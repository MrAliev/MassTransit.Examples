using Gateway.API.Interfaces;
using Masstransit.Common.Responses;
using MassTransit;
using Users.Bus.Contracts.Requests;
using Users.Bus.Contracts.Responses;
using Users.Model;

namespace Gateway.API.Services
{
    public class AggregateUserManager : IAggregateUserManager
    {
        private readonly IBus _bus;
        private readonly ILogger<AggregateUserManager> _logger;

        public AggregateUserManager(IBus bus, ILogger<AggregateUserManager> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public CompositeUserModel Create(string firstProperty)
        {
            var client = _bus.CreateRequestClient<CreateUserRequest>() ?? throw new ArgumentNullException(nameof(CreateUserRequest));

            var request = new CreateUserRequest { FirstProperty = firstProperty };

            Response response = client.GetResponse<CreateAggregateUserResponse, ExceptionResponse>(request).GetAwaiter().GetResult();

            return response switch
            {
                (_, CreateAggregateUserResponse success) => success.UserModel,
                (_, ExceptionResponse error) => throw error.Exception,
                _ => throw new InvalidCastException($"Cannot cast response type {response.GetType().Name}")
            };
        }

        public Task<CompositeUserModel> CreateAsync(string firstProperty)
        {
            return Task.FromResult(Create(firstProperty));
        }
    }
}
