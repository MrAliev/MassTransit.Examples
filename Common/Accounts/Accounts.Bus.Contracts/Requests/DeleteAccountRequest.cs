namespace Accounts.Bus.Contracts.Requests;

public record DeleteAccountRequest
{
    public Guid Id { get; init; }
}