using Accounts.Model;

namespace Accounts.Services.Contracts;

public interface IAccountsService
{
    public Account Create(string userName);

    public Task<Account> CreateAsync(string name);

    public void Delete(Guid id);

    public Task DeleteAsync(Guid id);
}