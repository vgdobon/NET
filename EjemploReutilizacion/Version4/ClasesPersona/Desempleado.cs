using System;

namespace Version4.ClasesPersona
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

        public override void GuardarEnFichero()
        {
            string FormatoSalidaFichero = $"Desempleado|{Nombre}|{Apellidos}|{Subsidio}";

            // (aquí estará el código que guarde la línea anterior en el fichero)

            Console.WriteLine($"guardada en fichero la línea: {FormatoSalidaFichero}");
        }
    }
}
