using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Users.Model;
using Wallets.Model;

namespace Accounts.Model
{
    public class Account
    {
        [ReadOnly(true)] public Guid Id => User.Id;  // <= Fix Aggregate Account item Id

        [Required] public User User { get; init; } = null!;

        [Required] public Wallet Wallet { get; init; } = null!;

        public Account(User user, Wallet wallet)
        {
            User = user;
            Wallet = wallet;
        }
    }
}
