using Users.Data;
using Users.Model;
using Users.Services.Contracts;

namespace Users.Services
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UsersDbContext _context;

        public UsersRepository(UsersDbContext context)
        {
            _context = context;
        }

        public User Create(string name)
        {
            var model = new User(name);
            _context.Set<User>().Add(model);
            _context.SaveChanges();
            return model;
        }

        public Task<User> CreateAsync(string name)
        {
            return Task.FromResult(Create(name));
        }

        public void Delete(Guid id, bool permanentDelete = false)
        {
            try
            {
                var model = _context.Set<User>().FirstOrDefault(item => item.Id.Equals(id));

                if (model is null) throw new ArgumentNullException(nameof(User));

                if (permanentDelete)
                {
                    model.IsDeleted = true;
                }
                else
                {
                    _context.Set<User>().Remove(model);

                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task DeleteAsync(Guid id, bool permanentDelete = false)
        {
            Delete(id, permanentDelete);
            return Task.CompletedTask;
        }
    }
}
