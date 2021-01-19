using System;
using System.Collections.Generic;
using System.Threading;
using Biblioteca = biblioteca.Services.Biblioteca;


namespace biblioteca.Presentation
{
    public class Menu
    {
        public Services.Biblioteca biblioteca= new Services.Biblioteca();

        public void MostrarMenu()
        {

            Console.WriteLine("1 - Añadir nuevo libro \n" +
                              "2 - Alquilar libro\n" +
                              "3 - Buscar libro\n" +
                              "4 - Mostrar listado de todos los libros de un determinado género\n" +
                              "5 - Mostrar listado de libros alquilados\n" +
                              "6 - Mostrar listado de libros disponibles (no alquilados)\n" +
                              "7 - Devolver un libro\n" +
                              "8 - Salir");
        }

        public int ElegirOpcion()
        {
            Console.Write("Elija una opcion:");
            bool optionIsInt = int.TryParse(Console.ReadLine(), out int option);

            return optionIsInt ? option : -1;

        }

        public void EjecutarOpcion(int opcion)
        {
            if(opcion>0 && opcion < 9)
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Titulo:");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Autor:");
                        string autor = Console.ReadLine();
                        Console.WriteLine("Año:");
                        string anno = Console.ReadLine();
                        Console.WriteLine("Categoría:");
                        string categoria = Console.ReadLine();

                        bool inserccionEjecutada = biblioteca.annadirLibro(titulo, autor, anno, categoria);

                        if (inserccionEjecutada)
                        {
                            Console.WriteLine("Libro añadido correctamente.Volviendo al menu..");
                            Thread.Sleep(2000);
                            Console.Clear();
                        } else {

                            Console.WriteLine("Error en la insercción del nuevo libro. Inténtelo de nuevo.Volviendo al menu..");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }

                        break;
                    case 2:
                        Console.WriteLine("Alquilar libro");
                        break;
                    case 3:
                        Console.WriteLine("Buscar libro");
                        break;
                    case 4:
                        Console.WriteLine("Mostrar listado de todos los libros de un determinado género");
                        break;
                    case 5:
                        Console.WriteLine("Mostrar listado de libros alquilados");
                        break;
                    case 6:
                        Console.WriteLine("Mostrar listado de libros disponibles (no alquilados)");
                        break;
                    case 7:
                        Console.WriteLine("Devolver un libro");
                        break;
                    case 8:
                        Console.WriteLine("Salir");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No ha elegido una opción correcta. Debe escribir un numero entre 1 y 8.Ej:4");
            }
        }

        internal void ejecutarApp()
        {
            int opcionUsuario = 0;
            do
            {
                MostrarMenu();
                opcionUsuario = ElegirOpcion();

                if (opcionUsuario > 0 && opcionUsuario < 9)
                {

                    EjecutarOpcion(opcionUsuario);
                }
                else
                {

                    Console.WriteLine("No has elegido una opción correcta");
                }
            } while (opcionUsuario != 8);

            Console.WriteLine("Cerrando Applicacion de Biblioteca");
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }



        }

        
    }
}
