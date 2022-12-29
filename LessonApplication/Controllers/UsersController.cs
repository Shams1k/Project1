using BL;
using Entities;
using Interfaces;
using LessonApplication.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LessonApplication.Controllers
{
    public class UsersController : Controller
    {
        private IUsersBL _bl;
        public UsersController(IUsersBL bl)
        {
            _bl = bl;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = _bl.GetByLogin(loginModel.Login);
            
            if (user != null && user.Password == loginModel.Password) {
                var identity = new CustomUserIdentity(user);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));   
            }
            return RedirectToAction("StartGame", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel registrationModel)
        {
            Users newUser = new Users()
            {
                Name = registrationModel.Name,
                Login = registrationModel.Login,
                Password = registrationModel.Password,
                CreationDate = DateTime.Now
            };
            _bl.PutUser(newUser);
            var identity = new CustomUserIdentity(newUser);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return RedirectToAction("StartGame", "Home");
        }


        public IActionResult Get(int id) {
            var user = _bl.GetById(id);

            if (user != null)
            {
                return View(new UserModel() { Id = user.Id, Name = $"{user.Name}" });
            }
            else {
                return View();
            }            
        }

    }
}
