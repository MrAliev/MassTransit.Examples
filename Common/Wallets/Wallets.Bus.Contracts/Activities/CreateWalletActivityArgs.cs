using System.ComponentModel.DataAnnotations;

namespace Wallets.Bus.Contracts.Activities
{
    public record CreateWalletActivityArgs
    {
        [Required]
        public Guid ParentId { get; init; }
    }
}
