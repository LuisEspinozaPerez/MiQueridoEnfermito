using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiQueridoEnfermito
{
    public class Venta
    {
        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }
        public List<Productos> Productos { get; set; }
        public int cantidad{get; set;}
        public double precio { get; set; }
        public double TotalPagar()
        {
            double total;
            return total = cantidad * precio;
        }
    }
}
