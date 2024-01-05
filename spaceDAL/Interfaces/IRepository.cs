using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceDAL.Interfaces
{
    public  interface IRepository<T> where T : class
    {
             T Get(int id);
            void create(T item);
            void delete(int id);
            void update(T item);
            IEnumerable<T> GetAll();
    }
}
