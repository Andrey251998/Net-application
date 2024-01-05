using Microsoft.EntityFrameworkCore;
using spaceDAL.Entities;
using System.Data.Entity;

namespace spaceDAL.EntityFramework
{
    public  class Application_Context: System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<User> users { get; set; }

        public System.Data.Entity.DbSet<Order> orders { get; set; }

        
        public Application_Context(string ConnectionString) : base(ConnectionString)
        {

        }
    }
    



}
