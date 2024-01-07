using Wallets.Data;
using Wallets.Service.Contracts;

namespace Wallet.Serivces
{
    public class WalletsRepository : IWalletsRepository
    {
        private readonly WalletsDbContext _context;

        public WalletsRepository(WalletsDbContext context)
        {
            _context = context;
        }

        public Wallets.Model.Wallet Create(Guid parentId)
        {
            var model = new Wallets.Model.Wallet(parentId);
            _context.Set<Wallets.Model.Wallet>().Add(model);
            _context.SaveChanges();
            return model;
        }

        public Task<Wallets.Model.Wallet> CreateAsync(Guid parentId)
        {
            return Task.FromResult(Create(parentId));
        }

        
        public void Delete(Guid id,  bool permanentDelete = false)
        {
            try
            {
                var model = _context.Set<Wallets.Model.Wallet>().FirstOrDefault(item => item.Id.Equals(id));

                if (model is null) throw new ArgumentNullException(nameof(Wallets.Model.Wallet));

                if (permanentDelete)
                {
                    model.IsDeleted = true;
                }
                else
                {
                    _context.Set<Wallets.Model.Wallet>().Remove(model);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task DeleteAsync(Guid id, bool permanentDelete)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            Delete(id);
            return Task.CompletedTask;
        }
    }
}
