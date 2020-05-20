using ServiciosWeb.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosWeb.WebApi.Controllers
{
    public class LibroController : ApiController
    {
        LibreriaConnection BD = new LibreriaConnection();
        [HttpGet]
        public IEnumerable<Libro> Get()
        {
            var listado = BD.Libro.ToList();
            return listado;
        }
        [HttpGet]
        public Libro Get(int id)
        {
            var libro = BD.Libro.FirstOrDefault(x=> x.IdLibro ==id);
            return libro;
        }
    }
}
