namespace Accounts.Bus.Contracts.Responses;

public record DeleteAccountResponse
{
    public bool Success { get; init; }
}