
using spaceBLL.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceBLL.Interfaces
{
   public interface IOrderService
    {
        void addUser(User user);
        void removeUser(int id);
        IEnumerable<User> GetUsers();
        void editUser(int id);
    }
}
