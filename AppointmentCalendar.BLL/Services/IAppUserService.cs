using AppointmentCalendar.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentCalendar.BLL.Services
{
    public interface IAppUserService
    {
        Task<IEnumerable<UserView>> GetAll();
    }
}