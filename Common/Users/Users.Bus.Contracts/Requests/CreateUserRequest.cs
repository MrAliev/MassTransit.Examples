namespace Users.Bus.Contracts.Requests
{


    public record CreateUserRequest
    {
        public string FirstProperty { get; init; } = null!;
    }
}
