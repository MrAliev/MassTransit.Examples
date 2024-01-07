namespace Wallets.Bus.Contracts.Responses;

public record DeleteWalletResponse
{
    public bool Success { get; init; }
}