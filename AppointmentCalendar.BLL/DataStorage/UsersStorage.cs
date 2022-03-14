using AppointmentCalendar.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentCalendar.BLL.DataStorage
{
    public class UsersStorage
    {
        public static List<User> Users = new List<User>
        {
            new User {FirstName = "Bob", LastName = "Bobek" },
            new User {FirstName = "Mario", LastName = "Bros" }
        };
    }
}
