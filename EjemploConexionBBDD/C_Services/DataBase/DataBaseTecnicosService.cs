using esqueletoProgramaCRUDconBD.B_DTOs.DepTecnico;
using esqueletoProgramaCRUDconBD.C_Services.DTOList;
using esqueletoProgramaCRUDconBD.D_Data;
using System.Collections.Generic;

namespace esqueletoProgramaCRUDconBD.C_Services.DataBase
{
    public static class DataBaseTecnicosService
    {
        public static void CargarListaDesdeBD(GestionTrabajadoresCeste2021Entities DbAccess)
        {
            foreach (Tecnicos tecDB in DbAccess.Tecnicos)
            {
                TecnicoDTO tecDTO = MapTecnicoFromDBToDTO(tecDB);
                ListaTrabajadoresService.AnnadirTrabajador(tecDTO);
            }
        }
        public static TecnicoDTO MapTecnicoFromDBToDTO(Tecnicos tecDB)
        {
            TecnicoDTO resul = new TecnicoDTO();

            resul.Id = tecDB.TrabajadoresDTecnico.Trabajadores.Id;
            resul.Dni = tecDB.TrabajadoresDTecnico.Trabajadores.Dni;
            resul.Nombre = tecDB.TrabajadoresDTecnico.Trabajadores.Nombre;
            resul.Apellidos = tecDB.TrabajadoresDTecnico.Trabajadores.Apellidos;
            resul.FechaNacimiento = tecDB.TrabajadoresDTecnico.Trabajadores.FechaNacimiento;
            resul.FechaBaja = tecDB.TrabajadoresDTecnico.Trabajadores.FechaBaja;
            resul.Direccion = tecDB.TrabajadoresDTecnico.Trabajadores.Direccion;
            resul.AnyosExp = tecDB.TrabajadoresDTecnico.AnyosExperiencia;
            resul.Tecnologia = tecDB.TrabajadoresDTecnico.Tecnologia;
            resul.Jefe = ListaJefesEquipoService.FindById(tecDB.Trabajadores.Id);

            return resul;
        }

        public static Tecnicos MapTecnicoFromDTOToDB(TecnicoDTO tecDTO)
        {
            Tecnicos resul = new Tecnicos();

            resul.TrabajadoresDTecnico.Trabajadores.Dni = tecDTO.Dni;
            resul.TrabajadoresDTecnico.Trabajadores.Nombre = tecDTO.Nombre;
            resul.TrabajadoresDTecnico.Trabajadores.Apellidos = tecDTO.Apellidos;
            resul.TrabajadoresDTecnico.Trabajadores.FechaNacimiento = tecDTO.FechaNacimiento;
            resul.TrabajadoresDTecnico.Trabajadores.Direccion = tecDTO.Direccion;
            resul.TrabajadoresDTecnico.AnyosExperiencia = tecDTO.AnyosExp;
            resul.TrabajadoresDTecnico.Tecnologia = tecDTO.Tecnologia;
            resul.JefeEquipoId = tecDTO.Jefe.Id;

            return resul;
        }

        public static int Annadir(TecnicoDTO tecDTO)
        {
            Tecnicos tecDB = MapTecnicoFromDTOToDB(tecDTO);
            DataBaseTrabajadoresService.DbAccess.Tecnicos.Add(tecDB);
            DataBaseTrabajadoresService.DbAccess.SaveChanges();

            return tecDB.TrabajadoresDTecnico.Trabajadores.Id;
        }
    }
}
