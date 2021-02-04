using System;
using System.Collections.Generic;
using System.Linq;
using Version3.ClasesPersona;

namespace Version3
{
    /// <summary>
    /// En esta versión se hace uso de herencia y de polimorfismo
    /// </summary>
    class Operaciones
    {
        public void MostrarDosPersonasEnPantalla(Persona p1, Persona p2)
        {
            p1.MostrarDetalles();
            p2.MostrarDetalles();
        }

        // ejemplo con lista
        public void CrearListaConDosPersonasExistentesYMostrarlaEnPantalla(Persona p1, Persona p2)
        {
            #region crear lista de personas y añadir las dos personas pasadas por parámetro
            List<Persona> lp = new List<Persona>();
            // Es necesario que haya herencia entre Trabajador y Persona, y entre Desempleado y Persona,
            // sino sería imposible añadir un Trabajador a una lista de Persona o un Desempleado a una lista de Persona
            lp.Add(p1);
            lp.Add(p2);
            #endregion

            #region mostrar personas por pantalla
            //lp.Reverse(); // descomentar esta línea si se desea invertir el orden de los elementos de la lista
            // - no sabemos de qué tipo de persona son p1 y p2, pero al aplicar polimorfismo con el método MostrarDetalle(),
            //   declarado como abstracto en Persona y sobreescrito en Trabajador y Desempleado, NO HACE FALTA saber los tipos.
            // - Aunque sabemos que solo son dos elementos, vamos a añadir el código de recorrer la lista para practicarlo y recordarlo,
            //   y de paso para tenerlo a mano si en un futuro tenemos que mostrar una lista de tamaño desconocido
            foreach (Persona p in lp)
            {
                p.MostrarDetalles();
            }
            #endregion
        }

        // ejemplo con array
        public void CrearArrayConDosPersonasExistentesYMostrarloEnPantalla(Persona p1, Persona p2)
        {
            #region crear array de personas y añadir las dos personas pasadas por parámetro
            Persona[] ap = new Persona[2];
            // Es necesario que haya herencia entre Trabajador y Persona, y entre Desempleado y Persona,
            // sino sería imposible añadir un Trabajador a un array de Persona o un Desempleado a un array de Persona
            ap[0] = p1;
            ap[1] = p2;
            #endregion

            #region mostrar personas por pantalla
            // - no sabemos de qué tipo de persona son p1 y p2, pero al aplicar polimorfismo con el método MostrarDetalles(),
            //   declarado como abstracto en Persona y sobreescrito en Trabajador y Desempleado, NO HACE FALTA saber los tipos.
            // - Aunque sabemos que solo son dos elementos, vamos a añadir el código de recorrer el array para practicarlo y recordarlo,
            //   y de paso para tenerlo a mano si en un futuro tenemos que mostrar un array de tamaño desconocido
            for (int i = 0; i <= 1; i++)
            {
                ap[i].MostrarDetalles();
            }
            #endregion
        }
    }
}
