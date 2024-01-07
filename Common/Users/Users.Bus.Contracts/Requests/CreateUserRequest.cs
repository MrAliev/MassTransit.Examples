namespace Users.Bus.Contracts.Requests
{
    public record CreateUserRequest
    {
        public string Name { get; init; } = null!;
    }
}
