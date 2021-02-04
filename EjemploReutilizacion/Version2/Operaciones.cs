using Version2.ClasesPersona;

namespace Version2
{
    /// <summary>
    /// En esta versión se hace uso de herencia, pero no de polimorfismo
    /// </summary>
    class Operaciones
    {
        public void MostrarDosPersonasEnPantalla(Persona p1, Persona p2)
        {
            MostrarPersonaPorPantalla(p1);
            MostrarPersonaPorPantalla(p2);
        }

        public void MostrarPersonaPorPantalla(Persona p)
        {
            switch (p.GetType().Name)
            {
                case "Trabajador":
                    // Para poder ejecutar un método de Trabajador siendo p de tipo Persona, hay que convertir p a tipo Trabajador
                    ((Trabajador)p).MostrarDetallesTrabajador();
                    break;
                case "Desempleado":
                    // Para poder ejecutar un método de Desempleado siendo p de tipo Persona, hay que convertir p a tipo Desempleado
                    ((Desempleado)p).MostrarDetallesDesempleado();
                    break;
                default:
                    break;
            }
        }
    }
}
