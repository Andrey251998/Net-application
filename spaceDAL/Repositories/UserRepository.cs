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
    public class UserRepository:IRepository<User>
    {
        private Application_Context db;

        public UserRepository(Application_Context _context)
        {
            this.db= _context;
        }
        public User Get(int id)
        {
            return db.users.Find(id);
        }
        public void create(User user)
        {
            db.users.Add(user);
            db.SaveChanges();
        }
        public void delete(int id)
        {
            User user = db.users.Find(id);
            if (user != null)
            {
                db.users.Remove(user);
            }
        }
        public void update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
        public IEnumerable<User> GetAll()
        {
            return db.users;
        }
    }
}
