using System;
using Version0.ClasesPersona;

namespace Version0
{
    class Program
    {
        /// <summary>
        /// todo el programa en un método: código monolítico
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Enunciado: crear un trabajador y un desempleado y mostrarlos por pantalla
            Trabajador t = new Trabajador();
            t.Nombre = "Eustaquio";
            t.Apellidos = "Jean";
            t.Sueldo = 1000;
            Console.WriteLine($"Soy el trabajador {t.Nombre} {t.Apellidos} y cobro un sueldo de {t.Sueldo}");

            Desempleado d = new Desempleado();
            d.Nombre = "Josefina";
            d.Apellidos = "Habichuela";
            d.Subsidio = 500;
            Console.WriteLine($"Soy la desempleada {d.Nombre} {d.Apellidos} y cobro un subsidio de {d.Subsidio}");

            Console.ReadKey();
        }
    }
}
