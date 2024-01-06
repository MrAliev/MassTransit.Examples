namespace Users.Bus.Contracts.Requests
{
    public record CreateUserRequestLog
    {
        public Guid Id { get; init; }
    }
}
