using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Actividad2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private const int NUMMAXCLIENTES = 100;
        public MainPage()
        {
            this.InitializeComponent();

            btnCalcular.Click += BtnCalcular_Click;

            //Comfigurar el combobox con la sucesion de clientes
            cmbPersonas.Loaded += CmbPersonas_Loaded;
        }



        private void CmbPersonas_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> numClientes = new List<int>();
            for (int i = 1; i <= NUMMAXCLIENTES; i++)
            {
                numClientes.Add(i);
              
            }

            var cmb = (ComboBox) sender;
            cmb.ItemsSource = numClientes;
            cmb.SelectedIndex = 0;
           

        }

        private async  void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Your message here");
            await dialog.ShowAsync();
           
        }
    }
}
