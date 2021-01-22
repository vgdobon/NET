using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónEmpleados.DTOs
{
    class InfoComercial : InfoDepVentas
    {
        public InfoJefeVentas Responsable { get; set; }

        public InfoComercial(string dni, string nombre, string apellidos, DateTime fechaNacimiento, string dirección, string zonaComercial, InfoJefeVentas responsable) : base(dni, nombre, apellidos, fechaNacimiento, dirección, zonaComercial)
        {
            Responsable = responsable;
        }

        public override string ToString()
        {
            return $"{base.ToString()},\n {nameof(Responsable)}: {Responsable}\n";
        }
    }
}
