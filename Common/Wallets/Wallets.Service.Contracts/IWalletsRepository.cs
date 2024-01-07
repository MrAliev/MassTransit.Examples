using Wallets.Model;

namespace Wallets.Service.Contracts
{
    public interface IWalletsRepository
    {
        public Wallet Create(Guid parentId);

        public Task<Wallet> CreateAsync(Guid parentId);


        public void Delete(Guid id, bool permanentDelete = false);

        public Task DeleteAsync(Guid id, bool permanentDelete = false);
    }
}
