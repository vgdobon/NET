using esqueletoProgramaCRUDconBD.B_DTOs.DepTecnico;
using esqueletoProgramaCRUDconBD.C_Services.DTOList;
using System;
using System.Collections.Generic;

namespace esqueletoProgramaCRUDconBD.A_Presentation.TrabajadoresIO.DepTecnico
{
    public static class JefeEquipoIO
    {
        public static bool finishChanges { get; set; }

        public static void GetInfoFromUserAndAddToList()
        {
            JefeEquipoDTO jeAAnnadir = GetInfoFromUser();
            ListaJefesEquipoService.Add(jeAAnnadir);
        }

        public static JefeEquipoDTO GetInfoFromUser()
        {
            JefeEquipoDTO je = new JefeEquipoDTO();
            je = TrabDepTecnicoIO.GetInfoFromUser(je) as JefeEquipoDTO;

            return je;
        }

        public static void GetJefeEquipoByIdAndLetUserModifyIt()
        {
            JefeEquipoDTO jeAModificar = GetJefeEquipoByIdEnteredByUser();
            ModifyJefeEquipo(jeAModificar);
            ListaJefesEquipoService.Modify(jeAModificar);
        }

        public static JefeEquipoDTO GetJefeEquipoByIdEnteredByUser()
        {
            int jeId = GetJefeEquipoIdEnteredByUser();
            return ListaJefesEquipoService.FindById(jeId);
        }

        public static int GetJefeEquipoIdEnteredByUser()
        {
            foreach (JefeEquipoDTO je in ListaJefesEquipoService.GetAllItems())
            {
                Console.WriteLine($"Id: {je.Id}, Nombre: {je.Nombre} {je.Apellidos}");
            }
            return UtilesPresentation.GetIntFromUser("Seleccione Id del jefe de equipo") ?? 0;
        }

        public static void ModifyJefeEquipo(JefeEquipoDTO je)
        {
            finishChanges = false;
            do
            {
                Console.Clear();
                ShowDetails(je);
                ShowFieldsMenu();
                string option = UtilesPresentation.GetStringFromUser("Seleccione el campo a modificar");
                ModifySelectedField(je, option);
            } while (finishChanges == false);
        }

        public static void ShowFieldsMenu()
        {
            TrabDepTecnicoIO.ShowModifiableFieldsMenu();
            Console.WriteLine("8 - Dejar de hacer cambios");
        }

        public static void ModifySelectedField(JefeEquipoDTO je, string option)
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
                    TrabDepTecnicoIO.ModifySelectedField(je, option);
                    break;
                case "8":
                    finishChanges = true;
                    break;
                default:
                    break;
            }
        }

        public static void GetJefeEquipoByIdToRemoveIt()
        {
            JefeEquipoDTO jeABorrar = GetJefeEquipoByIdEnteredByUser();
            ListaJefesEquipoService.Remove(jeABorrar);
        }

        public static void ShowFullList()
        {
            List<JefeEquipoDTO> listaJe = ListaJefesEquipoService.GetAllItems();
            ShowDetailsFromList(listaJe);
        }

        public static void FilterByTecnologia()
        {
            string tecnologia = UtilesPresentation.GetStringFromUser("Seleccione la tecnología por la que filtrar");
            List<JefeEquipoDTO> listaJe = ListaJefesEquipoService.GetItemsFilteredByTecnologia(tecnologia);
            ShowDetailsFromList(listaJe);
        }

        public static void ShowDetailsFromList(List<JefeEquipoDTO> listaJe)
        {
            foreach (JefeEquipoDTO je in listaJe)
            {
                Console.WriteLine("-------------------------------------");
                ShowDetails(je);
            }
            Console.WriteLine("-------------------------------------");
        }

        public static void ShowDetailsFromOneJefeEquipo()
        {
            JefeEquipoDTO jeAMostrar = GetJefeEquipoByIdEnteredByUser();
            ShowDetails(jeAMostrar);
        }

        public static void ShowDetails(JefeEquipoDTO je)
        {
            TrabDepTecnicoIO.ShowDetails(je);
        }
    }
}
