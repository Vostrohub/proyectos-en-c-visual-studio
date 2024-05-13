using System;

namespace Dados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int dado1 = rand.Next(1, 7);
            int dado2 = rand.Next(1, 7);
            int dado3 = rand.Next(1, 7);
            int puntosExtra = 0;

            Console.WriteLine("El resultado del primer dado es: " + dado1);
            Console.WriteLine("El resultado del segundo dado es: " + dado2);
            Console.WriteLine("El resultado del tercer dado es: " + dado3);

            int suma = dado1 + dado2 + dado3;

            if (dado1 == dado2 || dado1 == dado3 || dado2 == dado3)
            {
                puntosExtra = 2;
                Console.WriteLine("Has obtenido 2 puntos adicionales por obtener dos caras iguales.");
            }

            suma += puntosExtra;

            Console.WriteLine("La suma total de los dados y los puntos extra es: " + suma);

            if (suma >= 15)
                Console.WriteLine("¡Ganaste!");
            if (suma < 15)
                Console.WriteLine("Perdiste");
        }
    }
}
