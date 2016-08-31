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
      
            try
            {
                double cuenta = double.Parse(txtCuenta.Text);
                int propina = int.Parse((cmbPropina.SelectedItem as ComboBoxItem).Content as String);
                int clientes =(int) cmbPersonas.SelectedItem;
                
                var dialog = new MessageDialog("La cuenta es de: $ "+cuenta+ ".\n La propina  :" +propina + "%.\n  El numero de clientes " + clientes);
                await dialog.ShowAsync();
                txtPagoPersonal.Visibility = Visibility.Visible;
                txtPagoPersonal.Text = $"El pago por persona es de ${Math.Round((cuenta*(1+propina/100.0))/clientes,2)} pesos";
            }
            catch (Exception)
            {
                var dialog2 = new MessageDialog("Por favor revise el total. Deben se un número.");
                await dialog2.ShowAsync();
            }
           
           
        }
    }
}
