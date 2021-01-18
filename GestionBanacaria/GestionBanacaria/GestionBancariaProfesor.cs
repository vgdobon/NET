using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ejercicio13version2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numsCuenta = new List<string>
            {
                "Jorge",
                "Manuel"
            };
            List<string> passwords = new List<string>
            {
                "1",
                "2"
            };
            List<decimal> saldos = new List<decimal>
            {
                1000,
                0
            };
            List<List<decimal>> HistoricoMovimientos = new List<List<decimal>>
            {
                new List<decimal> { 10, 20, -15},
                new List<decimal>()
            };
            Console.Write("Número de cuenta: ");
            string numCuenta = Console.ReadLine();
            Console.Write("Contraseña: ");
            string pwd = Console.ReadLine();
            int posUsuario = numsCuenta.IndexOf(numCuenta);
            if (posUsuario != -1 && passwords.ElementAt(posUsuario) == pwd)
            {
                decimal saldo = saldos.ElementAt(posUsuario);
                List<decimal> movimientos = HistoricoMovimientos.ElementAt(posUsuario);
                string opcion = "";
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - Ingreso de efectivo");
                    Console.WriteLine("2 - Retirada de efectivo");
                    Console.WriteLine("3 - Lista de todos los movimientos");
                    Console.WriteLine("4 - Lista de todos los ingresos de efectivo");
                    Console.WriteLine("5 - Lista de todas las retiradas de efectivo");
                    Console.WriteLine("6 - Mostrar saldo actual");
                    Console.WriteLine("7 - Salir");
                    Console.Write("Seleccione una opción: ");
                    opcion = Console.ReadLine();
                    bool terminar = false;
                    switch (opcion)
                    {
                        case "1":
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("  INGRESO DE EFECTIVO  ");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine();
                            Console.Write("Introduzca la cantidad que desea ingresar: ");
                            string ingresoStr = Console.ReadLine().Replace('.', ',');
                            bool ingresoStrIsDecimal = decimal.TryParse(ingresoStr, out decimal ingreso);
                            if (ingresoStrIsDecimal && ingreso > 0)
                            {
                                saldo += ingreso;
                                movimientos.Add(ingreso);
                                Console.Write("El ingreso de efectivo se ha realizado correctamente");
                            }
                            else
                            {
                                Console.Write("Error al tratar de hacer el ingreso de efectivo");
                            }
                            break;
                        case "2":
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("  RETIRADA DE EFECTIVO  ");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine();
                            Console.Write("Introduzca la cantidad que desea retirar: ");
                            string retiradaStr = Console.ReadLine().Replace('.', ',');
                            bool retiradaStrIsDecimal = decimal.TryParse(retiradaStr, out decimal retirada);
                            if (retiradaStrIsDecimal && retirada > 0 && !(retirada > saldo))
                            {
                                saldo -= retirada;
                                movimientos.Add(-retirada);
                                Console.Write("La retirada de efectivo se ha realizado correctamente");
                            }
                            else
                            {
                                Console.Write("Error al tratar de hacer la retirada de efectivo");
                            }
                            break;
                        case "3":
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("  LISTA MOVIMIENTOS  ");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine();
                            foreach (decimal d in movimientos)
                            {
                                Console.WriteLine(d);
                            }
                            break;
                        case "4":
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("     LISTA INGRESOS    ");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine();
                            foreach (decimal d in movimientos)
                            {
                                if (d > 0)
                                {
                                    Console.WriteLine(d);
                                }
                            }
                            break;
                        case "5":
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("     LISTA RETIRADAS   ");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine();
                            foreach (decimal d in movimientos)
                            {
                                if (d < 0)
                                {
                                    Console.WriteLine(d);
                                }
                            }
                            break;
                        case "6":
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("     MOSTRAR SALDO     ");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine();
                            Console.WriteLine($"su saldo actual es de {saldo}");
                            break;
                        case "7":
                            terminar = true;
                            break;
                        default:
                            Console.Write("Opción incorrecta");
                            break;
                    }
                    if (terminar == false)
                    {
                        Console.ReadKey();
                    }
                } while (!(opcion == "7"));
            }
            else
            {
                Console.WriteLine("El nº de cuenta o la contraseña introducida son incorrectos");
            }
            Console.WriteLine();
            Console.Write("(Fin del programa. Pulse cualquier tecla para cerrar la consola)");
            Console.ReadKey();
        }
    }
}
