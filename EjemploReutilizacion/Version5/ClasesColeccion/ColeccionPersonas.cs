using Version5.ClasesPersona;
using Version5.ClasesSalida;

namespace Version5.ClasesColeccion
{
    abstract class ColeccionPersonas
    {
        public abstract void Annadir(Persona p);
        public abstract void SacarTodosLosElementosASalida(PersonaASalida pas);
    }
}
