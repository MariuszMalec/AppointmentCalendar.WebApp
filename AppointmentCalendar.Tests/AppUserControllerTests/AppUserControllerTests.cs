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
        public async Task Index_IfViewResultModelNotCorrect_ReturnError()
        {
            var curentViewUsers = GetUsersView();
            var mock = new Mock<IAppUserService>();
            mock.Setup(u => u.GetAll())
                .ReturnsAsync(curentViewUsers);

            var controller = new AppUserController(mock.Object);

            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.Equal(curentViewUsers, result.Model);
        }

        [Fact]
        public async Task Index_IfViewResultTypeNotCorrect_ReturnError()
        {
            var mock = new Mock<IAppUserService>();
            mock.Setup(u => u.GetAll())
                .ReturnsAsync(GetUsersView());

            var controller = new AppUserController(mock.Object);

            var result = await controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        private List<UserView> GetUsersView()
        {
            return new List<UserView>()
            {
                        new UserView()
                        {
                            Id=1,
                            FirstName="Mariusz",
                            LastName ="Bros",
                            CreatedAt=DateTime.Now
                        }
            };
        }
    }
}
