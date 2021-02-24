using System;
using System.ComponentModel.DataAnnotations;

namespace CommonGestionTrabajadoresMVC.DTOs
{
    public class ProyectoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        [Display(Name = "Fecha limite")]
        public DateTime FechaLimite { get; set; }
    }
}