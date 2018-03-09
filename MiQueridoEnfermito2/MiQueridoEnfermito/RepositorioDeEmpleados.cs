using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiQueridoEnfermito
{
    class RepositorioDeEmpleados
    {
        ManejadorDeArchivos archivoEmpleados;
        List<Empleado> Empleados;
        public RepositorioDeEmpleados()
        {
            archivoEmpleados = new ManejadorDeArchivos("Empleados.poo");
            Empleados = new List<Empleado>();
        }

        public bool AgregarEmpleado(Empleado amigo)
        {
            Empleados.Add(amigo);
            bool resultado = ActualizarArchivo();
            Empleados = LeerEmpleado();
            return resultado;
        }

        public bool EliminarEmpleado(Empleado amigo)
        {
            Empleado temporal = new Empleado();
            foreach (var item in Empleados)
            {
                if (item.NombreEmpleado == amigo.NombreEmpleado)
                {
                    temporal = item;
                }
            }
            Empleados.Remove(temporal);
            bool resultado = ActualizarArchivo();
            Empleados = LeerEmpleado();
            return resultado;
        }

        public bool ModificarEmpleado(Empleado original, Empleado modificado)
        {
            Empleado temporal = new Empleado();
            foreach (var item in Empleados)
            {
                if (original.NombreEmpleado == item.NombreEmpleado)
                {
                    temporal = item;
                }
            }
            temporal.NombreEmpleado = modificado.NombreEmpleado;
            temporal.NumeroEmpleado = modificado.NumeroEmpleado;
            bool resultado = ActualizarArchivo();
            Empleados = LeerEmpleado();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Empleado item in Empleados)
            {
                datos += string.Format("{0}|{1}\n", item.NombreEmpleado, item.NumeroEmpleado);
            }
            return archivoEmpleados.Guardar(datos);
        }
        public List<Empleado> LeerEmpleado()
        {
            string datos = archivoEmpleados.Leer();
            if (datos != null)
            {
                List<Empleado> empleados = new List<Empleado>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Empleado a = new Empleado()
                    {
                        NombreEmpleado = campos[0],
                        NumeroEmpleado = campos[1],
                    };
                    empleados.Add(a);
                }
                Empleados = empleados;
                return empleados;
            }
            else
            {
                return null;
            }
        }
    }
}
