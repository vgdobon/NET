using System;
using Version4.ClasesColeccion;
using Version4.ClasesPersona;

namespace Version4
{
    class Program
    {
        /// <summary>
        /// Est versión añade a la anterior la abstracción del tipo de colección (List, Array, u otros) que se va a utilizar para coleccionar personas
        /// Además, plantea distintas salidas para los datos: pantalla y fichero, cada una de ellas en un método diferente
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region tipos de persona (inicializadas con sintaxis corta)
            Trabajador t = new Trabajador() { Nombre = "Eustaquio", Apellidos = "Jean", EsHombre = true, Sueldo = 1000 };
            // para Josefina no es necesario inicializar su atributo EsHombre, porque por defecto vale false,
            // que es el valor correspondiente para una mujer. Eso sí, si se desea, se puede inicializar a false explícitamente
            Desempleado d = new Desempleado() { Nombre = "Josefina", Apellidos = "Habichuela", Subsidio = 500 };
            #endregion

            Operaciones op = new Operaciones();

            // mostrar lista en pantalla
            ListaPersonas lp = new ListaPersonas();
            op.CrearColeccionConDosPersonasExistentesYMostrarlaEnPantalla(t, d, lp);

            Console.WriteLine();

            // mostrar array en pantalla
            ArrayPersonas ap = new ArrayPersonas();
            op.CrearColeccionConDosPersonasExistentesYMostrarlaEnPantalla(t, d, ap);

            Console.WriteLine();

            // guardar lista en fichero
            lp = new ListaPersonas();
            op.CrearColeccionConDosPersonasExistentesYGuardarlaEnFichero(t, d, lp);

            Console.WriteLine();

            // guardar array en fichero
            ap = new ArrayPersonas();
            op.CrearColeccionConDosPersonasExistentesYGuardarlaEnFichero(t, d, ap);

            Console.ReadKey();
        }
    }
}
