using System;

namespace Version1.ClasesPersona
{
    class Trabajador
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public decimal Sueldo { get; set; }
        public bool EsHombre { get; set; }

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
