using Actividad8.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Actividad8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ImagePage : Page
    {

        Photo img;

        public ImagePage()
        {
            this.InitializeComponent();
        }
        // Método ue se llama cuando 
        // obtiene el parámetro  y lo asgina al textBox.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            img = (Photo)e.Parameter;
            BitmapImage i = new BitmapImage();
            i.UriSource = new Uri(img.GetStringUrl());
            image.Source = i;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }


        private async void ShareAppBarButton_Click(object sender, object e)
        {
            var data = $" Por favor revisa la siguiente imagen es muy interesante {img.GetStringUrl()}";

            await ComposeEmail(data, null);
        }


        private async Task ComposeEmail( string messageBody, StorageFile attachmentFile)
        {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Body = messageBody;

            if (attachmentFile != null)
            {
                var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);

                var attachment = new Windows.ApplicationModel.Email.EmailAttachment(
                    attachmentFile.Name,
                    stream);

                emailMessage.Attachments.Add(attachment);
            }

          
          

            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);


        }
    }
}