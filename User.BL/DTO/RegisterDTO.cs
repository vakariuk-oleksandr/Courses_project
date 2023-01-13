using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project.BL.DTO
{
    public class RegisterDTO
    {
        public string Gmail { get; set; }

        public string Password { get; set; }

        public string City { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDay { get; set; }

        public string PhoneNumber { get; set; }

    }
}
