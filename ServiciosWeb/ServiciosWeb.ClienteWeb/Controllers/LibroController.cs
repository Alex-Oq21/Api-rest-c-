using Newtonsoft.Json;
using ServiciosWeb.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;

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
        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(Libro libro)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:60702/");
            var request = clienteHttp.PostAsync("api/Libro", libro, new JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);
                if (correcto)
                {
                    return RedirectToAction("index");
                }
                return View(libro);
            }
            return View(libro);
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:60702/");
            var request = clienteHttp.GetAsync("api/Libro?id=" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<Libro>(resultString);
                return View(informacion);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(Libro libro)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:60702/");
            var request = clienteHttp.PutAsync("api/Libro", libro, new JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);
                if (correcto)
                {
                    return RedirectToAction("index");
                }
                return View(libro);
            }
            return View(libro);
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:60702/");
            var request = clienteHttp.DeleteAsync("api/Libro?id=" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);
                if (correcto)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Detalle(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:60702/");
            var request = clienteHttp.GetAsync("api/Libro?id=" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<Libro>(resultString);
                return View(informacion);
            }
            return View();
        }
    }
}