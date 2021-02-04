using System;
using Version2.ClasesPersona;

namespace Version2
{
    class Program
    {
        /// <summary>
        /// esta versión añade a la anterior la abstracción de los tipos de persona (Trabajador, Desempleado, u otros) que se vayan a mostrar por pantalla
        /// Hay herencia, pero no hay polimorfismo (la clase Trabajador no declara métodos abstractos que deban implementar Trabajador y Desempleado)
        /// </summary>
        static void Main(string[] args)
        {
            // Enunciado: crear dos personas (un trabajador y un desempleado), y mostrarlas por pantalla, primero en un orden, luego en el contrario
            #region tipos de persona (inicializadas con sintaxis corta)
            Trabajador t = new Trabajador() { Nombre = "Eustaquio", Apellidos = "Jean", EsHombre = true, Sueldo = 1000 };
            // para Josefina no es necesario inicializar su atributo EsHombre, porque por defecto vale false,
            // que es el valor correspondiente para una mujer. Eso sí, si se desea, se puede inicializar a false explícitamente
            Desempleado d = new Desempleado() { Nombre = "Josefina", Apellidos = "Habichuela", Subsidio = 500 };
            #endregion

            Operaciones op = new Operaciones();
            // en un orden
            op.MostrarDosPersonasEnPantalla(t, d);
            Console.WriteLine();
            // en el orden contrario
            op.MostrarDosPersonasEnPantalla(d, t);

            Console.ReadKey();
        }
    }
}
