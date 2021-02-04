using System;
using System.Collections.Generic;
using Version5.ClasesPersona;
using Version5.ClasesSalida;

namespace Version5.ClasesColeccion
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

        public override void SacarTodosLosElementosASalida(PersonaASalida pas)
        {
            // - no sabemos de qué tipo es cada persona de la lista, pero al aplicar polimorfismo con el método SacarElemento(),
            //   declarado como abstracto en PersonaASalida y sobreescrito en PersonaAPantalla y PersonaAFichero, NO HACE FALTA saber los tipos.
            // - Como desde este método no sabemos cuántos elementos va a tener la lista, añadimos el código que recorre una lista
            foreach (Persona p in lp)
            {
                pas.SacarElemento(p);
            }
        }
    }
}
