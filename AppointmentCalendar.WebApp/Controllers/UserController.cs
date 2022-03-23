using AppointmentCalendar.BLL;
using AppointmentCalendar.BLL.Entities;
using AppointmentCalendar.BLL.Interfaces;
using AppointmentCalendar.BLL.Models;
using AppointmentCalendar.BLL.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentCalendar.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IPersonService _userService;
        private readonly IMapper _mapper;
        private readonly UsersContext _userContext;
        private readonly ILogger<HomeController> _logger;

        public UserController(IPersonService userService, IMapper mapper, UsersContext userContext, ILogger<HomeController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _userContext = userContext;
            _logger = logger;
        }

        // GET: UserController
        public async Task<IActionResult> Index()
        {
            //var users = _userService.GetAll();

            if (!_userContext.Users.Any())
            {
                _logger.LogInformation("Wprowadzam dane do bazy ...");
                var players = _userService.GetAll();
                foreach (var item in players)
                {
                    _userContext.Add(item);
                }
                _logger.LogInformation("zapis danych do bazy danych ...");
                await _userContext.SaveChangesAsync();
            }

            var database = _userContext.Users;
            var users = _mapper.Map<List<UserView>>(database);
            return View(users);
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var baseUser = await _userContext.Users.FindAsync(id);
            var user = _mapper.Map<UserView>(baseUser);

            if (user == null)
            {
                return NotFound();
            }
            _logger.LogInformation($"Wybrales gracza {user.FirstName} z bazy danych z mapowanego do widoku");
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userContext.Add(user);
                await _userContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var userView = _mapper.Map<UserView>(user);

            return View(userView);
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userContext.Users.FindAsync(id);
            if (user == null)
            {
                _logger.LogError($"Brak w bazie danych gracza od Id {id}");
                return NotFound();
            }
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userContext.Update(user);
                    _userContext.SaveChanges();
                    _logger.LogInformation($"Uzytkownik {user.LastName} zostal zmodyfikowany");
                    return RedirectToAction(nameof(Index));
                }   
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userContext.Users
                .FirstOrDefault(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UserController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var user = await _userContext.Users.FindAsync(id);
                _userContext.Users.Remove(user);
                _userContext.SaveChanges();

                _logger.LogWarning("Get({Id}) you deleted uzytkownika from data base! ", user.LastName);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}
