using esqueletoProgramaCRUDconBD.B_DTOs.DepTecnico;
using esqueletoProgramaCRUDconBD.C_Services.DTOList;
using System;
using System.Collections.Generic;

namespace esqueletoProgramaCRUDconBD.A_Presentation.TrabajadoresIO.DepTecnico
{
    public class TecnicoIO
    {
        public static bool finishChanges { get; set; }

        public static void GetInfoFromUserAndAddToList()
        {
            TecnicoDTO tecAAnnadir = GetInfoFromUser();
            ListaTecnicosService.Add(tecAAnnadir);
        }

        public static TecnicoDTO GetInfoFromUser()
        {
            TecnicoDTO tec = new TecnicoDTO();
            tec = TrabDepTecnicoIO.GetInfoFromUser(tec) as TecnicoDTO;

            return tec;
        }

        public static void GetTecnicoByIdAndLetUserModifyIt()
        {
            TecnicoDTO jeAModificar = GetTecnicoByIdEnteredByUser();
            ModifyTecnico(jeAModificar);
        }

        public static TecnicoDTO GetTecnicoByIdEnteredByUser()
        {
            foreach (TecnicoDTO je in ListaTecnicosService.GetAllItems())
            {
                Console.WriteLine($"Id: {je.Id}, Nombre: {je.Nombre} {je.Apellidos}");
            }
            int jeId = UtilesPresentation.GetIntFromUser("Seleccione Id del técnico") ?? 0;
            return ListaTecnicosService.FindById(jeId);
        }

        public static void ModifyTecnico(TecnicoDTO je)
        {
            finishChanges = false;
            do
            {
                ShowFieldsMenu();
                string option = UtilesPresentation.GetStringFromUser("Seleccione el campo a modificar");
                ModifySelectedField(je, option);
            } while (finishChanges == false);
        }

        public static void ShowFieldsMenu()
        {
            TrabDepTecnicoIO.ShowModifiableFieldsMenu();
            Console.WriteLine("8 - Id del jefe de equipo");
            Console.WriteLine("9 - Dejar de hacer cambios");
        }

        public static void ModifySelectedField(TecnicoDTO tec, string option)
        {
            switch (option)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                    TrabDepTecnicoIO.ModifySelectedField(tec, option);
                    break;
                case "8":
                    tec.Jefe = JefeEquipoIO.GetJefeEquipoByIdEnteredByUser();
                    break;
                case "9":
                    finishChanges = true;
                    break;
                default:
                    break;
            }
        }

        public static void GetTecnicoByIdToRemoveIt()
        {
            TecnicoDTO jeABorrar = GetTecnicoByIdEnteredByUser();
            ListaTecnicosService.Remove(jeABorrar);
        }

        public static void ShowFullList()
        {
            List<TecnicoDTO> listaJe = ListaTecnicosService.GetAllItems();
            ShowDetailsFromList(listaJe);
        }

        public static void FilterByJefeDeEquipo()
        {
            int jeId = JefeEquipoIO.GetJefeEquipoIdEnteredByUser();
            List<TecnicoDTO> listaJe = ListaTecnicosService.GetItemsFilteredByJefeEquipoId(jeId);
            ShowDetailsFromList(listaJe);
        }

        public static void ShowDetailsFromList(List<TecnicoDTO> listaJe)
        {
            foreach (TecnicoDTO je in listaJe)
            {
                Console.WriteLine("-------------------------------------");
                ShowDetails(je);
            }
            Console.WriteLine("-------------------------------------");
        }

        public static void ShowDetailsFromOneTecnico()
        {
            TecnicoDTO jeAMostrar = GetTecnicoByIdEnteredByUser();
            ShowDetails(jeAMostrar);
        }

        public static void ShowDetails(TecnicoDTO je)
        {
            TrabDepTecnicoIO.ShowDetails(je);
        }
    }
}
