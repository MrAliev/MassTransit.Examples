using Users.Model;
using Users.Repository;
using Users.Services.Contracts;

namespace Users.Services
{
    public class CompositeUserModelsRepository(UsersDbContext context) : ICompositeUsersRepository
    {
        private readonly UsersDbContext _context = context;

        public CompositeUserModel Create(string firstProperty)
        {
            var model = new CompositeUserModel(firstProperty);
            _context.Set<CompositeUserModel>().Add(model);
            _context.SaveChanges();
            return model;
        }

        public Task<CompositeUserModel> CreateAsync(string firstProperty)
        {
            return Task.FromResult(Create(firstProperty));
        }
    }
}
