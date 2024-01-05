using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceBLL.UserDTO
{
    public class Order
    {
        public int Id { get; set; }

        public string? title { get; set; }

        public string? Date { get; set; }

        public decimal Price { get; set; }
    }
}
