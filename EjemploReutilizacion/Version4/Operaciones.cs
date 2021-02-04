using System.Collections.Generic;
using Version4.ClasesColeccion;
using Version4.ClasesPersona;

namespace Version4
{
    /// <summary>
    /// En esta versión se hace uso de herencia y de polimorfismo, y se abstrae el tipo de almacenamiento de las personas (List o Array)
    /// </summary>
    class Operaciones
    {
        // ejemplo para pantalla
        public void CrearColeccionConDosPersonasExistentesYMostrarlaEnPantalla(Persona p1, Persona p2, ColeccionPersonas cp)
        {
            #region añadir las dos personas pasadas por parámetro a la colección pasada por parámetro
            // usando el método Annadir declarado como abstracto en ColeccionPersonas e implementado en ListaPersonas y ArrayPersonas,
            // da igual qué tipo de colección sea, y qué tipos de personas se vayan a añadir a la colección
            cp.Annadir(p1);
            cp.Annadir(p2);
            #endregion

            #region mostrar personas por pantalla
            // usando el método MostrarTodosLosElementosEnPantalla declarado como abstracto en ColeccionPersonas
            // e implementado en ListaPersonas y ArrayPersonas, da igual qué tipo de colección sea
            cp.MostrarTodosLosElementosEnPantalla();
            #endregion
        }

        // ejemplo para fichero
        public void CrearColeccionConDosPersonasExistentesYGuardarlaEnFichero(Persona p1, Persona p2, ColeccionPersonas cp)
        {
            #region añadir las dos personas pasadas por parámetro a la colección pasada por parámetro
            // usando el método Annadir declarado como abstracto en ColeccionPersonas e implementado en ListaPersonas y ArrayPersonas,
            // da igual qué tipo de colección sea, y qué tipos de personas se vayan a añadir a la colección
            cp.Annadir(p1);
            cp.Annadir(p2);
            #endregion

            #region mostrar personas por pantalla
            // usando el método MostrarTodosLosElementosEnPantalla declarado como abstracto en ColeccionPersonas
            // e implementado en ListaPersonas y ArrayPersonas, da igual qué tipo de colección sea
            cp.GuardarTodosLosElementosEnFichero();
            #endregion
        }
    }
}
