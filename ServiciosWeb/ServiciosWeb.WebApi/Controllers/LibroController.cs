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
        [HttpPost]
        public  bool Post(Libro libro)
        {
            BD.Libro.Add(libro);
            return BD.SaveChanges() >0;
        }
        [HttpPut]
        public bool Put(Libro libro)
        {
            var libroactulizar = BD.Libro.FirstOrDefault(x => x.IdLibro == libro.IdLibro);
            libroactulizar.Titulo = libro.Titulo;
            libroactulizar.Sipnosis = libro.Sipnosis;
            libroactulizar.Autor = libro.Autor;
            libroactulizar.Editorial = libro.Editorial;
            libroactulizar.Idioma = libro.Idioma;
            libroactulizar.Formato = libro.Formato;
            libroactulizar.Genero = libro.Genero;
            libroactulizar.Disponible = libro.Disponible;
            return BD.SaveChanges() > 0;
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            var libroEliminar = BD.Libro.FirstOrDefault(x => x.IdLibro == id);
            BD.Libro.Remove(libroEliminar);
            return BD.SaveChanges() > 0;

        }
    }
}
