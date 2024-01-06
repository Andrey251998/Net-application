using spaceDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceDAL.Interfaces
{
    public interface IClientRepository<T> where T : class
    {
        void ClientNew(T item);
    }
}
