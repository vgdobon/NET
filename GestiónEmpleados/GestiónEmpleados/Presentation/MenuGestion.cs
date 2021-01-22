using System;
using GestiónEmpleados.DTOs;
using GestiónEmpleados.Services;

namespace GestiónEmpleados.Presentation
{
    class MenuGestion
    {
        private bool _finalizar;

        private Controlador controlador;

        public MenuGestion()
        {
            controlador = new Controlador();
            _finalizar = false;
        }



        
        internal void EjecutarApp()
        {

            do
            {
                Console.Clear();
                MostrarMenu();
                _finalizar = EjecutarOpcion(elegirOpcion());
            } while ( !_finalizar);



        }

        private bool EjecutarOpcion(int opcion)
        {
            string dni;
            string nombre;
            string apellidos;
            string direccion;
            string tecnologia;
            string zonaComercial;

            DateTime fechaNacimiento;
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Alta de jefes de equipo");

                    Console.Write("Dni:");
                    dni = Console.ReadLine();

                    Console.Write("Nombre:");
                    nombre = Console.ReadLine();

                    Console.Write("Apellidos:");
                    apellidos = Console.ReadLine();

                    Console.WriteLine("Fecha de nacimiento:");
                    Console.Write("Año:");
                    int.TryParse(Console.ReadLine(),out int annoJefeEquipo);
                    Console.Write("Mes:");
                    int.TryParse(Console.ReadLine(), out int mesJefeEquipo);
                    Console.Write("Dia:");
                    int.TryParse(Console.ReadLine(), out int diaJefeEquipo);

                    fechaNacimiento = new DateTime(annoJefeEquipo, mesJefeEquipo, diaJefeEquipo);

                    Console.Write("Direccion");
                    direccion = Console.ReadLine();

                    Console.Write("Años de experiencia:");
                    int.TryParse(Console.ReadLine(), out int annosExpJefeEquipo);

                    Console.Write("Tecnologia");
                    tecnologia = Console.ReadLine();

                    controlador.RegistroNuevoTrabajador(new InfoJefeEquipo(dni,nombre,apellidos,fechaNacimiento,direccion, annosExpJefeEquipo, tecnologia));


                    Console.ReadKey();

                    break;

                case 2:

                    Console.WriteLine("Alta de técnicos(comprobar que el responsable existe)");

                    if (controlador.ExisteJefeEquipo())
                    {
                        InfoJefeEquipo responsableTecnologia= controlador.JefeEquipo();

                        Console.Write("Dni:");
                        dni = Console.ReadLine();

                        Console.Write("Nombre:");
                        nombre = Console.ReadLine();


                        Console.Write("Apellidos:");
                        apellidos = Console.ReadLine();
                        Console.WriteLine("Fecha de nacimiento:");
                        Console.Write("Año:");
                        int.TryParse(Console.ReadLine(), out int annoTecnico);
                        Console.Write("Mes:");
                        int.TryParse(Console.ReadLine(), out int mesTecnico);
                        Console.Write("Dia:");
                        int.TryParse(Console.ReadLine(), out int diaTecnico);

                        fechaNacimiento = new DateTime(annoTecnico, mesTecnico, diaTecnico);

                        Console.Write("Direccion");
                        direccion = Console.ReadLine();

                        Console.Write("Años de experiencia:");
                        int.TryParse(Console.ReadLine(), out int annosExp);

                        Console.Write("Tecnologia");
                        tecnologia = Console.ReadLine();

                        controlador.RegistroNuevoTrabajador(new InfoTecnico(dni,nombre,apellidos,fechaNacimiento,direccion,annosExp,tecnologia,responsableTecnologia));
                    }
                    else
                    {
                        Console.WriteLine("No existe un Responsable Jefe de equipo");
                    }
                   


                    Console.ReadKey();

                    break;

                case 3:

                    Console.WriteLine("3 - Alta de jefes de ventas");
                    Console.Write("Dni:");
                    dni = Console.ReadLine();

                    Console.Write("Nombre:");
                    nombre = Console.ReadLine();

                    Console.Write("Apellidos:");
                    apellidos = Console.ReadLine();

                    Console.WriteLine("Fecha de nacimiento:");
                    Console.Write("Año:");
                    int.TryParse(Console.ReadLine(), out int annoJefeVentas);
                    Console.Write("Mes:");
                    int.TryParse(Console.ReadLine(), out int mesJefeVentas);
                    Console.Write("Dia:");
                    int.TryParse(Console.ReadLine(), out int diaJefeVentas);

                    fechaNacimiento = new DateTime(annoJefeVentas, mesJefeVentas, diaJefeVentas);

                    Console.Write("Direccion");
                    direccion = Console.ReadLine();

                    Console.Write("Zona Comercial:");
                    zonaComercial = Console.ReadLine();

                    controlador.RegistroNuevoTrabajador(new InfoJefeVentas(dni, nombre, apellidos, fechaNacimiento, direccion, zonaComercial));

                    Console.ReadKey();

                    break;

                case 4:

                    Console.WriteLine("4 - Alta de Comerciales");

                    if (controlador.ExisteJefeVentas())
                    {

                        InfoJefeVentas responsableComercial = controlador.JefeVentas();

                        Console.Write("Dni:");
                        dni = Console.ReadLine();

                        Console.Write("Nombre:");
                        nombre = Console.ReadLine();

                        Console.Write("Apellidos:");
                        apellidos = Console.ReadLine();

                        Console.WriteLine("Fecha de nacimiento:");
                        Console.Write("Año:");
                        int.TryParse(Console.ReadLine(), out int annoComercial);
                        Console.Write("Mes:");
                        int.TryParse(Console.ReadLine(), out int mesComercial);
                        Console.Write("Dia:");
                        int.TryParse(Console.ReadLine(), out int diaComercial);

                        fechaNacimiento = new DateTime(annoComercial, mesComercial, diaComercial);

                        Console.Write("Direccion");
                        direccion = Console.ReadLine();

                        Console.Write("Zona Comercial:");
                        zonaComercial = Console.ReadLine();

                        controlador.RegistroNuevoTrabajador(new InfoComercial(dni, nombre, apellidos, fechaNacimiento, direccion, zonaComercial,responsableComercial));

                    }
                    else
                    {
                        Console.WriteLine("No existe un Responsable Jefe de equipo");
                    }

                    Console.ReadKey();


                    break;

                case 5:
                    Console.WriteLine("5 - Alta de personas de dpto.de dirección");

                    Console.Write("Dni:");
                    dni = Console.ReadLine();

                    Console.Write("Nombre:");
                    nombre = Console.ReadLine();

                    Console.Write("Apellidos:");
                    apellidos = Console.ReadLine();

                    Console.WriteLine("Fecha de nacimiento:");
                    Console.Write("Año:");
                    int.TryParse(Console.ReadLine(), out int annoDireccion);
                    Console.Write("Mes:");
                    int.TryParse(Console.ReadLine(), out int mesDireccion);
                    Console.Write("Dia:");
                    int.TryParse(Console.ReadLine(), out int diaDireccion);

                    fechaNacimiento = new DateTime(annoDireccion, mesDireccion, diaDireccion);

                    Console.Write("Direccion");
                    direccion = Console.ReadLine();

                    Console.Write("Cargo");
                    string cargo = Console.ReadLine();

                    controlador.RegistroNuevoTrabajador(new InfoDirección(dni, nombre, apellidos, fechaNacimiento, direccion, cargo));

                    break;

                case 6:
                    
                    Console.WriteLine("6 - Mostrar todos los técnicos");

                    foreach (InfoTrabajador trabajador in controlador.plantilla)
                    {
                        if (trabajador is InfoTecnico)
                        {
                            Console.WriteLine(trabajador);
                        }
                        //if (trabajador.GetType().Equals(typeof(InfoTecnico)))
                        //{
                        //    Console.WriteLine(trabajador);
                        //}
                    }

                    Console.ReadKey();

                    break;

                case 7:

                    Console.WriteLine("7 - Mostrar los técnicos según responsable");

                    Console.WriteLine("Tecnicos asignados al responsable:");
                    string nombreResposableTecnico = Console.ReadLine();

                    foreach (var variable in controlador.plantilla)
                    {
                        if (variable is InfoTecnico)
                        {
                            InfoTecnico tecnico = (InfoTecnico) variable;

                            if (tecnico.Responsable.Nombre.Equals(nombreResposableTecnico))
                            {
                                Console.WriteLine(tecnico);
                            }
                        }
                    }

                    break;

                case 8:
                    Console.WriteLine("8 - Mostrar los comerciales según responsable");
                    Console.Write("Comercial asignados al responsable: ");
                    string nombreResposableVentas = Console.ReadLine();

                    foreach (var variable in controlador.plantilla)
                    {
                        if (variable is InfoComercial)
                        {
                            InfoComercial comercial = (InfoComercial)variable;

                            if (comercial.Responsable.Nombre.Equals(nombreResposableVentas))
                            {
                                Console.WriteLine(comercial);
                            }
                        }
                    }

                    break;

                case 9:

                    Console.WriteLine("9 - Mostrar jefes de equipo según tecnología");
                    string tecnologiaConsulta = Console.ReadLine();

                    foreach (var variable in controlador.plantilla)
                    {
                        if(variable is InfoJefeEquipo)
                        {
                            InfoJefeEquipo jefeEquipoConsulta = (InfoJefeEquipo)variable;

                            if (jefeEquipoConsulta.Tecnologia.Equals(tecnologiaConsulta))
                            {
                                Console.WriteLine(jefeEquipoConsulta);
                            }
                        }
                    }

                    break;

                case 10:

                    Console.WriteLine("10 - Mostrar Dpto.Dirección");

                    foreach (var variable in controlador.plantilla)
                    {
                        if (variable is InfoDirección)
                        {
                            Console.WriteLine(variable);
                        }
                    }

                    break;

                case 11:

                    Console.WriteLine("11 - Baja de personal");

                    string dniBaja = Console.ReadLine();

                    InfoTrabajador trabajadorBaja = null;

                    foreach (var VARIABLE in controlador.plantilla)
                    {
                        if (VARIABLE.Dni.Equals(dniBaja))
                        {
                            trabajadorBaja = VARIABLE;
                        }
                    }

                    controlador.plantilla.Remove(trabajadorBaja);

                    break;

                case 12:
                    _finalizar = true;

                    break;

                default:
                    Console.WriteLine("Un error ha ocurrido en la opción del menú.");
                    break;
            }

            return _finalizar;
        }

        private int elegirOpcion()
        {
            bool opcionCorrecta = false;
            int opcion;
            do
            {
                Console.Write("Elija una opcion");
                bool opcionIsInt = int.TryParse(Console.ReadLine(), out opcion);

                if(opcionIsInt && opcion>0 && opcion < 13)
                {
                    opcionCorrecta = true;
                }
                else
                {
                    Console.WriteLine("No has elegido una opcion correcta. Debe introducir un número entre 1 y 12");
                }

            } while (!opcionCorrecta);
            

            return opcion;
        }


        private void MostrarMenu()
        {
            Console.WriteLine("1 - Alta de jefes de equipo\n" +
                              "2 - Alta de técnicos(comprobar que el responsable existe)\n" +
                              "3 - Alta de jefes de ventas\n" +
                              "4 - Alta de Comerciales(comprobar que el responsable existe)\n" +
                              "5 - Alta de personas de dpto.de dirección\n" +
                              "6 - Mostrar todos los técnicos\n " +
                              "7 - Mostrar los técnicos según responsable\n " +
                              "8 - Mostrar los comerciales según responsable\n " +
                              "9 - Mostrar jefes de equipo según tecnología\n " +
                              "10 - Mostrar Dpto.Dirección\n " +
                              "11 - Baja de personal\n " +
                              "12 - Salir");
        }
    }
}