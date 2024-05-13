using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_EJ5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Double a, b, c;

            Console.WriteLine("Ingrese a:");
            a = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese b:");
            b = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese c:");
            c = Double.Parse(Console.ReadLine());

            Double x = (a + b + c) / ((a + b) / c);
            Console.WriteLine("El resultado es: " + x);
        }
    }
}
