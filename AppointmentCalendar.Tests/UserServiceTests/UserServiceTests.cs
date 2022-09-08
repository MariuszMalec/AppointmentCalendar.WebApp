using AppointmentCalendar.BLL.Entities;
using AppointmentCalendar.BLL.Interfaces;
using AppointmentCalendar.BLL.Services;
using Moq;

namespace AppointmentCalendar.Tests.UserServiceTests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetAll_IfNoUsers_ReturnError()
        {
            var service = new UserService();

            var result = service.GetAll();

            Assert.Equal(2, result.Count());
        }
    }
}
