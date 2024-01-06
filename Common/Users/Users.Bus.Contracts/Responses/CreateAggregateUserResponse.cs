using Users.Model;

namespace Users.Bus.Contracts.Responses
{
    public record CreateAggregateUserResponse
    {
        public CompositeUserModel UserModel { get; init; } = null!;
    }
}
