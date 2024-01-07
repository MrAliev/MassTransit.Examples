using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Model
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; init; }

        public bool IsDeleted { get; set; }

        [Required] public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }
    }
}
