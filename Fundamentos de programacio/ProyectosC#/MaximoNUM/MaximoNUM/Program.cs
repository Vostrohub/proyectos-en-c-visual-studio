using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoNUM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ingrese el primer numero:");
            int numero1 = Convert .ToInt32(Console.ReadLine());

            Console.WriteLine("ingrese el segundo numero:");
            int numero2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("ingrese el tercer numero:");
            int numero3 = Convert.ToInt32(Console.ReadLine());

            if (numero1 == numero2 && numero2 == numero3)
            {
                Console.WriteLine("Los tres numeros son iguales. ");
            }
            else
            {
                if (numero1 >= numero2)
                {
                    if (numero1 >= numero3)
                    {
                        Console.WriteLine("El maximo es: " + numero1);
                    }
                    else
                    {
                        Console.WriteLine("El numero maximo: " + numero3);
                    }
                }
                else
                {
                    if (numero2 >= numero3)
                    {
                        Console.WriteLine("El numero maximo es : " + numero2);
                    }

                    else
                    {
                        Console.WriteLine("El numero maximo es: " + numero3);
                }   }
            }
        }
    }
}
