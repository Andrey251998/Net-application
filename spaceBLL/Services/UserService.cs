using spaceBLL.Interfaces;
using spaceBLL.UserDTO;
using spaceDAL.Interfaces;
using spaceDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace spaceBLL.Services
{
    public class UserService:IOrderService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void addUser(UserDTO.User user)
        {
            spaceDAL.Entities.User use = new spaceDAL.Entities.User
            {
                Name = user.Name,
                LastName = user.LastName,
                MidName = user.MidName,
                Date_Birthday = user.Date_Birthday
            };

            Database.users.create(use);
        }
        public void removeUser(int id)
        { 
        }
        public void editUser(int id)
        {
            
        }
        public IEnumerable<UserDTO.User> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<spaceDAL.Entities.User, spaceBLL.UserDTO.User>()).CreateMapper();
            return mapper.Map<IEnumerable<spaceDAL.Entities.User>, List<spaceBLL.UserDTO.User>>(Database.users.GetAll());
        }
    }
}
