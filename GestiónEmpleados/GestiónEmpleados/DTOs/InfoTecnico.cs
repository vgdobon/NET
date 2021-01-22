using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónEmpleados.DTOs
{
    class InfoTecnico : InfoDepTecnologia
    {
        public InfoJefeEquipo Responsable { get; set; }
        public InfoTecnico(string dni, string nombre, string apellidos, DateTime fechaNacimiento, string dirección, int yearsExp, string tecnologia, InfoJefeEquipo responsable) : base(dni, nombre, apellidos, fechaNacimiento, dirección, yearsExp, tecnologia)
        {

            this.Responsable = responsable;
        }

        public override string ToString()
        {
            return $"{base.ToString()},\n {nameof(Responsable)}: {Responsable}\n";
        }
    }
}
