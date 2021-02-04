using Version4.ClasesPersona;

namespace Version4.ClasesColeccion
{
    class ArrayPersonas : ColeccionPersonas
    {
        public Persona[] ap { get; set; }
        public int nextIndexToAddNewValue { get; set; }

        public ArrayPersonas()
        {
            // por defecto, definimos que el array creado sea solo de 2 elementos
            ap = new Persona[2];
        }

        public ArrayPersonas(int tamanno)
        {
            // si se desea definir un tamaño distinto de 2 para el array, se añade este constructor
            ap = new Persona[tamanno];
        }

        public override void Annadir(Persona p)
        {
            ap[nextIndexToAddNewValue] = p;
            nextIndexToAddNewValue++;
        }

        public override void MostrarTodosLosElementosEnPantalla()
        {
            // - no sabemos de qué tipo es cada persona del array, pero al aplicar polimorfismo con el método MostrarDetalles(),
            //   declarado como abstracto en Persona y sobreescrito en Trabajador y Desempleado, NO HACE FALTA saber los tipos.
            // - Como desde este método no sabemos cuántos elementos va a tener el array, añadimos el código que recorre un array
            // - nextIndexToAddNewValue tiene el índice donde se añadirá un posible siguiente elemento.
            //   así pues, el último elemento en el momento actual está en el índice nextIndexToAddNewValue-1
            // - Si el array no tiene elementos, nextIndexToAddNewValue valdrá 0 y no habrá que ejecutar el bloque for
            for (int i = 0; i < nextIndexToAddNewValue; i++)
            {
                ap[i].MostrarDetalles();
            }
        }

        public override void GuardarTodosLosElementosEnFichero()
        {
            // - no sabemos de qué tipo es cada persona del array, pero al aplicar polimorfismo con el método MostrarDetalles(),
            //   declarado como abstracto en Persona y sobreescrito en Trabajador y Desempleado, NO HACE FALTA saber los tipos.
            // - Como desde este método no sabemos cuántos elementos va a tener el array, añadimos el código que recorre un array
            // - nextIndexToAddNewValue tiene el índice donde se añadirá un posible siguiente elemento.
            //   así pues, el último elemento en el momento actual está en el índice nextIndexToAddNewValue-1
            // - Si el array no tiene elementos, nextIndexToAddNewValue valdrá 0 y no habrá que ejecutar el bloque for
            if (nextIndexToAddNewValue > 0)
            {
                for (int i = 0; i < nextIndexToAddNewValue; i++)
                {
                    ap[i].GuardarEnFichero();
                }
            }
        }
    }
}
