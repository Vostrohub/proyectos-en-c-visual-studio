using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace venta
{
    internal class Program
    {
        static void Main()
        {
            int[,] ventas = new int[5, 12];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 12; j++)
                {

                    ventas[i, j] = 0;
                }

            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Console.Write(ventas[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
