using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VENTAS
{
    internal class Program
    {
        static void Main()
        {
            int[] ventas = new int[12];

            ventas[5] = 600000;

            for (int i = 0; i < 12; i++)
                ventas[i] = ventas[i] + 1000000;

            for (int i = 0; i < 12; i++)
                Console.WriteLine($"el valor de ventas en la posicion {i} es {ventas[i]}");
        }
    }
}
