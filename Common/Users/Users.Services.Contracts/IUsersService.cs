using Users.Model;

namespace Users.Services.Contracts;

public interface IUsersService
{
    public User Create(string name);

    public Task<User> CreateAsync(string name);

    public void Delete(Guid id);

    public Task DeleteAsync(Guid id);
}