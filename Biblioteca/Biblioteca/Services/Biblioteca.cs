using Biblioteca.DTOs;
using System;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class Biblioteca
    {
        public List<DTOs.Libro> biblioteca;

        public Biblioteca()
        {
            this.biblioteca = new List<DTOs.Libro>();
        }

        public bool annadirLibro(string title,string author,  string year, string category)
        {
            Libro libro = new Libro(title, author, year, category);

            if (biblioteca != null)
            {
                biblioteca.Add(libro);
                return true;
            }

            return false;
        }

        public List<Libro> mostrarLibros(bool alquilado)
        {
            List<Libro> listadoLibros = new List<Libro>();

            foreach (Libro libro in biblioteca)
            {
                if (libro.Alquilado == alquilado)
                    listadoLibros.Add(libro);
            }

            return listadoLibros;
        }

        public List<Libro> MostrarLibrosPorGenero(string genero)
        {
            List<Libro> listadoPorGenero = new List<Libro>();
            foreach (Libro libro in biblioteca)
            {
                if (libro.Category.ToLower() == genero.ToLower())
                    listadoPorGenero.Add(libro);
            }

            return listadoPorGenero;
        }

        public Libro BuscarLibroPorId(int i)
        {
            foreach(Libro libro in biblioteca)
            {
                if (libro.Id == i)
                {
                    return libro;
                }
            }

            return null;
        }

    }
}
