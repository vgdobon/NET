using esqueletoProgramaCRUDconBD.A_Presentation.TrabajadoresIO.DepTecnico;
using System;

namespace esqueletoProgramaCRUDconBD.A_Presentation.Menus.DepTecnico
{
    class Submenu2JefesEquipo: MenuGenerico
    {
        #region declarar propiedades de las clases que ejecutarán los submenús directos de este menú (si los hay)
        // no hay submenús
        #endregion

        public override void ShowMenu()
        {
            Console.WriteLine("1 - Añadir jefe de equipo");
            Console.WriteLine("2 - Modificar jefe de equipo");
            Console.WriteLine("3 - Borrar jefe de equipo");
            Console.WriteLine("4 - Ver listado de jefes de equipo");
            Console.WriteLine("5 - Filtrar jefes de equipo por tecnología");
            Console.WriteLine("6 - Ver datos de un jefe de equipo");
            Console.WriteLine("7 - Volver a menú Departamento Técnico");
        }

        public override void ManageSelectedOption()
        {
            switch (Option)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                    switch (Option)
                    {
                        case "1":
                            JefeEquipoIO.GetInfoFromUserAndAddToList();
                            break;
                        case "2":
                            JefeEquipoIO.GetJefeEquipoByIdAndLetUserModifyIt();
                            break;
                        case "3":
                            JefeEquipoIO.GetJefeEquipoByIdToRemoveIt();
                            break;
                        case "4":
                            JefeEquipoIO.ShowFullList();
                            break;
                        case "5":
                            JefeEquipoIO.FilterByTecnologia();
                            break;
                        case "6":
                            JefeEquipoIO.ShowDetailsFromOneJefeEquipo();
                            break;
                    }
                    WaitForKeyPressed();
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
