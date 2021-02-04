using Version5.ClasesColeccion;
using Version5.ClasesPersona;
using Version5.ClasesSalida;

namespace Version5
{
    /// <summary>
    /// En esta versión se hace uso de herencia y de polimorfismo, y se abstrae el tipo de almacenamiento de las personas (List o Array)
    /// </summary>
    class Operaciones
    {
        // ejemplo con abstracción de tipo de persona, tipo de colección y tipo de salida, considerando que ambos objetos persona ya tienen valor
        public void CrearColeccionConDosPersonasExistentesYMostrarlaEnSalida(Persona p1, Persona p2, ColeccionPersonas cp, PersonaASalida pas)
        {
            #region añadir las dos personas pasadas por parámetro a la colección pasada por parámetro
            // usando el método Annadir declarado como abstracto en ColeccionPersonas e implementado en ListaPersonas y ArrayPersonas,
            // da igual qué tipo de colección sea, y qué tipos de personas se vayan a añadir a la colección
            cp.Annadir(p1);
            cp.Annadir(p2);
            #endregion

            #region sacar personas a la salida correspondiente
            cp.SacarTodosLosElementosASalida(pas);
            #endregion
        }

        // ejemplo con abstracción de tipo de persona, tipo de colección y tipo de salida, considerando que ambos objetos persona hay que rellenarlos desde pantalla
        public void CrearColeccionConDosPersonasDesdePantallaYMostrarlaEnSalida(Persona p1, Persona p2, ColeccionPersonas cp, PersonaASalida pas)
        {
            #region rellenar los atributos de las dos personas desde pantalla
            p1.RellenarCamposDesdePantalla();
            p2.RellenarCamposDesdePantalla();
            #endregion

            #region añadir las dos personas recién rellenadas a la colección pasada por parámetro
            // usando el método Annadir declarado como abstracto en ColeccionPersonas e implementado en ListaPersonas y ArrayPersonas,
            // da igual qué tipo de colección sea, y qué tipos de personas se vayan a añadir a la colección
            cp.Annadir(p1);
            cp.Annadir(p2);
            #endregion

            #region sacar personas a la salida correspondiente
            cp.SacarTodosLosElementosASalida(pas);
            #endregion
        }

        // ejemplo con abstracción de tipo de persona, tipo de colección y tipo de salida, considerando que ambos objetos persona hay que rellenarlos desde pantalla
        public void CrearColeccionConDosPersonasDesdeFicheroYMostrarlaEnSalida(Persona p1, Persona p2, ColeccionPersonas cp, PersonaASalida pas)
        {
            #region rellenar los atributos de las dos personas desde fichero
            p1.RellenarCamposDesdeFichero();
            p2.RellenarCamposDesdeFichero();
            #endregion

            #region añadir las dos personas recién rellenadas a la colección pasada por parámetro
            // usando el método Annadir declarado como abstracto en ColeccionPersonas e implementado en ListaPersonas y ArrayPersonas,
            // da igual qué tipo de colección sea, y qué tipos de personas se vayan a añadir a la colección
            cp.Annadir(p1);
            cp.Annadir(p2);
            #endregion

            #region sacar personas a la salida correspondiente
            cp.SacarTodosLosElementosASalida(pas);
            #endregion
        }
    }
}
