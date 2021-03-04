using System;

namespace CommonGestionTrabajadoresMVC.DTOs
{
    public class TrabajadorDTO
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}