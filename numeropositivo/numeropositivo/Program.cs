using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numeropositivo
{
    internal class Program
    {
        static void Main()
        {
            int num;
                int factoria = 1, i = 1;
            Console.WriteLine("Introduzca numero");
            num = int.Parse(Console.ReadLine());
            if (num == 0) 
            {
                Console.WriteLine("El factorial no es esta definido");
            }
            else if (num == 0 || num == 1)
            {
                Console.WriteLine("El factorial" + num);

            }
            else
            {
                while (i <= num) 
                {
                    factoria = factoria * i;
                    i++;
                }
                Console.WriteLine("El factorial: " + factoria);
            }
        }
    }
}
