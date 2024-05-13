using System;

class Program
{
    static void Main()
    {
        int sum = 0;
        int i = 0;
        while (i <= 9) 
        {
            Console.Write("Ingrese el número {0}: ", i + 1);
            int num = Convert.ToInt32(Console.ReadLine());
            sum += num;
            i++;
        } 

        double promedio = sum / 10.0;
        Console.WriteLine("El promedio de los números ingresados es: {0}", promedio);
    }
}
