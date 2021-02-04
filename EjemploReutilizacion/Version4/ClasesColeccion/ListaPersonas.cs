using System.Collections.Generic;
using Version4.ClasesPersona;

namespace Version4.ClasesColeccion
{
    class ListaPersonas : ColeccionPersonas
    {
        public List<Persona> lp { get; set; }

        public ListaPersonas()
        {
            lp = new List<Persona>();
        }

        public override void Annadir(Persona p)
        {
            lp.Add(p);
        }

        public override void MostrarTodosLosElementosEnPantalla()
        {
            // - no sabemos de qué tipo es cada persona de la lista, pero al aplicar polimorfismo con el método MostrarDetalles(),
            //   declarado como abstracto en Persona y sobreescrito en Trabajador y Desempleado, NO HACE FALTA saber los tipos.
            // - Como desde este método no sabemos cuántos elementos va a tener la lista, añadimos el código que recorre una lista
            foreach (Persona p in lp)
            {
                p.MostrarDetalles();
            }
        }

        public override void GuardarTodosLosElementosEnFichero()
        {
            // - no sabemos de qué tipo es cada persona de la lista, pero al aplicar polimorfismo con el método MostrarDetalles(),
            //   declarado como abstracto en Persona y sobreescrito en Trabajador y Desempleado, NO HACE FALTA saber los tipos.
            // - Como desde este método no sabemos cuántos elementos va a tener la lista, añadimos el código que recorre una lista
            foreach (Persona p in lp)
            {
                p.GuardarEnFichero();
            }
        }
    }
}
