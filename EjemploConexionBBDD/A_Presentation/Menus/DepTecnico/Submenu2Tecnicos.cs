using esqueletoProgramaCRUDconBD.A_Presentation.TrabajadoresIO.DepTecnico;
using System;

namespace esqueletoProgramaCRUDconBD.A_Presentation.Menus.DepTecnico
{
    class Submenu2Tecnicos : MenuGenerico
    {
        #region declarar propiedades de las clases que ejecutarán los submenús directos de este menú (si los hay)
        // no hay submenús
        #endregion

        public override void ShowMenu()
        {
            Console.WriteLine("1 - Añadir técnico");
            Console.WriteLine("2 - Modificar técnico");
            Console.WriteLine("3 - Borrar técnico");
            Console.WriteLine("4 - Ver listado de técnicos");
            Console.WriteLine("5 - Filtrar técnicos por jefe de equipo");
            Console.WriteLine("6 - Ver datos de un técnico");
            Console.WriteLine("7 - Volver a menú Departamento Técnico");
        }

        public override void ManageSelectedOption()
        {
            switch (Option)
            {
                case "1":
                    TecnicoIO.GetInfoFromUserAndAddToList();
                    break;
                case "2":
                    TecnicoIO.GetTecnicoByIdAndLetUserModifyIt();
                    break;
                case "3":
                    TecnicoIO.GetTecnicoByIdToRemoveIt();
                    break;
                case "4":
                    TecnicoIO.ShowFullList();
                    break;
                case "5":
                    TecnicoIO.FilterByJefeDeEquipo();
                    break;
                case "6":
                    TecnicoIO.ShowDetailsFromOneTecnico();
                    break;
                case "7":
                    Finish = true;
                    break;
                default:
                    EnteredWrongOption();
                    break;
            }
        }
    }
}
