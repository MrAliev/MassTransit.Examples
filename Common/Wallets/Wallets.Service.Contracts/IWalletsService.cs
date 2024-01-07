using Wallets.Model;

namespace Wallets.Service.Contracts;

public interface IWalletsService
{
    public Wallet Create(Guid parentId);

    public Task<Wallet> CreateAsync(Guid parentId);

    public void Delete(Guid id);

    public Task DeleteAsync(Guid id);
}