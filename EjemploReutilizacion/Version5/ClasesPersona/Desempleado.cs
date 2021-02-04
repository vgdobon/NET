using System;

namespace Version5.ClasesPersona
{
    class Desempleado: Persona
    {
        public decimal Subsidio { get; set; }

        public Desempleado()
        {
            TEXTO_HOMBRE = "el desempleado";
            TEXTO_MUJER = "la desempleada";
            TEXTO_INGRESO = "un subsidio";
        }

        public override decimal ObtenerIngreso()
        {
            return Subsidio;
        }

        public override void RellenarCamposDesdePantalla()
        {
            Console.WriteLine("Nuevo Desempleado");
            Console.WriteLine("----------------");
            Console.Write("Nombre: ");
            Nombre = Console.ReadLine();
            Console.Write("¿Es un nombre masculino? (s/n): ");
            EsHombre = (Console.ReadLine().ToLower() == "s");
            Console.Write("Apellidos: ");
            Apellidos = Console.ReadLine();
            Console.Write("Subsidio: ");
            string str_Subsidio = Console.ReadLine();

            decimal posibleSubsidio;
            bool str_Subsidio_isDecimal = decimal.TryParse(str_Subsidio, out posibleSubsidio);
            // para no perder mucho tiempo, voy a plantear una sola oportunidad de introducir el subsidio correctamente
            // si no se mete un subsidio válido a la primera, se asignará un subsidio de -1
            if (str_Subsidio_isDecimal == false)
            {
                Subsidio = -1; // un subsidio negativo no es real. Al verlo por pantalla será un indicador de error
            }
            else
            {
                Subsidio = posibleSubsidio;
            }
            Console.WriteLine("----------------");
            Console.WriteLine();
        }

        public override void RellenarCamposDesdeFichero()
        {
            // mientras no lleguemos a ver los ficheros, simulamos que leemos una línea del fichero con el siguiente valor:
            string lineaDePruebaConFormatoDeFichero = "Desempleado|mercedes|no|campo|1000";

            // parseamos la línea anterior para extraeer los distintos campos del trabajador
            string[] elementosLeidosDeLineaDeFichero = lineaDePruebaConFormatoDeFichero.Split('|');
            Nombre = elementosLeidosDeLineaDeFichero[1];
            EsHombre = (elementosLeidosDeLineaDeFichero[2] == "yes");
            Apellidos = elementosLeidosDeLineaDeFichero[3];
            Subsidio = decimal.Parse(elementosLeidosDeLineaDeFichero[4]);
        }
    }
}
