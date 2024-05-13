using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabla_de_multiplicar
{
    internal class Program
    {
        static void Main()
        {
            int multi, k, num;
           multi = 0;
            Console.WriteLine("Ingresar un numero");
            num = int.Parse(Console.ReadLine());

            for (k=1; k<=10; k++) 
            {
                multi = k * num;
                Console.WriteLine($"{k} * {num} = {multi} ");
            }
        }
    }
}
