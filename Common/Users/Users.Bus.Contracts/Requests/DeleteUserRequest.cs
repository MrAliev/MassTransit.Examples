namespace Users.Bus.Contracts.Requests;

public record DeleteUserRequest
{
    public Guid Id { get; init; }
}