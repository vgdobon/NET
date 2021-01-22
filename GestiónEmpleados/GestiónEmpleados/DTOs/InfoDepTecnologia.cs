using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónEmpleados.DTOs
{
    class InfoDepTecnologia : InfoTrabajador
    {
        public int YearsExp { get; set; }
        public string Tecnologia { get; set; }
        public InfoDepTecnologia(string dni, string nombre, string apellidos, DateTime fechaNacimiento, string dirección, int yearsExp, string tecnologia) : base(dni, nombre, apellidos, fechaNacimiento, dirección)
        {
            this.YearsExp = yearsExp;
            this.Tecnologia = tecnologia;
        }

        public override string ToString()
        {
            return $"{base.ToString()},\n {nameof(YearsExp)}: {YearsExp},\n {nameof(Tecnologia)}: {Tecnologia}\n";
        }
    }
}
