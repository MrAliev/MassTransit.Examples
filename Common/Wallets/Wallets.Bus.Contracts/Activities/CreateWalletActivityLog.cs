using System.ComponentModel.DataAnnotations;

namespace Wallets.Bus.Contracts.Activities;

public record CreateWalletActivityLog
{
    [Required]
    public Guid Id { get; init; }
}