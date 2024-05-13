using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Crear la lista
        List<int> numbers = new List<int>();

        // Tomar tantos enteros positivos como sea posible como entrada
        Console.WriteLine("Ingrese enteros positivos. Ingrese -9999 para terminar la entrada.");
        while (true)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            if (number == -9999)
            {
                break;
            }
            numbers.Add(number);
        }

        // Imprimir la lista de números en el orden en que fueron ingresados
        Console.WriteLine("La lista de números es: ");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();

        // Imprimir sólo los números impares en la lista
        odd_print(numbers);

        // Encontrar el máximo entero en la lista
        int max = find_max(numbers);
        Console.WriteLine("El máximo entero en la lista es: " + max);

        // Encontrar la posición del máximo entero en la lista
        int pos = find_pos(numbers, max);
        Console.WriteLine("La posición del máximo entero en la lista es: " + pos);
    }

    // Función para imprimir sólo los números impares en la lista
    static void odd_print(List<int> numbers)
    {
        Console.WriteLine("Los números impares en la lista son: ");
        foreach (int number in numbers)
        {
            if (number % 2 != 0)
            {
                Console.Write(number + " ");
            }
        }
        Console.WriteLine();
    }

    // Función para encontrar el máximo entero en la lista
    static int find_max(List<int> numbers)
    {
        return numbers.Max();
    }

    // Función para encontrar la posición de un número en la lista
    static int find_pos(List<int> numbers, int x)
    {
        return numbers.IndexOf(x);
    }
}
