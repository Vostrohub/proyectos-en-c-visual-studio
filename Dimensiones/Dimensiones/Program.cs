using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dimensiones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,,] ventas = new int[3, 5, 12];
            for (int z = 0; z < 3; z++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        ventas[z, i, j] = 0;
                    }
                }
            }

            for (int z = 0; z < 3; z++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        Console.Write(ventas[z, i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }