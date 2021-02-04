using System;

namespace Version1.ClasesPersona
{
    class Desempleado
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public decimal Subsidio { get; set; }
        public bool EsHombre { get; set; }

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
