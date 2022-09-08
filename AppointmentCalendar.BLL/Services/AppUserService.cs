using AppointmentCalendar.BLL.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentCalendar.BLL.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UsersContext _userContext;
        private readonly ILogger<AppUserService> _logger;
        private readonly IMapper _mapper;

        public AppUserService(UsersContext userContext, ILogger<AppUserService> logger, IMapper mapper)
        {
            _userContext = userContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserView>> GetAll()
        {
            var usersView = new List<UserView>();
            if (!_userContext.Users.Any())
            {
                return usersView;//empty
            }

            _logger.LogInformation("Otwieram baze ...");
            var users = _userContext.Users.ToList();
            usersView = _mapper.Map<List<UserView>>(users);

            return usersView;
        }

    }
}
