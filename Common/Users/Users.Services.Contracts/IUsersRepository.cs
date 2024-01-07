using Users.Model;

namespace Users.Services.Contracts
{
    public interface IUsersRepository
    {
        public User Create(string name);

        public Task<User> CreateAsync(string name);

        public void Delete(Guid id, bool permanentDelete = false);

        public Task DeleteAsync(Guid id, bool permanentDelete = false);
    }
}
