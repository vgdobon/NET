using System;

namespace Version4.ClasesPersona
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

        public override void GuardarEnFichero()
        {
            string FormatoSalidaFichero = $"Trabajador|{Nombre}|{Apellidos}|{Sueldo}";

            // (aquí estará el código que guarde la línea anterior en el fichero)

            Console.WriteLine($"guardada en fichero la línea: {FormatoSalidaFichero}");
        }
    }
}
