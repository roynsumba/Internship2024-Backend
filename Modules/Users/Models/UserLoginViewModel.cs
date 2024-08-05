
namespace AppraisalTracker.Modules.Login;

    public class UserLoginViewModel
    {
        public Guid UserId { get; set; }
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
