using System.ComponentModel.DataAnnotations;

namespace CommonGestionTrabajadoresMVC.DTOs
{
    public class TecnicoDTO : TrabDepTecnicoDTO
    {
        public JefeEquipoDTO Jefe { get; set; }
        [Display(Name = "Tarea actual")]
        public string TareaActual { get; set; }
    }
}