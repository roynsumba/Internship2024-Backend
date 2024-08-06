using System.ComponentModel.DataAnnotations;

namespace AppraisalTracker.Modules.Users.Models;

public class User
{
    [Key]
    public Guid UserId { get; set; }

    [Required]
    [StringLength(100)]
    public required string Username { get; set; }

    [Required]
    [StringLength(100)]
    public required string Password { get; set; }


    [StringLength(100)]
    public required string FirstName { get; set; }

    [StringLength(100)]
    public required string LastName { get; set; }
}

