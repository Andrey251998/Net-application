using spaceDAL.Entities;
using spaceDAL.EntityFramework;
using spaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceDAL.Repositories
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private Application_Context db;
        private OrderRepository orderRepository;
        private UserRepository userRepository;

        public EFUnitOfWork()
        {
            db = new Application_Context("Server=localhost;Database=space;User=sa;Password=123;");
        }

        public IRepository<User> users
        {
            get 
            {
                if (userRepository == null)
                
                    userRepository = new UserRepository(db);
                
            return userRepository;
            }
        }
        public IRepository<Order> orders
        {
            get
            {
                if (orderRepository == null)

                    orderRepository = new OrderRepository(db);

                return orderRepository;
            }
        }

        public void save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
