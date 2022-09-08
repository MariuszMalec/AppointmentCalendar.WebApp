using AppointmentCalendar.BLL.Models;
using AppointmentCalendar.BLL.Services;
using AppointmentCalendar.WebApp.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AppointmentCalendar.Tests.UserControllerTests
{
    public class AppUserControllerTests
    {
        [Fact]
        public void Index_IsNotActionResult_ReturnError()
        {
            var mock = new Mock<IAppUserService>();
            mock.Setup(u => u.GetAll())
                .ReturnsAsync(new List<UserView>()
                      {
                        new UserView()
                        {
                            Id=1,
                            FirstName="",
                            LastName ="",
                            CreatedAt=DateTime.Now
                        }
                      });
            var controller = new AppUserController(mock.Object);

            var result = controller.Index();

            // Assert
            Assert.IsType<Task<ActionResult<List<UserView>>>>(result);
            result.Result.Should().NotBeNull();
        }
    }
}
