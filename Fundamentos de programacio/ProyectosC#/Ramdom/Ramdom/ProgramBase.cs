using System;
using System.Diagnostics;

namespace Ramdom
{
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    internal class ProgramBase
    {
        static void Main()
        {
            {
                Random rand = new Random();

                int dado1 = rand.Next(1, 7);
                int dado2 = rand.Next(1, 7);
                int dado3 = rand.Next(1, 7);

                Console.WriteLine("El resultado del primer dado es: " + dado1);
                Console.WriteLine("El resultado del segundo dado es: " + dado2);
                Console.WriteLine("El resultado del tercer dado es: " + dado3);
            }
        }
    }
}