using Actividad8.Modelos;
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

namespace Actividad8
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

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Task.Run(async () =>
            {
                //Inicializamos el objeto
                using (HttpClient client = new HttpClient())
                {
                    String resultado = await client.GetStringAsync("https://api.flickr.com/services/rest/?method=flickr.photos.getRecent&api_key=6c9ed3a64f891884f5e9547eb1836e9e&format=json&nojsoncallback=1");
                    GetRecent feed = JsonConvert.DeserializeObject<GetRecent>(resultado);
                    photos = feed.Photos.Photo;
                }

            }).Wait();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var photo = (Photo) e.ClickedItem;
            // Navega hacia un pagina tipo PaginaMsg con el parametro ingresado en el TextBox

            Frame.Navigate(typeof(ImagePage),photo);

        }
    }
}
