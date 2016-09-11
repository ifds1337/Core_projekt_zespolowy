using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjZesp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Strona kontaktowa";

            return View();
        }

        public IActionResult Pokoje()
        {
            ViewData["Message"] = "info o pokojach";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
