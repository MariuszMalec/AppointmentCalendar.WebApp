using AppointmentCalendar.BLL.Entities;
using AppointmentCalendar.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentCalendar.BLL.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool DeleteById(int id);
        User Create(User newEmployee);
        bool Update(int id, User employee);
    }
}
