using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// Note: IActionResult is an abstraction for multiple return types
namespace BulkyBookWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Note : This returns the corresponding view related to Homecontroller and Index
            return View();
        }

        public IActionResult Privacy()
        {
            // This returns corresponding Privacy view
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}