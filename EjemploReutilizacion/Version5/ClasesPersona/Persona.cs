namespace Version5.ClasesPersona
{
    abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public bool EsHombre { get; set; }

        public string TEXTO_HOMBRE { get; set; }
        public string TEXTO_MUJER { get; set; }
        public string TEXTO_INGRESO { get; set; }

        public abstract decimal ObtenerIngreso();
        public abstract void RellenarCamposDesdePantalla();
        public abstract void RellenarCamposDesdeFichero();
    }
}
