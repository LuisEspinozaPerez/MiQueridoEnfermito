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
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        RepositorioDeClientes repositorio;
        bool esNuevo;
        public Clientes()
        {
            InitializeComponent();
            repositorio = new RepositorioDeClientes();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            dtgCliente.ItemsSource = null;
            dtgCliente.ItemsSource = repositorio.LeerClientes();
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
            txbNombreCliente.Clear();
            txbDireccion.Clear();
            txbRfc.Clear();
            txbTelefono.Clear();
            txbCorreo.Clear();
            txbNombreCliente.IsEnabled = habilitadas;
            txbDireccion.IsEnabled = habilitadas;
            txbRfc.IsEnabled = habilitadas;
            txbTelefono.IsEnabled = habilitadas;
            txbCorreo.IsEnabled = habilitadas;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerClientes().Count == 0)
            {
                MessageBox.Show("No tienes clientes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgCliente.SelectedItem != null)
                {
                    Cliente a = dtgCliente.SelectedItem as Cliente;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.NombreCliente + "?", "¿Eliminar?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.Eliminarclientes(a))
                        {
                            MessageBox.Show("El cliente ha sido removido", "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿Que deseas eliminar", "No tienes clientes", MessageBoxButton.OK, MessageBoxImage.Question);
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
            if (repositorio.LeerClientes().Count == 0)
            {
                MessageBox.Show("No tienes clientes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgCliente.SelectedItem != null)
                {
                    Cliente a = dtgCliente.SelectedItem as Cliente;
                    HabilitarCajas(true);
                    txbNombreCliente.Text = a.NombreCliente;
                    txbDireccion.Text = a.Direccion;
                    txbRfc.Text = a.RFC;
                    txbTelefono.Text = a.Telefono;
                    txbCorreo.Text = a.Correo;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿Que producto?", "Clientes", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreCliente.Text) || string.IsNullOrEmpty(txbDireccion.Text) || string.IsNullOrEmpty(txbRfc.Text) || string.IsNullOrEmpty(txbTelefono.Text) || string.IsNullOrEmpty(txbCorreo.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Cliente a = new Cliente()
                {
                    NombreCliente = txbNombreCliente.Text,
                    Direccion = txbDireccion.Text,
                    RFC = txbRfc.Text,
                    Telefono = txbTelefono.Text,
                    Correo = txbCorreo.Text,
                };
                if (repositorio.AgregarAmigo(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar el cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Cliente original = dtgCliente.SelectedItem as Cliente;
                Cliente a = new Cliente();
                a.NombreCliente = txbNombreCliente.Text;
                a.Direccion = txbDireccion.Text;
                a.RFC = txbRfc.Text;
                a.Telefono = txbTelefono.Text;
                a.Correo = txbCorreo.Text;
                if (repositorio.ModificarClientes(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su cliente a sido actualizado", "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar el cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
