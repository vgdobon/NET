using System;

namespace biblioteca.DTOs
{
    public class Libro
    {
        public static int Incrementer { get; set; }
        public int Id { get; set; }
    
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Category { get; set; }

        public bool Alquilado { get; set; }



        public Libro(string title, string author, string year, string Category)
        {
            this.Title = title ?? throw new ArgumentNullException(nameof(title));
            this.Author = author ?? throw new ArgumentNullException(nameof(author));
            this.Year = year ?? throw new ArgumentNullException(nameof(year));
            this.Category = Category ?? throw new ArgumentNullException(nameof(Category));
            this.Alquilado = false;
            Incrementer++;
            Id = Incrementer;

        }
    }
}
