using Actividad6.Modelos;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Actividad6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creamos una nueva tarea asincrona con la acción DescargarPaginaAsync.(Expresion Lambda)
            Task task = new Task(DescargarPaginaAsync);
            //Ejecutamos la tarea
            task.Start();

            Console.WriteLine("Consultando la API de Flickr");
            Console.WriteLine("Esperando respuesta....");
            // Esperamos a que se complete la tarea
            task.Wait();
            Console.ReadLine();

        }

        private async static void DescargarPaginaAsync()
        {
            /* Solicitud a la API de Flickr
             * https://www.flickr.com/services/api/flickr.photos.getRecent.html
            * methodo:flickr.photos.getRecent
            * apikey:a96dc9bef0f55c1b09c73f2d6bc1fd67
            * formato de salida : json (default xml)
            *  
            * 
            */
            string page = "https://api.flickr.com/services/rest/?method=flickr.photos.getRecent&api_key=a96dc9bef0f55c1b09c73f2d6bc1fd67&format=json&nojsoncallback=1&api_sig=afff628faca3c2041504d5f6517f9637";

            // HttpClient para solicitar la pagina
            // usin sirver para que .netframework gsetione los objetos IDisposable de forma automatica.
            // otra opcion seria usar try catch y cerreando las conecciones manualmenten
            //https://msdn.microsoft.com/en-us/library/yh598w02.aspx


            using (HttpClient cliente = new HttpClient())
            using (HttpResponseMessage respusta = await cliente.GetAsync(page))
            using (HttpContent contenido = respusta.Content)
            {
                // ... Guardamos el JSON como cadena
                string resultado = await contenido.ReadAsStringAsync();
                
                
                // Convertimos el JSON a un Objeto GetRecent con ayuda de la libreria Newtonsoft.Json

                GetRecent feed = JsonConvert.DeserializeObject<GetRecent>(resultado);


                //Impirmimos la cantidad de photos recibidad y la URL

                Console.WriteLine("El estado de la solicitud : {0}", feed.Stat);
                Console.WriteLine("Página actual: {0}", feed.Photos.Page);
                Console.WriteLine("Total de paginas de fotos actuales: {0}", feed.Photos.Pages);
                Console.WriteLine("Fotos por página: {0}", feed.Photos.PerPage);
                Console.WriteLine("Total de fotos  recientes recibidadas: {0}", feed.Photos.Total);
                string s;
                foreach (Photo f in feed.Photos.Photo)
                {
                    s = f.GetStringUrl();

                    Console.WriteLine(s);
                }
            }
        }
    }
}
