namespace Version3.ClasesPersona
{
    abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public bool EsHombre { get; set; }
        public int Edad { get; set; }

        public abstract void MostrarDetalles();
    }
}
