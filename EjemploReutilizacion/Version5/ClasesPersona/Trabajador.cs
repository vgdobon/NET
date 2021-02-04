using System;

namespace Version5.ClasesPersona
{
    class Trabajador: Persona
    {
        public decimal Sueldo { get; set; }

        public Trabajador()
        {
            TEXTO_HOMBRE = "el trabajador";
            TEXTO_MUJER = "la trabajadora";
            TEXTO_INGRESO = "un sueldo";
        }

        public override decimal ObtenerIngreso()
        {
            return Sueldo;
        }

        public override void RellenarCamposDesdePantalla()
        {
            Console.WriteLine("Nuevo Trabajador");
            Console.WriteLine("----------------");
            Console.Write("Nombre: ");
            Nombre = Console.ReadLine();
            Console.Write("¿Es un nombre masculino? (s/n): ");
            EsHombre = (Console.ReadLine().ToLower() == "s");
            Console.Write("Apellidos: ");
            Apellidos = Console.ReadLine();
            Console.Write("Sueldo: ");
            string str_Sueldo = Console.ReadLine();

            decimal posibleSueldo;
            bool str_Sueldo_isDecimal = decimal.TryParse(str_Sueldo, out posibleSueldo);
            // para no perder mucho tiempo, voy a plantear una sola oportunidad de introducir el sueldo correctamente
            // si no se mete un sueldo válido a la primera, se asignará un sueldo de -1
            if (str_Sueldo_isDecimal == false)
            {
                Sueldo = -1; // un sueldo negativo no es real. Al verlo por pantalla será un indicador de error
            }
            else
            {
                Sueldo = posibleSueldo;
            }
            Console.WriteLine("----------------");
            Console.WriteLine();
        }

        public override void RellenarCamposDesdeFichero()
        {
            // mientras no lleguemos a ver los ficheros, simulamos que leemos una línea del fichero con el siguiente valor:
            string lineaDePruebaConFormatoDeFichero = "Trabajador|pepe|yes|porras|1000";

            // parseamos la línea anterior para extraeer los distintos campos del trabajador
            string[] elementosLeidosDeLineaDeFichero = lineaDePruebaConFormatoDeFichero.Split('|');
            Nombre = elementosLeidosDeLineaDeFichero[1];
            if (elementosLeidosDeLineaDeFichero[2] == "yes")
            {
                EsHombre = true;
            }
            else
            {
                EsHombre = false;
            }
            //EsHombre = elementosLeidosDeLineaDeFichero[2] == "yes";
            Apellidos = elementosLeidosDeLineaDeFichero[3];
            Sueldo = decimal.Parse(elementosLeidosDeLineaDeFichero[4]);
        }
    }
}
