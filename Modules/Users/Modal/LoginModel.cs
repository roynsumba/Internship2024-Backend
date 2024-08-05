using System.ComponentModel.DataAnnotations;

namespace AppraisalTracker.Modules.Login
{
    public class LoginModel{
        [Required]
        
        public required string Username { get; set; }
        
        [Required]
        public required string Password { get; set; }
    }
}