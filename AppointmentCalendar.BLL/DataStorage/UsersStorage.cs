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
            new User {FirstName = "Mariusz", LastName = "Bobek", Address="Sadowa", AddressCorrespondence="",Email="mb@example.com", PhoneMobile="501622578", PhoneNumber=null},
            new User {FirstName = "Mario", LastName = "Bros" , Address="Brosowo", AddressCorrespondence="",Email="mbros@example.com", PhoneMobile=null, PhoneNumber="552391376"}
        };
    }
}
