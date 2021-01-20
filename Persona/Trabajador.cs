using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class Trabajador : Persona
    {
        public int salario;
        public DateTime fechaAlta;

        public Trabajador(string dni, string nombre, string apellidos,int salario, DateTime fecha) : base( dni , nombre, apellidos)
        {
            this.salario = salario;
            this.fechaAlta = fecha;
        }


        public override string ToString()
        {
            return $""
        }


    }
}
