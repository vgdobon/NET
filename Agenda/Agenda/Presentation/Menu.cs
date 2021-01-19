using System;

public class Menu
{


	public void mostrarMenu()
    {
		Console.WriteLine("Elija una opcion (1, 2, 3, 4 o 5");
		Console.WriteLine(" 1 - Dar de alta nuevo contacto \n" +
						  " 2 - Borrar contacto \n" +
						  " 3 - Buscar teléfono de un contacto \n" +
						  " 4 -dfsfsdfsdfsdMostrar todoslos contactos y devolver el número de contactos dados de alta \n" +
						  " 5 - Salir.");
	}
	public int elegirOpcion()
	{
	
		bool OpcionIsInt = int.TryParse(Console.ReadLine(), out int opcion);

		if (OpcionIsInt)
			return opcion;
		else
			return -1;
	}
}
}
