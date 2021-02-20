using System;

namespace esqueletoProgramaCRUDconBD.A_Presentation.Menus
{
    public abstract class MenuGenerico
    {

        /// <summary>
        /// propiedad que dara acceso desde cualquier método de la clase a la opción seleccionada del menú
        /// </summary>
        protected string Option { get; set; }
        /// <summary>
        /// propiedad que indicará a cualquier método de la clase si el usuario ha decidido salir o no del menú
        /// </summary>
        protected bool Finish { get; set; }

        public void Execute()
        {
            do
            {
                Console.Clear();
                ShowMenu();
                Option = UtilesPresentation.GetStringFromUser("Seleccione una opción");

                ManageSelectedOption();
            } while (Finish == false);
        }

        public abstract void ShowMenu();

        public abstract void ManageSelectedOption();

        public void EnteredWrongOption()
        {
            WriteLineAndWaitForKeyPressed("La opción seleccionada no existe");
        }

        public void WriteLineAndWaitForKeyPressed(string msg)
        {
            Console.WriteLine(msg);
            WaitForKeyPressed();
        }

        public void WaitForKeyPressed()
        {
            Console.WriteLine();
            Console.WriteLine("Pulse cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
