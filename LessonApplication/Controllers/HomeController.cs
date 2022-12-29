using BL.Interfaces;
using Entities;
using Interfaces;
using LessonApplication.Models;
using LessonApplication.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LessonApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUsersBL _userBl;
        private IGameBl _gameBl;

        public HomeController(ILogger<HomeController> logger, IUsersBL usersBl, IGameBl gameBl)
        {
            _logger = logger;
            _userBl = usersBl;
            _gameBl = gameBl;
        }

        [Authorize]
        public IActionResult Index(int id, string name)
        {
            TempData["Success"] = "Success";

            if (User.Identity.IsAuthenticated) {
                var userName = User.Identity.Name;
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return Json(new { Id = 1, Name = "Nikto" });
        }


        public IActionResult Info() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Authorize]
        public IActionResult StartGame()
        {
            Game newGame = new Game();
            GameModel gameModel = new GameModel()
            {
                Score = 0,
                GameDate = DateTime.Now,
                UserId = _userBl.GetByLogin(User.Identity.Name).Id
            };
            return View(gameModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult SaveGame(int score)
        {
            Game game = new Game()
            {
                Score = score,
                GameDate = DateTime.Now,
                UserId = _userBl.GetByLogin(User.Identity.Name).Id
            };
            _gameBl.PutGame(game);

            return RedirectToAction("StartGame", "Home");
        }
    }
}
