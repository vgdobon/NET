using esqueletoProgramaCRUDconBD.B_DTOs;
using esqueletoProgramaCRUDconBD.D_Data;
using System;
using System.Linq;

namespace esqueletoProgramaCRUDconBD.C_Services.DataBase
{
    public static class DataBaseTrabajadoresService
    {
        public static GestionTrabajadoresCeste2021Entities DbAccess { get; set; } = new GestionTrabajadoresCeste2021Entities();

        public static void CargarLista()
        {
            DataBaseJefesEquipoService.CargarListaDesdeBD(DbAccess);
            DataBaseTecnicosService.CargarListaDesdeBD(DbAccess);
        }

        public static void DarDeBaja(TrabajadorDTO tDTO)
        {
            Trabajadores tDB = BuscarPorId(tDTO.Id);
            tDB.FechaBaja = DateTime.Now;
            DbAccess.SaveChanges();
            tDTO.FechaBaja = tDB.FechaBaja;
        }

        public static Trabajadores BuscarPorId(int id)
        {
            return DbAccess.Trabajadores.FirstOrDefault(x => x.Id == id);
        }
    }
}
