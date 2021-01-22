using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using GestiónEmpleados.DTOs;

namespace GestiónEmpleados.Services
{
    class Controlador
    {
        public List<InfoTrabajador> plantilla { get; set; }

        public InfoJefeEquipo TipoJefeEquipo= new InfoJefeEquipo("000000","Prueba","probando",new DateTime(1900,1,1),"Calle",0,"");
        public InfoJefeVentas TipoJefeVentas = new InfoJefeVentas("000000", "Prueba", "probando", new DateTime(1900, 1, 1), "Calle",  "");

        public Controlador()
        {
            plantilla = new List<InfoTrabajador>();
        }

        public void RegistroNuevoTrabajador(InfoTrabajador nuevoTrabajador)
        {
            plantilla.Add(nuevoTrabajador);
        }

        public bool ExisteJefeEquipo()
        {
            foreach (var VARIABLE in plantilla)
            {
                if(Object.ReferenceEquals(VARIABLE.GetType(), TipoJefeEquipo.GetType()))
                {
                    return true;
                }
            }

            return false;
        }

        public InfoJefeEquipo JefeEquipo()
        {
            foreach (InfoTrabajador VARIABLE in plantilla)
            {
                if (TipoJefeEquipo.Equals(VARIABLE))
                {
                    return (InfoJefeEquipo) VARIABLE;
                }
            }

            return null;
        }

        public bool ExisteJefeVentas()
        {
            foreach (var VARIABLE in plantilla)
            {
                if (Object.ReferenceEquals(VARIABLE.GetType(), TipoJefeEquipo.GetType()))
                {
                    return true;
                }
            }

            return false;
        }

        public InfoJefeVentas JefeVentas()
        {
            foreach (InfoTrabajador VARIABLE in plantilla)
            {
                if (TipoJefeVentas.Equals(VARIABLE))
                {
                    return (InfoJefeVentas)VARIABLE;
                }
            }

            return null;
        }

    }
}
