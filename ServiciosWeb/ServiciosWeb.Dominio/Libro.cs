using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosWeb.Dominio
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Sipnosis { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Idioma { get; set; }
        public string Formato { get; set; }
        public string Genero { get; set; }
        public string Disponible { get; set; }
    }
}
