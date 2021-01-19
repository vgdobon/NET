using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public class Contacto
    {
        public string Nombre  {get;set;}
        public string Apellidos {get;set;}
        public string Numero  {get;set;}

        public Contacto()
        {

        }

        public Contacto(string NombrePar, string ApellidosPar, string NumeroPar)
        {
            this.Nombre = NombrePar;
            this.Apellidos = ApellidosPar;
            this.Numero = NumeroPar;
        }

        public override string ToString()
        {
            return $"Nombre:{Nombre}\t Apellidos:{Apellidos}\tNumero:{Numero}";
        }
    }
}
