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
            //preparar os dados a serem enviados para a View na primeira interação

            ViewBag.Visor = "0";   
            return View();
        }

        [HttpPost] // só quando o formulário for submetido em 'post' ele será acionado
        public IActionResult Index(string botao, string visor, string pOp, string operador)
        {

            switch (botao)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    //pressionei um algarismo
                    if(visor == "0")
                    {
                        visor = botao;
                    }
                    else { visor += botao; }
                    //desafio : fazer em modo algébrico esta operação
                    break;
                case ",":
                    //foi pressionado ','
                    if (visor.Contains(",") == false)
                    {
                        visor += ",";
                    }
                    
                    break;
                case "C":
                    //foi pressionado 'C'
                    if(visor != "0")
                    {
                        visor = "0";
                    }
                    break;
                case "+/-":
                    //vamos inverter o valor do "visor"
                    if (visor.StartsWith("-")){
                        visor = visor.Substring(1);
                    }
                    else
                    {
                        visor = "-" + visor;
                    }
                    
                    break;
                case "+":
                case "-":
                case "x":
                case ":":
                    //foi pressionado um operador

                    pOp = visor;
                    operador = botao;
                    visor = "";
                    

                    break;
                case "=":
                    
                    
                    string temp = pOp.Replace(",", ".") + operador.Replace("x", "*").Replace(":", "/") + visor;
                    var op = new System.Data.DataTable().Compute(temp, "");
                    visor = op.ToString();
                    

                    break;


            }

            //preparar dados para serem enviados à View
            ViewBag.Visor = visor;
            ViewBag.POp = pOp;
            ViewBag.Operador = operador;
            

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