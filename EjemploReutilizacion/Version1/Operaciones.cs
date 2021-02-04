using Version1.ClasesPersona;

namespace Version1
{
    /// <summary>
    /// cada método necesita saber el tipo de cada uno de sus parámetros
    /// </summary>
    class Operaciones
    {
        public void MostrarTrabajadorYDesempleadoEnPantalla(Trabajador t, Desempleado d)
        {
            t.MostrarDetallesTrabajador();
            d.MostrarDetallesDesempleado();
        }

        public void MostrarDesempleadoYTrabajadorEnPantalla(Desempleado d, Trabajador t)
        {
            d.MostrarDetallesDesempleado();
            t.MostrarDetallesTrabajador();
        }
    }
}
