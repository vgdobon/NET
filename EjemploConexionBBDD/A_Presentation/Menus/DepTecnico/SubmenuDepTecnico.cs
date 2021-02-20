using System;

namespace esqueletoProgramaCRUDconBD.A_Presentation.Menus.DepTecnico
{
    public class SubmenuDepTecnico: MenuGenerico
    {
        #region declarar propiedades de las clases que ejecutarán los submenús directos de este menú (si los hay)
        Submenu2JefesEquipo MenuJefesEquipo { get; set; }
        Submenu2Tecnicos MenuTecnicos { get; set; }
        #endregion

        public SubmenuDepTecnico()
        {
            MenuJefesEquipo = new Submenu2JefesEquipo();
            MenuTecnicos = new Submenu2Tecnicos();
        }

        public override void ShowMenu()
        {
            Console.WriteLine("1 - Gestionar jefes de equipo");
            Console.WriteLine("2 - Gestionar técnicos");
            Console.WriteLine("3 - Volver al menú principal");
        }

        public override void ManageSelectedOption()
        {
            switch (Option)
            {
                case "1":
                    MenuJefesEquipo.Execute();
                    break;
                case "2":
                    MenuTecnicos.Execute();
                    break;
                case "3":
                    Finish = true;
                    break;
                default:
                    EnteredWrongOption();
                    break;
            }
        }
    }
}
