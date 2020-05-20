using ServiciosWeb.ClienteConsola.ServiceLibroASMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServiciosWeb.ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Invoca servicio ASMX
          //ServicioLibroSoapClient cliente = new ServicioLibroSoapClient();
          // var libros = cliente.ObtenerLibros();
          //  //Invocar servicio WCF
          //  ServiceLibroWCF.Service1Client clienteWCF = new ServiceLibroWCF.Service1Client();
          //  var libros2 = clienteWCF.ObtenerLibros();

            //Invocar servicio REST
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:60702/");
            var request = clienteHttp.GetAsync("api/Libro").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Libro>>(resultString);
                foreach (var item in listado)
                {
                    Console.WriteLine(item.Titulo);
                }
                Console.ReadLine();
            }
        }
    }
}
