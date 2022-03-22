using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tA__Calculadora.Models;

namespace tA__Calculadora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet] // este anotador é facultativo
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] // só quando o formulário for submetido em 'post' ele será acionado
        public IActionResult Index(string botao)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}