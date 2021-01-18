using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lista de números pares hasta el 100");
            Console.Write("\"");
            int num=0;

            while(num<=100)
            {
                if(num%2==0)
                {
                    if(num!=100){
                        Console.Write($"{num},");
                    }else{
                        Console.Write($"{num}\"");
                    }
                }
                num++;
            }
            Console.ReadKey();
        }
    }
}
