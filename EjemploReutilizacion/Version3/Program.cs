using System;
using Version3.ClasesPersona;

namespace Version3
{
    class Program
    {
        /// <summary>
        /// Esta versión añade a la anterior el uso de polimorfismo en el método MostrarDetalles() de las clases Trabajador y Desempleado
        /// Además, plantea distintos formas de coleccionar personas: List y Array, cada una de ellas en un método diferente
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region tipos de persona (inicializadas con sintaxis corta)
            Trabajador t = new Trabajador() { Nombre = "Eustaquio", Apellidos = "Jean", EsHombre = true, Sueldo = 1000, Edad=45 };
            // para Josefina no es necesario inicializar su atributo EsHombre, porque por defecto vale false,
            // que es el valor correspondiente para una mujer. Eso sí, si se desea, se puede inicializar a false explícitamente
            Desempleado d = new Desempleado() { Nombre = "Josefina", Apellidos = "Habichuela", Subsidio = 500, Edad=34 };
            #endregion

            Operaciones op = new Operaciones();
            op.MostrarDosPersonasEnPantalla(t, d);
            Console.WriteLine();
            op.MostrarDosPersonasEnPantalla(d, t);
            Console.WriteLine();
            op.CrearListaConDosPersonasExistentesYMostrarlaEnPantalla(t, d);
            Console.WriteLine();
            op.CrearArrayConDosPersonasExistentesYMostrarloEnPantalla(t, d);

            Console.ReadKey();
        }
    }
}
