using ConsumiendoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ConsumiendoApi.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Autos()
        {
            //List<AutoModel> listaAutos = new List<AutoModel>();
            //WebRequest webRequest = WebRequest.Create("https://localhost:44311/api/Autos");
            //WebResponse webResponse = webRequest.GetResponse();
            //StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

            //listaAutos = JsonConvert.DeserializeObject<List<AutoModel>>(streamReader.ReadToEnd());
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
