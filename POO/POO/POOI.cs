using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class POOI
    {
        public string Nombre { get; set }


        public POO(){ }

        public POO(string Nombre)
        {
            this.Nombre = Nombre;
        }

        public void EscribirNombre()
        {
            Console.WriteLine(Nombre);
        }
    }
}
