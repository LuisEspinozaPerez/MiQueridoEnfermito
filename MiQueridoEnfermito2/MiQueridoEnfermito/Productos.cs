using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiQueridoEnfermito
{
    public class Productos
    {
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string PrecioCompra { get; set; }
        public string PrecioVenta { get; set; }
        public string PresentacionProducto { get; set; }
        public override string ToString()
        {
            return string.Format("{0} ${1} {2}", NombreProducto, PrecioVenta, PresentacionProducto);
        }
    }
}
