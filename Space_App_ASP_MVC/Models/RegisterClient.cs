using System.ComponentModel.DataAnnotations;

namespace Space_App_ASP_MVC.Models
{
    public class RegisterClient
    {
        public string? Email { get;set;}
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
