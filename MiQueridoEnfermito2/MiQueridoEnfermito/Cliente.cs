﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiQueridoEnfermito
{
    public class Cliente
    {
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", NombreCliente);
        }
    }
}
