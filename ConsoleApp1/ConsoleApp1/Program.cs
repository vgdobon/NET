using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!" +"\n");
            Console.WriteLine();

            List<List<string>> saludo = new List<List<string>>();
            List<string> barrita = new List<string>{"_","_","_","_","_","_","_","_","_","_","_","_","_"};
            List<string> bienvenido = new List<string>{"|","B", "I", "E", "N", "V", "E", "N", "I", "D", "O", "S","|"};
            List<string> a = new List<string> {"|"," "," "," "," "," ", "A", " "," "," "," "," ","|",};
            List<string> net = new List<string> {"|"," "," "," ",".","N", "E" ,"T"," "," "," "," ","|",};

            saludo.Add(barrita);
            saludo.Add(bienvenido);
            saludo.Add(a);
            saludo.Add(net);
            saludo.Add(barrita);

           foreach( List<string>palabra in saludo){
                foreach(string letra in palabra){
                    Console.Write(letra +"  ");
                    System.Threading.Thread.Sleep(200);               
                }
                Console.WriteLine();
               
           }
            

           
          


            System.Threading.Thread.Sleep(5000);
           
        }
    }

   // Console.Write(saludo[col,fila] + "\n");
   // System.Threading.Thread.Sleep(500);
}
