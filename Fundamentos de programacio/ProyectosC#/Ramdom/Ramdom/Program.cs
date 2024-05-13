using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ramdom
{
    internal class Program
    {
        static void Main()
        {
            Random rand = new Random();

            int dado1 = rand.Next(1, 7);
            int dado2 = rand.Next(1, 7);
            int dado3 = rand.Next(1, 7);
            int puntosExtra = 2;

            Console.WriteLine("El resultado del primer dado es: " + dado1);
            Console.WriteLine("El resultado del segundo dado es: " + dado2);
            Console.WriteLine("El resultado del tercer dado es: " + dado3);

            int suma = dado1 + dado2 + dado3 + puntosExtra;
            Console.WriteLine("La suma total de los dados y los puntos extra es: " + suma);

            Console.WriteLine(suma >= 15 ? "¡Has ganado!" : "Has perdido.");
        }
    }
}
