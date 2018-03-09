using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiQueridoEnfermito
{
    /// <summary>
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        RepositorioDeClientes repositorioDeClientes;
        RepositorioDeEmpleados repositorioDeEmpleados;
        RepositorioDeProductos repositorioDeProductos;
        RepositorioDeVentas repositorioDeVentas;
        ManejadorDeArchivos archivo;
        public Ventas()
        {
            InitializeComponent();
            repositorioDeProductos = new RepositorioDeProductos();
            repositorioDeEmpleados = new RepositorioDeEmpleados();
            repositorioDeClientes = new RepositorioDeClientes();
            repositorioDeVentas = new RepositorioDeVentas();
            cmbCliente.ItemsSource = repositorioDeClientes.LeerClientes();
            cmbEmpleado.ItemsSource = repositorioDeEmpleados.LeerEmpleado();
            cmbProductos.ItemsSource = repositorioDeProductos.LeerProductos();
            
        }

        private void btnTotalPagar_Click(object sender, RoutedEventArgs e)
        {
            Venta venta = new Venta();
            venta.cantidad = int.Parse(txbcantidad.Text);
            venta.precio = float.Parse(txbprecio.Text);
            txbTotalPagar.Text = venta.TotalPagar().ToString();
            
        }

        private void btnGenerarVenta_Click(object sender, RoutedEventArgs e)
        {
            RepositorioDeVentas archivo = new RepositorioDeVentas();
            if (repositorioDeVentas.GenerarTicket(cmbCliente.Text, int.Parse(txbcantidad.Text), int.Parse(txbprecio.Text), cmbProductos.Text, int.Parse(txbTotalPagar.Text),cmbEmpleado.Text, cmbCliente.Text+".poo"))
            {
                MessageBox.Show("Venta exitosa", "Ticket Generado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo realizar la venta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }

       
}

