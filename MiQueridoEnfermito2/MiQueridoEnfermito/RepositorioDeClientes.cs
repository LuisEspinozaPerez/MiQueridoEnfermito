using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiQueridoEnfermito
{
    class RepositorioDeClientes
    {
        ManejadorDeArchivos archivoClientes;
        List<Cliente> Clientes;
        public RepositorioDeClientes()
        {

            archivoClientes = new ManejadorDeArchivos("Clientes.poo");
            Clientes = new List<Cliente>();
        }
        public bool AgregarAmigo(Cliente producto)
        {
            Clientes.Add(producto);
            bool resultado = ActualizarArchivo();
            Clientes = LeerClientes();
            return resultado;
        }

        public bool Eliminarclientes(Cliente producto)
        {
            Cliente temporal = new Cliente();
            foreach (var item in Clientes)
            {
                if (item.Telefono == producto.Telefono)
                {
                    temporal = item;
                }
            }
            Clientes.Remove(temporal);
            bool resultado = ActualizarArchivo();
            Clientes = LeerClientes();
            return resultado;
        }

        public bool ModificarClientes(Cliente original, Cliente modificado)
        {
            Cliente temporal = new Cliente();
            foreach (var item in Clientes)
            {
                if (original.Telefono == item.Telefono)
                {
                    temporal = item;
                }
            }
            temporal.NombreCliente = modificado.NombreCliente;
            temporal.Direccion = modificado.Direccion;
            temporal.RFC = modificado.RFC;
            temporal.Telefono = modificado.Telefono;
            temporal.Correo = modificado.Correo;
            bool resultado = ActualizarArchivo();
            Clientes = LeerClientes();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Cliente item in Clientes)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}\n", item.NombreCliente, item.Direccion, item.RFC, item.Telefono, item.Correo);
            }
            return archivoClientes.Guardar(datos);
        }
        public List<Cliente> LeerClientes()
        {
            string datos = archivoClientes.Leer();
            if (datos != null)
            {
                List<Cliente> clientes = new List<Cliente>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Cliente a = new Cliente()
                    {
                        NombreCliente = campos[0],
                        Direccion = campos[1],
                        RFC = campos[2],
                        Telefono = campos[3],
                        Correo = campos[4]
                    };
                    clientes.Add(a);
                }
                Clientes = clientes;
                return clientes;
            }
            else
            {
                return null;
            }
        }
    }
}
