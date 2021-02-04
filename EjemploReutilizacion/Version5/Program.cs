using System;
using Version5.ClasesColeccion;
using Version5.ClasesPersona;
using Version5.ClasesSalida;

namespace Version5
{
    class Program
    {
        /// <summary>
        /// Esta versión añade a la anterior la abstracción del tipo de salida (pantalla, fichero, u otros) a la que se van a enviar las personas de la colección
        /// Además, plantea distintas entradas para los datos: pantalla y fichero, cada una de ellas en un método diferente
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

            PersonaAPantalla pap = new PersonaAPantalla();
            PersonaAFichero paf = new PersonaAFichero();
            
            // mostrar lista en pantalla
            ListaPersonas lp = new ListaPersonas();
            op.CrearColeccionConDosPersonasExistentesYMostrarlaEnSalida(t, d, lp, pap);

            Console.WriteLine();

            // mostrar array en pantalla
            ArrayPersonas ap = new ArrayPersonas();
            op.CrearColeccionConDosPersonasExistentesYMostrarlaEnSalida(t, d, ap, pap);

            Console.WriteLine();

            // guardar lista en fichero
            lp = new ListaPersonas();
            op.CrearColeccionConDosPersonasExistentesYMostrarlaEnSalida(t, d, lp, paf);

            Console.WriteLine();

            // guardar array en fichero
            ap = new ArrayPersonas();
            op.CrearColeccionConDosPersonasExistentesYMostrarlaEnSalida(t, d, ap, paf);

            Console.WriteLine();

            // mostrar lista en pantalla, obteniendo las dos personas desde pantalla
            lp = new ListaPersonas();
            op.CrearColeccionConDosPersonasDesdePantallaYMostrarlaEnSalida(new Trabajador(), new Desempleado(), lp, pap);

            Console.WriteLine();

            // mostrar lista en pantalla, obteniendo las dos personas desde fichero
            lp = new ListaPersonas();
            op.CrearColeccionConDosPersonasDesdeFicheroYMostrarlaEnSalida(new Trabajador(), new Desempleado(), lp, pap);

            Console.ReadKey();
        }
    }
}
