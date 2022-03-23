using AppointmentCalendar.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentCalendar.BLL.Configuration
{
    public static class UserSeed
    {
        private static List<User> _users = new List<User>()//TODO insert startowe dane do bazy
        {
            new User {FirstName = "Mikel", LastName="Jordan" },
            new User {FirstName = "Hakim", LastName="Olajowon"},
            new User {FirstName = "Cledy", LastName="Drexler" }
        };

        public static List<User> GetAll()
        {
            return _users;
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                GetAll()
                );
        }

    }
}
