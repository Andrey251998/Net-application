using Microsoft.EntityFrameworkCore;


namespace Space_App_ASP_MVC.Models
{
    public class Application_context:DbContext
    {
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Orders> Orders { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null;
        public Application_context(DbContextOptions<Application_context> options) : base(options)
        {


            Database.EnsureCreated();

        }

    }
}
