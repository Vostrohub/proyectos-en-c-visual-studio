using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signos_de_alternaciom
{
    internal class Program
    {
        static void Main()
        {
            int sum, k, num, signo;
            Console.WriteLine("Ingresar un numero positivo: ");
            num = int.Parse(Console.ReadLine());
            if (num <= 0)
                Console.WriteLine("Valor de entrada invalido - terminar \n");
            else 
            {
                sum = 0;
                signo = 1;
                for (k = 1; k <= num; k++) 
                {
                    sum = sum + signo * k;
                    signo = -signo;
                }
                Console.WriteLine("La suma es {0} \n", sum);
            }

        }
    }
}
