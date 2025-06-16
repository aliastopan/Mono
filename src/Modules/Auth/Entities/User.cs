using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mono.Modules.Auth.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid UserId { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(32)]
    public string Username { get; set; } = default!;

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = default!;
}
