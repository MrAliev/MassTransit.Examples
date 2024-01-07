using System.ComponentModel.DataAnnotations;

namespace Users.Bus.Contracts.Activities;

public record CreateUserActivityLog
{
    [Required]
    public Guid Id { get; init; }
}