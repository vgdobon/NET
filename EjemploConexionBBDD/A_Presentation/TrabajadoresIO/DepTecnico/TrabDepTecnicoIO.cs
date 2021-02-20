using esqueletoProgramaCRUDconBD.B_DTOs;
using esqueletoProgramaCRUDconBD.B_DTOs.DepTecnico;
using System;

namespace esqueletoProgramaCRUDconBD.A_Presentation.TrabajadoresIO.DepTecnico
{
    public static class TrabDepTecnicoIO
    {
        public static TrabDepTecnicoDTO GetInfoFromUser(TrabDepTecnicoDTO tdt)
        {
            tdt = TrabajadorIO.GetInfoFromUser(tdt) as TrabDepTecnicoDTO;
            tdt.AnyosExp = UtilesPresentation.GetIntFromUser("Años de experiencia") ?? 0;
            tdt.Tecnologia = UtilesPresentation.GetStringFromUser("Tecnología en que está especializado");

            return tdt;
        }

        public static void ShowModifiableFieldsMenu()
        {
            TrabajadorIO.ShowModifiableFieldsMenu();
            Console.WriteLine("6 - Años de experiencia");
            Console.WriteLine("7 - Tecnología en que está especializado");
        }

        public static void ModifySelectedField(TrabDepTecnicoDTO tdt, string option)
        {
            switch (option)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                    TrabajadorIO.ModifySelectedField(tdt, option);
                    break;
                case "6":
                    tdt.AnyosExp = UtilesPresentation.GetIntFromUser("nuevos años de experiencia") ?? 0;
                    break;
                case "7":
                    tdt.Tecnologia = UtilesPresentation.GetStringFromUser("nueva tecnología");
                    break;
                default:
                    break;
            }
        }

        public static void ShowDetails(TrabDepTecnicoDTO tdt)
        {
            TrabajadorIO.ShowDetails(tdt);
            Console.WriteLine($"Años de experiencia: {tdt.AnyosExp}");
            Console.WriteLine($"Tecnología en que está especializado: {tdt.Tecnologia}");
        }
    }
}
