using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Wallets.Model
{
    public class Wallet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; init; }

        [Required] public Guid ParentId { get; set; }

        public bool IsDeleted { get; set; }
        
        public decimal Amount { get; set; }

        public Wallet(Guid  parentId)
        {
            ParentId = parentId;
        }
    }
}
