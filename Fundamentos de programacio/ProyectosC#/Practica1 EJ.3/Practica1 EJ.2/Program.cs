using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_EJ._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;

            Console.WriteLine("Ingrese a:");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese b:");
            b = int.Parse(Console.ReadLine());

            double x = (double)a / ((double)a + b) / ((double)a - b);
            Console.WriteLine("El resultado es: " + x);

        }
    }
}
