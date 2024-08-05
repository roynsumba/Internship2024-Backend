using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppraisalTracker.Modules.Login
{
    public class LoginModel
    {
        [Required]

        public required string Username { get; set; }

        [Required]
        [PasswordPropertyText]
        public required string Password { get; set; }
    }
}