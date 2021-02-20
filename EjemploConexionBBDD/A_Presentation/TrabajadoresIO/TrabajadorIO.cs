using esqueletoProgramaCRUDconBD.B_DTOs;
using esqueletoProgramaCRUDconBD.C_Services.DTOList;
using System;

namespace esqueletoProgramaCRUDconBD.A_Presentation.TrabajadoresIO
{
    public static class TrabajadorIO
    {
        public static TrabajadorDTO GetInfoFromUser(TrabajadorDTO t)
        {
            t.Dni = UtilesPresentation.GetStringFromUser("DNI");
            t.Nombre = UtilesPresentation.GetStringFromUser("Nombre");
            t.Apellidos = UtilesPresentation.GetStringFromUser("Apellidos");
            t.FechaNacimiento = UtilesPresentation.GetDateFromUser("Fecha de nacimiento") ?? new DateTime();
            t.Direccion = UtilesPresentation.GetStringFromUser("Dirección");

            return t;
        }

        public static void ShowModifiableFieldsMenu()
        {
            Console.WriteLine("1 - DNI");
            Console.WriteLine("2 - Nombre");
            Console.WriteLine("3 - Apellidos");
            Console.WriteLine("4 - Fecha de nacimiento");
            Console.WriteLine("5 - Dirección");
        }

        public static void ModifySelectedField(TrabajadorDTO t, string option)
        {
            switch (option)
            {
                case "1":
                    t.Dni = UtilesPresentation.GetStringFromUser("nuevo DNI");
                    break;
                case "2":
                    t.Nombre = UtilesPresentation.GetStringFromUser("nuevo nombre");
                    break;
                case "3":
                    t.Apellidos = UtilesPresentation.GetStringFromUser("nuevos apellidos");
                    break;
                case "4":
                    t.FechaNacimiento = UtilesPresentation.GetDateFromUser("nueva fecha de nacimiento") ?? new DateTime();
                    break;
                case "5":
                    t.Direccion = UtilesPresentation.GetStringFromUser("nueva dirección");
                    break;
                default:
                    break;
            }
        }

        public static void ShowDetails(TrabajadorDTO t)
        {
            Console.WriteLine($"Id: {t.Id}");
            Console.WriteLine($"Nombre: {t.Nombre} {t.Apellidos}");
            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime yearsFromZeroTime = zeroTime + (DateTime.Now - t.FechaNacimiento);
            Console.WriteLine($"Fecha de nacimiento: {t.FechaNacimiento:dd-MM-yyyy} ({yearsFromZeroTime.Year-1} años)");
            Console.WriteLine($"Dirección: {t.Direccion}");
        }

        public static void GetTrabajadorByIdToEndContract()
        {
            TrabajadorDTO tADarDeBaja = GetTrabajadorByIdEnteredByUser();
            ListaTrabajadoresService.DarDeBajaTrabajador(tADarDeBaja);
        }

        public static TrabajadorDTO GetTrabajadorByIdEnteredByUser()
        {
            int tId = GetTrabajadorIdEnteredByUser();
            return ListaTrabajadoresService.ObtenerTrabajadorPorId(tId);
        }

        public static int GetTrabajadorIdEnteredByUser()
        {
            foreach (TrabajadorDTO t in ListaTrabajadoresService.GetList())
            {
                Console.WriteLine($"Id: {t.Id}, Nombre: {t.Nombre} {t.Apellidos}");
            }
            return UtilesPresentation.GetIntFromUser("Seleccione Id del trabajador") ?? 0;
        }
    }
}
