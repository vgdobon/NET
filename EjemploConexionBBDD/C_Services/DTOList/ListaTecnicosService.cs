using esqueletoProgramaCRUDconBD.B_DTOs.DepTecnico;
using esqueletoProgramaCRUDconBD.C_Services.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace esqueletoProgramaCRUDconBD.C_Services.DTOList
{
    public static class ListaTecnicosService
    {
        public static List<TecnicoDTO> GetAllItems()
        {
            return ListaTrabajadoresService.GetList().Where(x => x is TecnicoDTO).Cast<TecnicoDTO>().ToList();
        }

        public static List<TecnicoDTO> GetItemsFilteredByJefeEquipoId(int jeId)
        {
            return ListaTrabajadoresService.GetList().Where(x => x is TecnicoDTO tec && tec.Jefe.Id == jeId)
                .Cast<TecnicoDTO>().ToList();
        }

        public static TecnicoDTO FindById(int id)
        {
            return ListaTrabajadoresService.ObtenerTrabajadorPorId(id) as TecnicoDTO;
        }

        public static void Add(TecnicoDTO tec)
        {
            tec.Id = DataBaseTecnicosService.Annadir(tec);
            ListaTrabajadoresService.AnnadirTrabajador(tec);
        }

        public static void Remove(TecnicoDTO tec)
        {
            ListaTrabajadoresService.EliminarTrabajador(tec);
        }
    }
}
