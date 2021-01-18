using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Programa 14: Agenda
//    Realizar una aplicación, la cual al entrar nos indique las siguientes opciones:
//    • 1 - Dar de alta nuevo contacto; 2 - Borrar contacto; 3 - Buscar teléfono de un contacto; 4 - Mostrar todos
//    los contactos y devolver el número de contactos dados de alta; 5 - Salir.
//    • Opc 1 - Por cada contacto, el programa pedirá Nombre, Apellidos y Nº teléfono. Los contactos se
//    almacenarán en memoria.
//    • Opc 2 – El programa pedirá nombre y apellidos del contacto que queremos eliminar y buscará si existe
//    en la agenda. Si existe, antes de eliminarlo pedirá confirmación por pantalla y solo lo eliminará si el
//usuario confirma su deseo de eliminarlo.
//    • Opc 3 – El programa pedirá nombre y apellidos de un contacto existente y buscará si existe en la
//agenda. Si existe, devolveremos su número de teléfono.
//    • Opc 4 – El programa mostrará todos los contactos ordenados alfabéticamente, y al final mostrará el nº
//    de contactos encontrados.
//    • Opc 5 – El programa se cerrará

namespace Agenda
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("AGENGA TELEFÓNICA");
            int opcion = 0;
            Agenda agenda = new Agenda();

            do
            {
                Console.WriteLine("Elija una opcion (1, 2, 3, 4 o 5");
                Console.WriteLine(" 1 - Dar de alta nuevo contacto \n" +
                                  " 2 - Borrar contacto \n" +
                                  " 3 - Buscar teléfono de un contacto \n" +
                                  " 4 - Mostrar todoslos contactos y devolver el número de contactos dados de alta \n" +
                                  " 5 - Salir.");
                bool OpcionIsInt = int.TryParse(Console.ReadLine(), out opcion);

                if (OpcionIsInt)
                {
                    switch (opcion)
                    {
                        case 1:

                            Console.WriteLine("Registrar nuevo contacto");

                            Console.Write("Nombre:");
                            string nombre = Console.ReadLine();

                            Console.Write("Apellidos:");
                            string apellidos = Console.ReadLine();

                            Console.Write("Numero:");
                            string numero = Console.ReadLine();

                            Contacto nuevo = new Contacto(nombre, apellidos, numero);
                            agenda.ListaContactos.Add(nuevo);

                            break;
                        case 2:

                            Console.WriteLine("Borrar contacto");

                            Console.WriteLine("Nombre:");
                            string nombreDel = Console.ReadLine();

                            Console.Write("Apellidos:");
                            string apellidosDel = Console.ReadLine();

                            Contacto eliminaContacto=new Contacto();

                            foreach (Contacto VARIABLE in agenda.ListaContactos)
                            {
                                if (VARIABLE.Nombre == nombreDel && VARIABLE.Apellidos == apellidosDel)
                                {
                                    eliminaContacto = VARIABLE;
                                }
                            }

                            agenda.ListaContactos.Remove(eliminaContacto);
                            break;

                        case 3:

                            Console.WriteLine("Consulta contacto");

                            Console.Write("Nombre:");
                            string nombreConsulta = Console.ReadLine();

                            Console.Write("Apellidos:");
                            string apellidosConsulta = Console.ReadLine();

                            foreach (var VARIABLE in agenda.ListaContactos)
                            {
                                if(VARIABLE.Nombre==nombreConsulta  && VARIABLE.Apellidos == apellidosConsulta)
                                {
                                    Console.WriteLine(VARIABLE);
                                }
                            }


                            break;

                        case 4:
                            Console.WriteLine("Lista de contactos:");
                            foreach (var VARIABLE in agenda.ListaContactos)
                            {
                                Console.WriteLine(VARIABLE);
                            }
                            break;

                        case 5:
                            Console.Write("Cerrando Agenda");
                            Thread.Sleep(500);
                            Console.Write(".");
                            Thread.Sleep(500);
                            Console.Write(".");
                            Thread.Sleep(500);
                            Console.Write(".");
                            Thread.Sleep(2000);
                            break;

                        default:
                            Console.WriteLine("No ha elegido una opción correcta");
                            opcion = 0;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("No ha elegido una opción correcta");
                    opcion = 0;
                }
                


            } while (opcion!=5);
        }
    }
}
