using System.ComponentModel.DataAnnotations;

namespace Users.Bus.Contracts.Activities
{
    public record CreateUserActivityArgs
    {
        [Required]
        public string Name { get; init; } = null!;
    }
}
