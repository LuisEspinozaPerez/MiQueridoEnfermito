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
    /// Lógica de interacción para Empleados.xaml
    /// </summary>
    public partial class Empleados : Window
    {
        RepositorioDeEmpleados repositorio;
        bool esNuevo;
        public Empleados()
        {
            InitializeComponent();
            repositorio = new RepositorioDeEmpleados();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }
        private void HabilitarCajas(bool habilitadas)
        {
            txbNombreEmpleado.Clear();
            txbNoEmpleado.Clear();
            txbNombreEmpleado.IsEnabled = habilitadas;
            txbNoEmpleado.IsEnabled = habilitadas;
        }

        private void HabilitarBotones(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
        }
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarBotones(false);
            esNuevo = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreEmpleado.Text) || string.IsNullOrEmpty(txbNoEmpleado.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Empleado a = new Empleado()
                {
                    NombreEmpleado = txbNombreEmpleado.Text,
                    NumeroEmpleado = txbNoEmpleado.Text,
                };
                if (repositorio.AgregarEmpleado(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Empleados", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar al empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empleado original = dtgEmpleados.SelectedItem as Empleado;
                Empleado a = new Empleado();
                a.NombreEmpleado = txbNombreEmpleado.Text;
                a.NumeroEmpleado = txbNoEmpleado.Text;
                if (repositorio.ModificarEmpleado(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su empleado a sido actualizado", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar al empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ActualizarTabla()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = repositorio.LeerEmpleado();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerEmpleado().Count == 0)
            {
                MessageBox.Show("No hay que editar...", "No tienes empleados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgEmpleados.SelectedItem != null)
                {
                    Empleado a = dtgEmpleados.SelectedItem as Empleado;
                    HabilitarCajas(true);
                    txbNombreEmpleado.Text = a.NombreEmpleado;
                    txbNoEmpleado.Text = a.NumeroEmpleado;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Empleados", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(false);
            HabilitarBotones(true);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerEmpleado().Count == 0)
            {
                MessageBox.Show("No tienes que eliminar...", "No tienes empleados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgEmpleados.SelectedItem != null)
                {
                    Empleado a = dtgEmpleados.SelectedItem as Empleado;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.NombreEmpleado + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarEmpleado(a))
                        {
                            MessageBox.Show("Tu empleado ha sido removido", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar a tu empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Empleado", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
