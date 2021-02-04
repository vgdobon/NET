using Version4.ClasesPersona;

namespace Version4.ClasesColeccion
{
    abstract class ColeccionPersonas
    {
        public abstract void Annadir(Persona p);
        public abstract void MostrarTodosLosElementosEnPantalla();
        public abstract void GuardarTodosLosElementosEnFichero();
    }
}
