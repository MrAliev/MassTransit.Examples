
using Wallets.Model;

namespace Wallets.Bus.Contracts.Responses
{
    public record CreateWalletResponse
    {
        public Wallet Wallet { get; init; } = null!;
    }
}
