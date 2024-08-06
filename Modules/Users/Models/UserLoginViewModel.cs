
namespace AppraisalTracker.Modules.Users.Models;

public class UserLoginViewModel
{
    public Guid UserId { get; set; }
    public required string Username { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
