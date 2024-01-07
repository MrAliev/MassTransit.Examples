using System.ComponentModel.DataAnnotations;

namespace Wallets.Bus.Contracts.Requests
{
    public record CreateWalletRequest
    {
        [Required]
        public Guid ParentId { get; init; }
    }
}
