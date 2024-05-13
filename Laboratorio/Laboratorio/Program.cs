using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<int> cola = new Queue<int>();

        Console.WriteLine("Ingrese enteros para formar la cola :");

        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int numero))
            {
                if (numero == -9999)
                    break;

                if (numero < 0)
                {
                    Console.WriteLine("No se permiten enteros negativos. Inténtelo de nuevo.");
                    continue;
                }

                cola.Enqueue(numero);
            }
            else
            {
                Console.WriteLine("Entrada no válida. Inténtelo de nuevo.");
            }
        }

        Console.WriteLine("\nCola inicial:");
        MostrarCola(cola);

        // Realizar operaciones comunes sobre colas
        Console.WriteLine("\nOperaciones comunes sobre colas:");

        cola.Enqueue(42);
        MostrarCola(cola);

        int elementoEliminado = cola.Dequeue();
        Console.WriteLine($"\nElemento eliminado: {elementoEliminado}");
        MostrarCola(cola);

        Console.WriteLine($"\nLa cola está vacía: {cola.Count == 0}");

        // Aplicar balking
        Console.WriteLine("\nAplicando balking (eliminar el primer 5):");
        EliminarElemento(cola, 5);
        MostrarCola(cola);
    }

    static void MostrarCola(Queue<int> cola)
    {
        if (cola.Count == 0)
        {
            Console.WriteLine("La cola está vacía.");
        }
        else
        {
            Console.Write("Cola: ");
            foreach (var elemento in cola)
            {
                Console.Write($"{elemento} ");
            }
            Console.WriteLine();
        }
    }

    static void EliminarElemento(Queue<int> cola, int elemento)
    {
        if (cola.Contains(elemento))
        {
            Queue<int> nuevaCola = new Queue<int>();

            while (cola.Count > 0)
            {
                int frente = cola.Dequeue();

                if (frente != elemento)
                {
                    nuevaCola.Enqueue(frente);
                }
            }

            while (nuevaCola.Count > 0)
            {
                cola.Enqueue(nuevaCola.Dequeue());
            }
        }
        else
        {
            Console.WriteLine($"Elemento {elemento} no encontrado en la cola.");
        }
    }
}
