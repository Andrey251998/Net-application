using spaceDAL.Entities;
using spaceDAL.EntityFramework;
using spaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceDAL.Repositories
{
   public class OrderRepository:IRepository<Order>
    {
        private Application_Context db;

        public OrderRepository(Application_Context _context)
        {
            this.db = _context;
        }
        public Order Get(int id)
        {
            return db.orders.Find(id);
        }
        public void create(Order order)
        {
            db.orders.Add(order);
        }
        public void delete(int id)
        {
            Order order = db.orders.Find(id);
            if (order != null)
            {
                db.orders.Remove(order);
            }
        }
        public void update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Order> GetAll()
        {
            return db.orders;
        }
    }
}
