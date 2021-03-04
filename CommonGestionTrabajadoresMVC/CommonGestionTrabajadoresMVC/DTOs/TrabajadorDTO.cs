using System;
using System.ComponentModel.DataAnnotations;

namespace CommonGestionTrabajadoresMVC.DTOs
{
    public class TrabajadorDTO
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe introducir un dni")]
        public string Dni { get; set; }
        [Required(ErrorMessage = "Debe introducir un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe introducir un apellidos")]
        public string Apellidos { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Debe introducir una fecha de nacimiento")]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        public string FechaNacimiendoDisplay { get { return $"{FechaNacimiento:dd/MM/yyyy}"; } }

        [Required(ErrorMessage = "Debe introducir una direccion")]
        public string Direccion { get; set; }
        [Display(Name = "Fecha de baja")]
        public DateTime? FechaBaja { get; set; }

      
    }
}