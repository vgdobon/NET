using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestiónEmpleados.data;
using GestiónEmpleados.Presentation;

//Programa 17: Gestión de trabajadores


//Al cargar la aplicación, mostrará un menú con las siguientes opciones:

//1 - Alta de jefes de equipo.
//2-Alta de técnicos (comprobar que el responsable existe)
//3 - Alta de jefes de ventas.
//4-Alta de Comerciales (comprobar que el responsable existe).
//5 - Alta de personas de dpto. de dirección.
//6-Mostrar todos los técnicos.
//7-Mostrar los técnicos según responsable.
//8-Mostrar los comerciales según responsable.
//9-Mostrar jefes de equipo según tecnología.
//10-Mostrar Dpto. Dirección.
//11- Baja de personal
//12- Salir



namespace GestiónEmpleados
{
    class Program
    {
        static void Main(string[] args)
        {

            trabajadoresModelEntities Tdb = new trabajadoresModelEntities();
            List<TrabajoresDT> listaTrabajadores = Tdb.TrabajoresDT.ToList();
            Console.WriteLine("Trabajadores:");

            foreach (var VARIABLE in listaTrabajadores)
            {
                Console.WriteLine(VARIABLE);

            }

            Console.ReadKey();

            MenuGestion menu = new MenuGestion();
            menu.EjecutarApp();
        }
    }
}
