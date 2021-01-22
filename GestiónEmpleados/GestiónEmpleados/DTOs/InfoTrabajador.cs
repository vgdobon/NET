using System;

namespace GestiónEmpleados.DTOs
{
    class InfoTrabajador
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        private DateTime FechaNacimiento { get; set; }
        public string Dirección { get; set; }

        public DateTime FechaBaja;


        public InfoTrabajador(string dni, string nombre, string apellidos, DateTime fechaNacimiento, string dirección)
        {
            Dni = dni ?? throw new ArgumentNullException(nameof(dni));
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            FechaNacimiento = fechaNacimiento;
            Dirección = dirección ?? throw new ArgumentNullException(nameof(dirección));
        }

        public override string ToString()
        {
            return $"{nameof(Dni)}: {Dni},\n {nameof(Nombre)}: {Nombre},\n {nameof(Apellidos)}: {Apellidos},\n {nameof(Dirección)}: {Dirección}\n";
        }
    }
}
