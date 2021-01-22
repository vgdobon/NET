using System;

namespace GestiónEmpleados.DTOs
{
    internal class InfoJefeEquipo : InfoDepTecnologia
    {
        public InfoJefeEquipo(string dni, string nombre, string apellidos, DateTime fechaNacimiento, string dirección, int yearsExp, string tecnologia) : base(dni, nombre, apellidos, fechaNacimiento, dirección, yearsExp, tecnologia)
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