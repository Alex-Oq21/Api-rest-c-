using Newtonsoft.Json;
using ServiciosWeb.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ServiciosWeb.ClienteWeb.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:60702/");
            var request = clienteHttp.GetAsync("api/Libro").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Libro>>(resultString);

                return View(listado);
            }
            return View(new List<Libro>());
        }
    }
}