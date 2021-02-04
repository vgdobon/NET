using System;

namespace Version3.ClasesPersona
{
    class Trabajador: Persona
    {
        public decimal Sueldo { get; set; }

        public override void MostrarDetalles()
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
