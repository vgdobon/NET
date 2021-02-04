using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    public class Leer
    {

        public void Ejecutar()
        {

            // LEER DE UN ARCHIVO
            string archivo = @"../../Files/Datos.txt";
            //codigo para acceder al archivo
            if (File.Exists(archivo))
            {
                Console.WriteLine("El archivo exites");
                StreamReader cursor = new StreamReader(archivo);
                int numLineasLeidas = 0;
                string lineaActual;
                bool finFichero = false;


                do
                {
                    lineaActual = cursor.ReadLine();
                    if (lineaActual == null)
                    {
                        finFichero = true;
                    }
                    else
                    {
                        Console.WriteLine(lineaActual);
                        numLineasLeidas++;
                    }

                } while (!finFichero);

                Console.WriteLine($"El fichero tiene {numLineasLeidas} lineas." );

                //Peek lee el siguiente carácterer pero no lo consume
                cursor.Peek();

                //Read lee el siguiente carácter y coloca el cursor al final del caracter leido
                cursor.Read();
                cursor.Read();
                cursor.Read();
                cursor.Read();
                cursor.Read();

                char[] caracteresLeidos = new char[1000];
                cursor.Read(caracteresLeidos,0,100);

                cursor.Close();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Archivo no encontrado");
                Console.ReadKey();

            }


        }
    }
}
