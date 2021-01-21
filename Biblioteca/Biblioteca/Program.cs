using biblioteca.Presentation;

//Programa 15: Gestión de una biblioteca
//Escribir un programa desde el cual se pueda gestionar una biblioteca. Al entrar nos mostrará las
//siguientes opciones:
//1 - Añadir nuevo libro
//2 - Alquilar libro
//3 - Buscar libro
//4 - Mostrar listado de todos los libros de un determinado género
//5 - Mostrar listado de libros alquilados
//6 - Mostrar listado de libros disponibles (no alquilados)
//7 - Devolver un libro
//8 - Salir
//Programa 15: Gestión de una biblioteca. Explicación de cada opción
//Opc 1 - Por cada libro nos pedirá: título, autor, año y género. Se almacenará en memoria. Cada libro
//tendrá asociado un código numérico, que se calculará de manera transparente al usuario, y un bool que
//indicará si el libro se encuentra alquilado o no (y que se inicializará a false al añadir cada nuevo libro)
//Opc 2 - Nos pedirá el código, habrá que comprobar que el código exista, así como si ha sido alquilado o
//no. En caso de estar alquilado no permitirá alquilarlo, lo mismo en caso de que no exista.
//Opc 3 - Nos solicitará el título y devolveremos los datos del libro: título, autor, año, género, y si se
//encuentra alquilado o no, siempre y cuando el libro exista.
//Opc 4 - Nos solicitará un género y devolveremos todos los datos de los libros correspondientes al género
//introducido.
//Opc 5 - Devolverá una lista de los libros alquilados.
//Opc 6 - Devolverá una lista de los libros no alquilados.
//Opc 7 - Nos solicitará el código del libro e indicaremos que el libro ya no está alquilado.


namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.ejecutarApp();
        }
    }
}
