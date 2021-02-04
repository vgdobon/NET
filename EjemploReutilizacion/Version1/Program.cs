using System;
using Version1.ClasesPersona;

namespace Version1
{
    class Program
    {
        /// <summary>
        /// esta versión separa la definición de los datos de entrada y las operaciones a realizar con ellos
        /// Además, añade a las clases Trabajador y Desempleado sus propios métodos para mostrar su información por pantalla
        /// </summary>
        static void Main(string[] args)
        {
            // Enunciado: crear dos personas (un trabajador y un desempleado), y mostrarlas por pantalla, primero en un orden, luego en el contrario
            #region crear trabajador y desempleado (inicializadas con sintaxis corta)
            Trabajador t = new Trabajador() { Nombre = "Eustaquio", Apellidos = "Jean", EsHombre = true, Sueldo = 1000 };
            // para Josefina no es necesario inicializar su atributo EsHombre, porque por defecto vale false,
            // que es el valor correspondiente para una mujer. Eso sí, si se desea, se puede inicializar a false explícitamente
            Desempleado d = new Desempleado() { Nombre = "Josefina", Apellidos = "Habichuela", Subsidio = 500 };
            #endregion

            Operaciones op = new Operaciones();
            // en un orden
            op.MostrarTrabajadorYDesempleadoEnPantalla(t, d);
            Console.WriteLine();
            // en el orden contrario
            op.MostrarDesempleadoYTrabajadorEnPantalla(d, t);

            Console.ReadKey();
        }
    }
}
