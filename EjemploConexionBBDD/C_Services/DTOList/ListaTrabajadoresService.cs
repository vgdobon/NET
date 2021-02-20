using esqueletoProgramaCRUDconBD.B_DTOs;
using esqueletoProgramaCRUDconBD.C_Services.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace esqueletoProgramaCRUDconBD.C_Services.DTOList
{
    public static class ListaTrabajadoresService
    {
        static List<TrabajadorDTO> TrabajadoresDTOList { get; set; } = new List<TrabajadorDTO>();

        public static void CargarListaDesdeBD()
        {
            DataBaseTrabajadoresService.CargarLista();
        }

        public static List<TrabajadorDTO> GetList()
        {
            return TrabajadoresDTOList.Where(x => x.FechaBaja == null).ToList();
        }

        public static void AnnadirTrabajador(TrabajadorDTO t)
        {
            TrabajadoresDTOList.Add(t);
        }

        public static void DarDeBajaTrabajador(TrabajadorDTO t)
        {
            DataBaseTrabajadoresService.DarDeBaja(t);
        }

        public static void EliminarTrabajador(TrabajadorDTO t)
        {
            TrabajadoresDTOList.Remove(t);
        }

        public static TrabajadorDTO ObtenerTrabajadorPorId(int id)
        {
            return TrabajadoresDTOList.FirstOrDefault(x => x.Id == id);
        }
    }
}
