using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommonGestionTrabajadoresMVC.DTOs
{
    public class TrabDepTecnicoDTO : TrabajadorDTO
    {
        [Display(Name = "Experiencia")]
        public int AnyosExp { get; set; }
        [Display(Name = "Coding Skills")]
        public List<TipoTecnologiaDTO> ListaTecnologias { get; set; } = new List<TipoTecnologiaDTO>();
        [Display(Name = "Proyectos")]
        public List<ProyectoDTO> ListaProyectos { get; set; }
        public List<int> IdTecnologias { get; set; } = new List<int>();
    }
}