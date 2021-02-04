using System;
using System.Runtime.Remoting.Services;
using Version5.ClasesPersona;

namespace Version5.ClasesSalida
{
    class PersonaAFichero : PersonaASalida
    {
        public override void SacarElemento(Persona p)
        {
            string strEsHombre = "no";
            if(p.EsHombre == true)
            {
                strEsHombre = "yes";
            }
            string FormatoSalidaFichero = $"{p.GetType().Name}|{p.Nombre}|{strEsHombre}|{p.Apellidos}|{p.ObtenerIngreso()}";

            // (aquí estará el código que guarde la línea anterior en el fichero)

            Console.WriteLine($"guardada en fichero la línea: {FormatoSalidaFichero}");
        }
    }
}
