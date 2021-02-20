using esqueletoProgramaCRUDconBD.A_Presentation.Menus.DepTecnico;
using esqueletoProgramaCRUDconBD.A_Presentation.TrabajadoresIO;
using System;

namespace esqueletoProgramaCRUDconBD.A_Presentation.Menus
{
    public class MenuPrincipal: MenuGenerico
    {
        #region declarar propiedades de las clases que ejecutarán los submenús directos de este menú (si los hay)
        SubmenuDepTecnico MenuDepTecnico { get; set; }
        #endregion

        public MenuPrincipal()
        {
            MenuDepTecnico = new SubmenuDepTecnico();
        }

        public override void ShowMenu()
        {
            Console.WriteLine("1 - Gestionar Dep. Técnico");
            Console.WriteLine("2 - Gestionar Dep. Comercial (en construcción)");
            Console.WriteLine("3 - Gestionar Dep. Dirección (en construcción)");
            Console.WriteLine("4 - Dar de baja trabajador");
            Console.WriteLine("5 - Salir");
        }

        public override void ManageSelectedOption()
        {
            switch (Option)
            {
                case "1":
                    MenuDepTecnico.Execute();
                    break;
                case "2":
                    // (en construcción)
                    break;
                case "3":
                    // (en construcción)
                    break;
                case "4":
                    TrabajadorIO.GetTrabajadorByIdToEndContract();
                    break;
                case "5":
                    Finish = true;
                    break;
                default:
                    EnteredWrongOption();
                    break;
            }
        }
    }
}
