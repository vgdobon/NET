using esqueletoProgramaCRUDconBD.B_DTOs.DepTecnico;
using esqueletoProgramaCRUDconBD.C_Services.DTOList;
using esqueletoProgramaCRUDconBD.D_Data;
using System.Linq;

namespace esqueletoProgramaCRUDconBD.C_Services.DataBase
{
    public static class DataBaseJefesEquipoService
    {
        public static void CargarListaDesdeBD(GestionTrabajadoresCeste2021Entities DbAccess)
        {
            foreach (JefesEquipo jeDB in DbAccess.JefesEquipo)
            {
                JefeEquipoDTO jeDTO = MapJefeEquipoFromDBToDTO(jeDB);
                ListaTrabajadoresService.AnnadirTrabajador(jeDTO);
            }
        }
        public static JefeEquipoDTO MapJefeEquipoFromDBToDTO(JefesEquipo jeDB, JefeEquipoDTO jeDTO = null)
        {
            JefeEquipoDTO resul = jeDTO ?? new JefeEquipoDTO();

            resul.Id = jeDB.TrabajadoresDTecnico.Trabajadores.Id;
            resul.Dni = jeDB.TrabajadoresDTecnico.Trabajadores.Dni;
            resul.Nombre = jeDB.TrabajadoresDTecnico.Trabajadores.Nombre;
            resul.Apellidos = jeDB.TrabajadoresDTecnico.Trabajadores.Apellidos;
            resul.FechaNacimiento = jeDB.TrabajadoresDTecnico.Trabajadores.FechaNacimiento;
            resul.FechaBaja = jeDB.TrabajadoresDTecnico.Trabajadores.FechaBaja;
            resul.Direccion = jeDB.TrabajadoresDTecnico.Trabajadores.Direccion;
            resul.AnyosExp = jeDB.TrabajadoresDTecnico.AnyosExperiencia;
            resul.Tecnologia = jeDB.TrabajadoresDTecnico.Tecnologia;

            return resul;
        }

        public static JefesEquipo MapJefeEquipoFromDTOToDB(JefeEquipoDTO jeDTO, JefesEquipo jeDB = null)
        {
            JefesEquipo resul = jeDB;
            if (jeDB == null)
            {
                resul = new JefesEquipo();
                resul.TrabajadoresDTecnico = new TrabajadoresDTecnico();
                resul.TrabajadoresDTecnico.Trabajadores = new Trabajadores();
            }

            resul.TrabajadoresDTecnico.Trabajadores.Dni = jeDTO.Dni;
            resul.TrabajadoresDTecnico.Trabajadores.Nombre = jeDTO.Nombre;
            resul.TrabajadoresDTecnico.Trabajadores.Apellidos = jeDTO.Apellidos;
            resul.TrabajadoresDTecnico.Trabajadores.FechaNacimiento = jeDTO.FechaNacimiento;
            resul.TrabajadoresDTecnico.Trabajadores.Direccion = jeDTO.Direccion;
            resul.TrabajadoresDTecnico.AnyosExperiencia = jeDTO.AnyosExp;
            resul.TrabajadoresDTecnico.Tecnologia = jeDTO.Tecnologia;

            return resul;
        }

        public static int Annadir(JefeEquipoDTO jeDTO)
        {
            JefesEquipo jeDB = MapJefeEquipoFromDTOToDB(jeDTO);
            DataBaseTrabajadoresService.DbAccess.JefesEquipo.Add(jeDB);
            DataBaseTrabajadoresService.DbAccess.SaveChanges();

            return jeDB.TrabajadoresDTecnico.Trabajadores.Id;
        }

        public static void Modificar(JefeEquipoDTO jeDTO)
        {
            JefesEquipo jeDB = BuscarPorId(jeDTO.Id);
            MapJefeEquipoFromDTOToDB(jeDTO, jeDB);
            DataBaseTrabajadoresService.DbAccess.SaveChanges();
        }

        public static JefesEquipo BuscarPorId(int id)
        {
            return DataBaseTrabajadoresService.DbAccess.JefesEquipo.FirstOrDefault(
                x => x.TrabajadoresDTecnico.Trabajadores.Id == id);
        }
    }
}
