using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiQueridoEnfermito
{

    public class RepositorioDeVentas
    {
       
        public bool GenerarTicket(string nombreCliente, int cantidad, double precio, string productos, double TotalPagar, string empleado, string ruta)
        {
            StreamWriter archivo = new StreamWriter(ruta);
            archivo.WriteLine("\tMi Querido Enfermito");
            archivo.WriteLine("Fecha: "+ DateTime.Now.ToLongDateString());
            archivo.WriteLine("Empleado: "+ empleado);
            archivo.WriteLine("Cliente: "+ nombreCliente);
            archivo.WriteLine("\nCantidad\tProducto\tPrecio\tPresentacion");
            archivo.Write(""+cantidad);
            archivo.Write("\t\t\t" + productos);
            archivo.WriteLine("\nTotal: $" + TotalPagar);
            archivo.WriteLine("\tGracias por su compra.");
            archivo.Close();
            return true;
        }
    }
}
