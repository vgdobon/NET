using System;

namespace Version2.ClasesPersona
{
    class Trabajador: Persona
    {
        public decimal Sueldo { get; set; }

        public void MostrarDetallesTrabajador()
        {
            string textoGenero = "el trabajador";
            if (EsHombre == false)
            {
                textoGenero = "la trabajadora";
            }

            Console.WriteLine($"Soy {textoGenero} {Nombre} {Apellidos} y cobro un sueldo de {Sueldo}");
        }
    }
}
