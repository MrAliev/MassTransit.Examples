using Users.Model;

namespace Gateway.API.Interfaces
{
    public interface IAggregateUserManager
    {
        public CompositeUserModel Create(string firstProperty);
        public Task<CompositeUserModel> CreateAsync(string firstProperty);
    }
}
