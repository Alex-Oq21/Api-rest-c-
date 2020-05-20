using ServiciosWeb.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiciosWeb.ServicioASMX
{
    /// <summary>
    /// Descripción breve de ServicioLibro
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioLibro : System.Web.Services.WebService
    {
        LibreriaConnection BD = new LibreriaConnection();
        [WebMethod]
        public List<Libro> ObtenerLibros()
        {
            var listado = BD.Libro.ToList();
            return listado;
        }
    }
}
