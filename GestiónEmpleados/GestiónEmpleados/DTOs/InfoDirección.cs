using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónEmpleados.DTOs
{
    class InfoDirección : InfoTrabajador
    {

        public string Cargo { get; set; }
        public InfoDirección(string dni, string nombre, string apellidos, DateTime fechaNacimiento, string dirección, string cargo) : base(dni, nombre, apellidos, fechaNacimiento, dirección)
        {
            this.Cargo = cargo;
        }

        public override string ToString()
        {
            return $"{base.ToString()},\n {nameof(Cargo)}: {Cargo}\n";
        }
    }
}
