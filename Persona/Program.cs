using System;
using System.Collections.Generic;

namespace Herencia
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Trabajador> plantilla = new List<Trabajador>();
            
            Console.WriteLine("Registrando nuevo empleado");

            bool opcionIsInt = int.TryParse(Console.ReadLine(), out int opcion);

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
                        int.TryParse(Console.ReadLine(),out int year);
                        Console.Write("Mes");
                        int.TryParse(Console.ReadLine(), out int month);
                        Console.Write("Dia");
                        int.TryParse(Console.ReadLine(), out int day);

                        DateTime date1 = new DateTime(year, month, day);

                        Console.Write("Salario");
                        int.TryParse(Console.ReadLine(),out int salario);

                        Trabajador andres = new Trabajador(dni, nombre, apellidos, salario, date1);


                        break;

                    case 2:
                        
                        foreach(Trabajador trabajador in plantilla)
                        {
                            Console.WriteLine(trabajador);
                        }




                        break;

                    case 3:

                        break;

                    default:

                        break;
                }
            }
        }
    }
}
