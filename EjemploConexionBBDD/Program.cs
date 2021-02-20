using esqueletoProgramaCRUDconBD.A_Presentation.Menus;
using esqueletoProgramaCRUDconBD.C_Services.DTOList;
using System;

namespace esqueletoProgramaCRUDconBD
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaTrabajadoresService.CargarListaDesdeBD();

            new MenuPrincipal().Execute();

            Console.WriteLine();
            Console.Write("(Fin del programa. Pulse cualquier tecla para cerrar la consola)");
            Console.ReadKey();
        }
    }
}
