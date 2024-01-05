using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceDAL.Entities
{
    public class User
    {
        public int Id { get; set; }


        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? MidName { get; set; }


        [DataType(DataType.Date)]

        public DateTime Date_Birthday { get; set; }
    }
}
