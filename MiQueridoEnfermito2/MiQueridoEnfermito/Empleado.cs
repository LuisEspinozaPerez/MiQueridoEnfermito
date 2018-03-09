using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiQueridoEnfermito
{
    public class Empleado
    {
        public string NombreEmpleado { get; set; }
        public string NumeroEmpleado { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", NombreEmpleado);
        }
    }
}
