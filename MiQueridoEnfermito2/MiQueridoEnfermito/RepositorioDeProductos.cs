using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiQueridoEnfermito
{
    public class RepositorioDeProductos
    {
        ManejadorDeArchivos archivoProductos;
        List<Productos> Prodctos;
        public RepositorioDeProductos()
        {
           
            archivoProductos = new ManejadorDeArchivos("Productos.poo");
            Prodctos = new List<Productos>();
        }
        public bool AgregarAmigo(Productos producto)
        {
            Prodctos.Add(producto);
            bool resultado = ActualizarArchivo();
            Prodctos = LeerProductos();
            return resultado;
        }

        public bool EliminarProducto(Productos producto)
        {
            Productos temporal = new Productos();
            foreach (var item in Prodctos)
            {
                if (item.NombreProducto == producto.NombreProducto)
                {
                    temporal = item;
                }
            }
            Prodctos.Remove(temporal);
            bool resultado = ActualizarArchivo();
            Prodctos = LeerProductos();
            return resultado;
        }

        public bool ModificarProductos(Productos original, Productos modificado)
        {
            Productos temporal = new Productos();
            foreach (var item in Prodctos)
            {
                if (original.NombreProducto == item.NombreProducto)
                {
                    temporal = item;
                }
            }
            temporal.NombreProducto = modificado.NombreProducto;
            temporal.DescripcionProducto = modificado.DescripcionProducto;
            temporal.PrecioCompra = modificado.PrecioCompra;
            temporal.PrecioVenta = modificado.PrecioVenta;
            temporal.PresentacionProducto = modificado.PresentacionProducto;
            bool resultado = ActualizarArchivo();
            Prodctos = LeerProductos();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Productos item in Prodctos)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}\n", item.NombreProducto, item.PresentacionProducto, item.PrecioCompra, item.PrecioVenta, item.PresentacionProducto);
            }
            return archivoProductos.Guardar(datos);
        }
        public List<Productos> LeerProductos()
        {
            string datos = archivoProductos.Leer();
            if (datos != null)
            {
                List<Productos> productos = new List<Productos>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Productos a = new Productos()
                    {
                        NombreProducto = campos[0],
                        DescripcionProducto = campos[1],
                        PrecioCompra = campos[2],
                        PrecioVenta = campos[3],
                        PresentacionProducto= campos[4]
                    };
                    productos.Add(a);
                }
                Prodctos = productos;
                return productos;
            }
            else
            {
                return null;
            }
        }
    
    
    }
}

