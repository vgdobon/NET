namespace CommonGestionTrabajadoresMVC.DTOs
{
    public class TecnicoDTO : TrabDepTecnicoDTO
    {
        public JefeEquipoDTO Jefe { get; set; }
        public string TareaActual { get; set; }
    }
}