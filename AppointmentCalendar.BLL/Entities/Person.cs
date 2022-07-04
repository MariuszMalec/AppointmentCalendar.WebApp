using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentCalendar.BLL.Entities
{
    public class Person : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string AddressCorrespondence { get; set; }

        public int PhoneNumber { get; set; }

        public string PhoneMobile { get; set; }
    }
}
