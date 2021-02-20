using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esqueletoProgramaCRUDconBD.B_DTOs.DepTecnico
{
    public class TrabDepTecnicoDTO: TrabajadorDTO
    {
        public int AnyosExp { get; set; }
        public string Tecnologia { get; set; }
    }
}
