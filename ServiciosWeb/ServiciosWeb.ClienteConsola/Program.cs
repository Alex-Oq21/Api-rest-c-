using ServiciosWeb.ClienteConsola.ServiceLibroASMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosWeb.ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Invoca servicio ASMX
          ServicioLibroSoapClient cliente = new ServicioLibroSoapClient();
           var libros = cliente.ObtenerLibros();

            ServiceLibroWCF.Service1Client clienteWCF = new ServiceLibroWCF.Service1Client();
            var libros2 = clienteWCF.ObtenerLibros();
        }
    }
}
