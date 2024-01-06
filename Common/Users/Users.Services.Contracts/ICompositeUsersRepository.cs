using Users.Model;

namespace Users.Services.Contracts
{
    public interface ICompositeUsersRepository
    {
        public CompositeUserModel Create(string firstProperty);

        public Task<CompositeUserModel> CreateAsync(string firstProperty);
    }
}
