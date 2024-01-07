using System.ComponentModel.DataAnnotations;

namespace Accounts.Bus.Contracts.Requests
{
    public record CreateAccountRequest
    {
        [Required]
        public string UserName { get; init; } = null!;
    }
}
