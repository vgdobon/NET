using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



//Gestión de cuenta bancaria 
//    • El programa mostrará un menú con las siguientes opciones: 
//        1– Ingreso de efectivo 
//        2–Retirada de efectivo 
//        3- Lista de todos los movimientos 
//        4- Lista de todos los ingresos de efectivo 
//        5- Lista de todas las retiradas de efectivo 
//        6- Mostrar saldo actual 
//        7- Salir. 
//    • Existirá una variable que guardará el saldo de un único cliente y sobre ese saldo se realizarán los ingresos (sumas de dinero al saldo actual) o retiradas(restas de dinero al saldo actual). 
//    • Una vez finalizada cualquier operación, el programa preguntará si queremos realizar alguna otra operación: • Si usuario responde que sí, se volverá a mostrar el menú, esperando que el usuario elija otra opción 
//    • en caso contrario mostrará el valor actual de saldo y finalizará el programa.

namespace GestionBanacaria
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            decimal saldo = 1000;
            List<decimal> ListaMovimientos=new List<decimal>();
            List<List<decimal>> cuentas = new List<List<decimal>>();
            //Lista {ListaCuenta{n.cuenta , pass},Lista}
            List<decimal> JeffBezos = new List<decimal>() { 2, 2222, 999999999 };
            List<decimal> MarkZuckerberg = new List<decimal>() {2, 2222, 999999999};
            List<decimal> BillGates = new List<decimal>() {3, 3333, 999999999};

            


            while (opcion != 7)
            {
                
                
                Console.WriteLine("1– Ingreso de efectivo \n" +
                                  "2– Retirada de efectivo \n" +
                                  "3- Lista de todos los movimientos \n" +
                                  "4- Lista de todos los ingresos de efectivo\n" +
                                  "5- Lista de todas las retiradas de efectivo \n" +
                                  "6- Mostrar saldo actual \n" +
                                  "7- Salir.");
                bool isInt = int.TryParse(Console.ReadLine(),out opcion);
                if (isInt)
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingreso de efectivo\n"+
                                              "Introduzca la cantidad:");
                            bool ingresoIsDecimal = decimal.TryParse(Console.ReadLine(), out decimal ingreso);
                            if (ingresoIsDecimal && ingreso>0)
                            {
                                saldo += ingreso;
                                Console.WriteLine("Operacion realizada");
                            }
                            else
                            {
                                Console.WriteLine("Operacion no permitida");
                            }

                            ListaMovimientos.Add(ingreso);
                            Console.WriteLine("Volviendo al menú..");
                            Thread.Sleep(5000);
                            break;

                        case 2:
                            Console.WriteLine("Retirada de efectivo\n" +
                                              "Introduzca la cantidad:");
                            bool retiradaIsDecimal = decimal.TryParse(Console.ReadLine(), out decimal retirada);
                            if (retiradaIsDecimal && (saldo-retirada)>-200 && retirada>0)
                            {
                                saldo -= retirada;
                                Console.WriteLine("Operacion realizada");
                            }
                            else
                            {
                                Console.WriteLine("Operacion no permitida");
                            }
                            ListaMovimientos.Add(-retirada);
                            Thread.Sleep(5000);
                            Console.WriteLine("Volviendo al menú..");
                            break;

                        case 3:
                            Console.WriteLine("Mostrando la lista de movimientos...");
                            foreach (var movimiento in ListaMovimientos)
                            {
                                Console.WriteLine(movimiento);
                            }

                            Console.ReadKey();
                            break;

                        case 4:
                            Console.WriteLine("Mostrando la lista de ingreso de efectivo....");
                            foreach (var movimiento in ListaMovimientos)
                            {
                                if (movimiento > 0)
                                {
                                    Console.WriteLine(movimiento);
                                }   
                            }
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.WriteLine("Mostrando la lista de ingreso de efectivo....");
                            foreach (var movimiento in ListaMovimientos)
                            {
                                if (movimiento < 0)
                                {
                                    Console.WriteLine(movimiento);
                                }
                            }
                            Console.ReadKey();
                            break;

                        case 6:
                            Console.WriteLine($"Su saldo actual es:{saldo}");
                            Thread.Sleep(5000);
                            break;

                        default:
                            Console.WriteLine("No has elegido una opción incorrecta");
                            break;
                    }
                    
                }
                Console.Clear();

            }
        }
    }
}
