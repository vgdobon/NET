using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class Persona
    {
        public string Dni;
        public string Nombre;
        public string Apellidos;

        public Persona(string dni, string nombre, string apellidos)
        {
            Dni = dni;
            Nombre = nombre;
            Apellidos = apellidos;
        }
    }
}
