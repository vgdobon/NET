using System.Collections.Generic;

namespace CommonGestionTrabajadoresMVC.DTOs
{
    public class TrabDepTecnicoDTO : TrabajadorDTO
    {
        public int AnyosExp { get; set; }
        public List<TipoTecnologiaDTO> ListaTecnologias { get; set; }
        public List<ProyectoDTO> ListaProyectos { get; set; }
    }
}