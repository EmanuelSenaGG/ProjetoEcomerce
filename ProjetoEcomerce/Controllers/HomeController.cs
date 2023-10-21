using Microsoft.AspNetCore.Mvc;
using ProjetoEcomerce.Models;
using System.Diagnostics;

namespace ProjetoEcomerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {

            if (TempData.ContainsKey("CreateMessage"))
            {
                ViewBag.CreateMessage = TempData["CreateMessage"];
            }

            return View();
        }
        public IActionResult CreateUser()
        {
            if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            return View();
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}