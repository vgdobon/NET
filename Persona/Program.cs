using System;
using System.Collections.Generic;



namespace Herencia
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Trabajador> plantilla = new List<Trabajador>();


            int opcion = 0;

            do
            {

                Console.WriteLine("Registrando nuevo empleado");
                Console.WriteLine("1 - Registrar nuevo empleado");
                Console.WriteLine("2 - Consultar datos de los empleados");
                Console.WriteLine("3 - Salir");

                bool opcionIsInt = int.TryParse(Console.ReadLine(), out opcion);


                if (opcionIsInt)
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Datos de nuevo trabajador");

                            Console.Write("DNI");
                            string dni = Console.ReadLine();

                            Console.Write("Nombre");
                            string nombre = Console.ReadLine();

                            Console.Write("Apellidos:");
                            string apellidos = Console.ReadLine();

                            Console.Write("Fecha de Contratación:");

                            Console.Write("Año");
                            int.TryParse(Console.ReadLine(), out int year);
                            Console.Write("Mes");
                            int.TryParse(Console.ReadLine(), out int month);
                            Console.Write("Dia");
                            int.TryParse(Console.ReadLine(), out int day);

                            DateTime date1 = new DateTime(year, month, day);

                            Console.Write("Salario");
                            int.TryParse(Console.ReadLine(), out int salario);

                            Trabajador trabajadorNuevo = new Trabajador(dni, nombre, apellidos, salario, date1);

                            plantilla.Add(trabajadorNuevo);

                            break;

                        case 2:

                            foreach (Trabajador trabajador in plantilla)
                            {
                                Console.WriteLine(trabajador);
                            }




                            break;

                        case 3:

                            Console.WriteLine("Saliendo de la aplicación..");

                            break;

                        default:

                            break;
                    }
                }
            } while (opcion != 3);


        }
    }
}
