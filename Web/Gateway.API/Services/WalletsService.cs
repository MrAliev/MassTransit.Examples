using MassTransit;
using Masstransit.Common.Responses;
using Users.Bus.Contracts.Requests;
using Users.Bus.Contracts.Responses;
using Wallets.Bus.Contracts.Requests;
using Wallets.Bus.Contracts.Responses;
using Wallets.Model;
using Wallets.Service.Contracts;

namespace Gateway.API.Services;

public class WalletsService  : IWalletsService
{
    private readonly IBus _bus;
    private readonly ILogger<WalletsService> _logger;

    public WalletsService(IBus bus, ILogger<WalletsService> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    public Wallet Create(Guid parentId)
    {
        var client = _bus.CreateRequestClient<CreateWalletRequest>();
        var request = new CreateWalletRequest { ParentId = parentId };

        Response response = client.GetResponse<CreateWalletResponse, ExceptionResponse>(request).GetAwaiter().GetResult();

        return response switch
        {
            (_, CreateWalletResponse success) => success.Wallet,
            (_, ExceptionResponse exception) => throw exception.Exception,
            _ => throw new InvalidCastException(nameof(Response))
        };
    }

    public Task<Wallet> CreateAsync(Guid parentId)
    {
        return Task.FromResult(Create(parentId));
    }

    public void Delete(Guid id)
    {
        var client = _bus.CreateRequestClient<DeleteUserRequest>();
        var request = new DeleteUserRequest { Id = id};

        Response response = client.GetResponse<DeleteUserResponse, ExceptionResponse>(request).GetAwaiter().GetResult();

        switch (response)
        {
            case (_, CreateUserResponse success):
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