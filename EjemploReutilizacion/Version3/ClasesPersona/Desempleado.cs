using System;

namespace Version3.ClasesPersona
{
    class Desempleado: Persona
    {
        public decimal Subsidio { get; set; }

        public override void MostrarDetalles()
        {
            string textoGenero = "el desempleado";
            if (EsHombre == false)
            {
                textoGenero = "la desempleada";
            }

            Console.WriteLine($"Soy {textoGenero} {Nombre} {Apellidos} y cobro un subsidio de {Subsidio}");
        }
    }
}
