using Accounts.Bus.Contracts.Requests;
using Accounts.Bus.Contracts.Responses;
using Accounts.Model;
using Accounts.Services.Contracts;
using MassTransit;
using Masstransit.Common.Responses;
using Users.Bus.Contracts.Responses;

namespace Gateway.API.Services;

public class AccountsService  : IAccountsService
{
    private readonly IBus _bus;
    private readonly ILogger<AccountsService> _logger;

    public AccountsService(IBus bus, ILogger<AccountsService> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    public Account Create(string name)
    {
        var client = _bus.CreateRequestClient<CreateAccountRequest>();
        var request = new CreateAccountRequest { UserName = name };

        Response response = client.GetResponse<CreateAccountRequest, ExceptionResponse>(request).GetAwaiter().GetResult();

        return response switch
        {
            (_, CreateAccountResponse success) => success.Account,
            (_, ExceptionResponse exception) => throw exception.Exception,
            _ => throw new InvalidCastException(nameof(Response))
        };
    }

    public Task<Account> CreateAsync(string name)
    {
        return Task.FromResult(Create(name));
    }

    public void Delete(Guid id)
    {
        var client = _bus.CreateRequestClient<DeleteAccountRequest>();
        var request = new DeleteAccountRequest { Id = id};

        Response response = client.GetResponse<DeleteAccountResponse, ExceptionResponse>(request).GetAwaiter().GetResult();

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