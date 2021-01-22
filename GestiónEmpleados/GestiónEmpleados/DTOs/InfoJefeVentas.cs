using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónEmpleados.DTOs
{
    class InfoJefeVentas : InfoDepVentas
    {
        public InfoJefeVentas(string dni, string nombre, string apellidos, DateTime fechaNacimiento, string dirección, string zonaComercial) : base(dni, nombre, apellidos, fechaNacimiento, dirección, zonaComercial)
        {
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n";
        }
    }
}
