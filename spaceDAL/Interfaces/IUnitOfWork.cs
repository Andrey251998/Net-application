using spaceDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceDAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    { 
        IRepository<User> users { get; }
        IRepository<Order> orders { get; }

        IClientRepository<Client> clients { get; }

        void save();
    }
}
