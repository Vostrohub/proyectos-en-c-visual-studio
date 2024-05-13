using System;

namespace ConsoleApp
{
    public class ejercicio2
    {
        public static void Main(string[] args)
        {
            double ValorA, ValorB, ValorC, ValorD, Resultado;
            Console.WriteLine("Para obtener el resultado de X se necesitan algunos valores");

            //valor A

            Console.WriteLine("Incertar Valor A: ");
            ValorA = double.Parse(Console.ReadLine());


            Console.Clear(); //Sirve para limpiar la consola y dejar solo lo que se necesita al momento

            //valor B
            Console.WriteLine("Incertar Valor B: ");
            ValorB = double.Parse(Console.ReadLine());


            Console.Clear();


            //valor C
            Console.WriteLine("Incertar Valor C: ");
            ValorC = double.Parse(Console.ReadLine());


            Console.Clear();


            //valor D
            Console.WriteLine("Incertar Valor D: ");
            ValorD = double.Parse(Console.ReadLine());


            Console.Clear();



            //Resultado

            double Paso1, Paso2; // declaro las variables cuando las voy a utilizar

            //Realizar calculos


            //Se separan los calculos para poder hacerlo mas legible y mas facil de trabajar por separado
            Paso1 = ValorA + (ValorB / ValorC) + ValorD;
            Paso2 = ValorA;

            Resultado = Paso1 / Paso2;
            Console.WriteLine($"El valor de X es {Resultado}");







        }
    }
}