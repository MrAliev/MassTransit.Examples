using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Model
{
    public class CompositeUserModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; init; }

        [Required] public string FirstProperty { get; set; } = null!;

        public CompositeUserModel(string firstProperty)
        {
            FirstProperty = firstProperty;
        }
    }
}
