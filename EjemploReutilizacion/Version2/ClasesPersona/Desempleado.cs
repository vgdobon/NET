using System;

namespace Version2.ClasesPersona
{
    class Desempleado: Persona
    {
        public decimal Subsidio { get; set; }

        public void MostrarDetallesDesempleado()
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
