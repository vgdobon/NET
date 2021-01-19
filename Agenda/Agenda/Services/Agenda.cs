using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public class Agenda
    {
        public List<Contacto> ListaContactos  {get;set;}

        public Agenda()
        {
            this.ListaContactos = new List<Contacto>();
        }
    }
}
