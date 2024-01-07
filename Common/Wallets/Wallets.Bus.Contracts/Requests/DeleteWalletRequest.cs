namespace Wallets.Bus.Contracts.Requests;

public record DeleteWalletRequest
{
    public Guid Id { get; init; }
}