using System.ComponentModel.DataAnnotations;

namespace CommonGestionTrabajadoresMVC.DTOs
{
    public class JefeEquipoDTO : TrabDepTecnicoDTO
    {
        [Display(Name = "Teléfono empresa")]
        public string TfnoEmpresa { get; set; }
    }
}