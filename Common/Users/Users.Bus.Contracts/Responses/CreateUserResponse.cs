using Users.Model;

namespace Users.Bus.Contracts.Responses
{
    public record CreateUserResponse
    {
        public User User { get; init; } = null!;
    }
}
