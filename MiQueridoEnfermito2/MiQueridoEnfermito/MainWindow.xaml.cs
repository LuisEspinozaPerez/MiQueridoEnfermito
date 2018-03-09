﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiQueridoEnfermito
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnventas_Click(object sender, RoutedEventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.Show();
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = new Producto();
            producto.Show();
        }

        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            Empleados empleados = new Empleados();
            empleados.Show();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show();
        }
    }
}
