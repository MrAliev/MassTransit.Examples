namespace Users.Bus.Contracts.Requests
{
    public record CreateUserActivityArgs
    {
        public string FirstProperty { get; init; } = null!;
    }
}
