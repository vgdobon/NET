using biblioteca.DTOs;
using System.Collections.Generic;

namespace biblioteca.Services
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
    }
}
