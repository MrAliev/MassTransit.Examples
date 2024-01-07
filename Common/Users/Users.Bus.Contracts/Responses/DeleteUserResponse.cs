namespace Users.Bus.Contracts.Responses;

public record DeleteUserResponse
{
    public bool Success { get; init; }
}