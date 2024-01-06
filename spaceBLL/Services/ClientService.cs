using spaceBLL.Interfaces;
using spaceBLL.UserDTO;
using spaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceBLL.Services
{
    public class ClientService:IClient
    {
        IUnitOfWork DataBase { get; set; }

        public ClientService(IUnitOfWork uow) 
        {
            DataBase = uow;
        }
        public void ClientNew(Client client) 
        {
            spaceDAL.Entities.Client cl = new spaceDAL.Entities.Client
            {
                Login = client.Login,
                Email = client.Email,
                Password = client.Password,
            };
            DataBase.clients.ClientNew(cl);
        }
    }
}
