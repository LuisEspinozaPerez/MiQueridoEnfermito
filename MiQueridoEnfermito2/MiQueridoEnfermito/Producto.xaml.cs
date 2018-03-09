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
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        RepositorioDeProductos repositorio;
        bool esNuevo;
        public Producto()
        {
            InitializeComponent();
            repositorio = new RepositorioDeProductos();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            dtgProducto.ItemsSource = null;
            dtgProducto.ItemsSource = repositorio.LeerProductos();
        }

        private void HabilitarBotones(bool habilitados)
        {
            btnGuardar.IsEnabled = !habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnCancelar.IsEnabled = !habilitados;
        }

        private void HabilitarCajas(bool habilitadas)
        {
            txbNombreProducto.Clear();
            txbDescripcion.Clear();
            txbPrecioCompra.Clear();
            txbPrecioVenta.Clear();
            txbPresentacion.Clear();
            txbNombreProducto.IsEnabled= habilitadas;
            txbDescripcion.IsEnabled= habilitadas;
            txbPrecioCompra.IsEnabled= habilitadas;
            txbPrecioVenta.IsEnabled= habilitadas;
            txbPresentacion.IsEnabled = habilitadas;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerProductos().Count == 0)
            {
                MessageBox.Show("No tienes productos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgProducto.SelectedItem != null)
                {
                    Productos a = dtgProducto.SelectedItem as Productos;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.NombreProducto + "?", "¿Eliminar?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarProducto(a))
                        {
                            MessageBox.Show("El producto ha sido removido", "Productos", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿Que deseas eliminar", "No tienes productos", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(false);
            HabilitarBotones(true);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerProductos().Count==0)
            {
                MessageBox.Show("No tienes productos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgProducto.SelectedItem != null)
                {
                    Productos a = dtgProducto.SelectedItem as Productos;
                    HabilitarCajas(true);
                    txbNombreProducto.Text = a.NombreProducto;
                    txbDescripcion.Text = a.DescripcionProducto;
                    txbPrecioCompra.Text = a.PrecioCompra;
                    txbPrecioVenta.Text = a.PrecioVenta;
                    txbPresentacion.Text = a.PresentacionProducto;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿Que producto?", "Producto", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txbNombreProducto.Text) || string.IsNullOrEmpty(txbDescripcion.Text) || string.IsNullOrEmpty(txbPrecioCompra.Text) || string.IsNullOrEmpty(txbPrecioVenta.Text) || string.IsNullOrEmpty(txbPresentacion.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Productos a = new Productos()
                {
                    NombreProducto = txbNombreProducto.Text,
                    DescripcionProducto = txbDescripcion.Text,
                    PrecioCompra= txbPrecioCompra.Text,
                    PrecioVenta= txbPrecioVenta.Text,
                    PresentacionProducto=txbPresentacion.Text,
                };
                if (repositorio.AgregarAmigo(a))
                {
                    MessageBox.Show("Guardado con Éxito", "PProductos", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Productos original = dtgProducto.SelectedItem as Productos;
                Productos a = new Productos();
                a.NombreProducto = txbNombreProducto.Text;
                a.DescripcionProducto = txbDescripcion.Text;
                a.PrecioCompra = txbPrecioCompra.Text;
                a.PrecioVenta = txbPrecioVenta.Text;
                a.PresentacionProducto = txbPresentacion.Text;
                if (repositorio.ModificarProductos(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su producto a sido actualizado", "Productos", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarBotones(false);
            esNuevo = true;
        }
    }
}
