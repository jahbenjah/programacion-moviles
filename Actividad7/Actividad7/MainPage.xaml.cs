using Actividad7.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Actividad7
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        List<Photo> photos;

        public MainPage()
        {
            this.InitializeComponent();

            photos = new List<Photo>();
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);


            Task task = new Task(DescargarPaginaAsync);
            //Ejecutamos la tarea
            task.Start();
            // Esperamos a que se complete la tarea
            task.Wait();
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
            string page = "https://api.flickr.com/services/rest/?method=flickr.photos.getRecent&api_key=fd52e211b61dfadc2934405aa6854d5c&format=json&nojsoncallback=1&api_sig=529c8bb45bcf2689d6b86f6f6e61caab";

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

                List<string> LigasFotos = new List<string>();


                foreach (Photo f in feed.Photos.Photo)
                {
                    LigasFotos.Add(f.GetStringUrl());
                }

              

            }


          }
     }
}
          
