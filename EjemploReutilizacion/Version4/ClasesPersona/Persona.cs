namespace Version4.ClasesPersona
{
    abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public bool EsHombre { get; set; }

        public abstract void MostrarDetalles();
        public abstract void GuardarEnFichero();
    }
}
