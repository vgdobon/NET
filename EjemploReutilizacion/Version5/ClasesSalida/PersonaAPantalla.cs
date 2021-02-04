using System;
using Version5.ClasesPersona;

namespace Version5.ClasesSalida
{
    class PersonaAPantalla : PersonaASalida
    {
        public override void SacarElemento(Persona p)
        {
            string textoGenero = p.TEXTO_HOMBRE;
            if (p.EsHombre == false)
            {
                textoGenero = p.TEXTO_MUJER;
            }

            string FormatoSalidaPantalla = $"Soy {textoGenero} {p.Nombre} {p.Apellidos} y cobro {p.TEXTO_INGRESO} de {p.ObtenerIngreso()}";

            Console.WriteLine(FormatoSalidaPantalla);
        }
    }
}
