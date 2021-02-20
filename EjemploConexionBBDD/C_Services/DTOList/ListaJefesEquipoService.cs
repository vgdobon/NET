using esqueletoProgramaCRUDconBD.B_DTOs.DepTecnico;
using esqueletoProgramaCRUDconBD.C_Services.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace esqueletoProgramaCRUDconBD.C_Services.DTOList
{
    public static class ListaJefesEquipoService
    {
        public static List<JefeEquipoDTO> GetAllItems()
        {
            return ListaTrabajadoresService.GetList().Where(x => x is JefeEquipoDTO && x.FechaBaja == null)
                .Cast<JefeEquipoDTO>().ToList();
        }
        public static List<JefeEquipoDTO> GetItemsFilteredByTecnologia(string tecnologia)
        {
            return ListaTrabajadoresService.GetList().Where(
                x => x is JefeEquipoDTO je && je.FechaBaja == null && je.Tecnologia == tecnologia)
                .Cast<JefeEquipoDTO>().ToList();
        }

        public static JefeEquipoDTO FindById(int id)
        {
            return ListaTrabajadoresService.ObtenerTrabajadorPorId(id) as JefeEquipoDTO;
        }

        public static void Add(JefeEquipoDTO je)
        {
            je.Id = DataBaseJefesEquipoService.Annadir(je);
            ListaTrabajadoresService.AnnadirTrabajador(je);
        }

        public static void Modify(JefeEquipoDTO je)
        {
           DataBaseJefesEquipoService.Modificar(je);
        }

        public static void Remove(JefeEquipoDTO je)
        {
            ListaTrabajadoresService.EliminarTrabajador(je);
        }
    }
}
