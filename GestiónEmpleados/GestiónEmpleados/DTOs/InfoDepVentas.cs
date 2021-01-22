using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónEmpleados.DTOs
{
    class InfoDepVentas : InfoTrabajador
    {
        public string ZonaComercial { get; set; }
        public InfoDepVentas(string dni, string nombre, string apellidos, DateTime fechaNacimiento, string dirección, string zonaComercial) : base(dni, nombre, apellidos, fechaNacimiento, dirección)
        {
            this.ZonaComercial = zonaComercial;
        }

        public override string ToString()
        {
            return $"{base.ToString()},\n {nameof(ZonaComercial)}: {ZonaComercial}\n";
        }
    }
}
