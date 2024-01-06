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
    public class ClientRepository:IClientRepository<Client>
    {
        private Application_Context db;

        public ClientRepository(Application_Context _context)
        {
            this.db = _context;
        }
        public void ClientNew(Client client)
        {
            db.clients.Add(client);
            db.SaveChanges();
        }
    }
}
