using Accounts.Model;

namespace Accounts.Bus.Contracts.Responses
{
    public record CreateAccountResponse
    {
        public Account Account { get; init; } = null!;
    }
}
