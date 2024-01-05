using System.ComponentModel.DataAnnotations;
namespace Space_App_ASP_MVC.Models
{
    public class Users
    {
        public int Id { get; set; }

   
        public string? Name { get; set; }
 
    public string? LastName { get; set; }
   
    public string? MidName { get; set; }


        [DataType(DataType.Date)]
        
        public DateTime Date_Birthday { get; set; }
        
        
    }
}

