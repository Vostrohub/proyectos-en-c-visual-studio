using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Queue miCola = new Queue();
        int opcion;

        do
        {
            Console.Clear();
            opcion = Menu();
            switch (opcion)
            {
                case 1:
                    Agregar(ref miCola);
                    break;
                case 2:
                    Eliminar(ref miCola);
                    break;
                case 3:
                    Limpiar(ref miCola);
                    break;
                case 4:
                    Imprimir(miCola);
                    break;
                case 5:
                    break;
                default:
                    Mensaje("ERROR: La opción no es válida. Intente de nuevo.");
                    break;
            }
        }
        while (opcion != 5);

        Mensaje("El programa ha finalizado");
    }

    static void Eliminar(ref Queue cola)
    {
        if (cola.Count > 0)
        {
            // Elimina el primer elemento de la cola
            int elemento = (int)cola.Dequeue();

            // Imprime el mensaje de confirmación
            Mensaje($"Elemento {elemento} eliminado");
        }
        else
        {
            // La cola está vacía
            Mensaje("La cola está vacía");
        }
    }

    static void Agregar(ref Queue cola)
    {
        Console.WriteLine("\n> Ingrese el valor: ");
        try
        {
            int valor = Convert.ToInt32(Console.ReadLine());
            if (valor > 99 || valor <= 0)
            {
                Mensaje("Solo se permiten números del 1 al 99.");
            }
            else
            {
                cola.Enqueue(valor);
                Imprimir(cola);
            }
        }
        catch
        {
            Mensaje("Error: Solo se permiten números del 1 al 99.");
        }
    }

    static void Limpiar(ref Queue cola)
    {
        cola.Clear();
        Imprimir(cola);
    }

    static int Menu()
    {
        Console.WriteLine("\nCola Menu");
        Console.WriteLine(" 1. - Agregar elemento");
        Console.WriteLine(" 2. - Eliminar elemento");
        Console.WriteLine(" 3. - Vaciar cola");
        Console.WriteLine(" 4. - Ver cola");
        Console.WriteLine(" 5. - Terminar Programa");
        Console.WriteLine(" jj:> - Ingresa tu opción");
        try
        {
            int valor = Convert.ToInt32(Console.ReadLine());
            return valor;
        }
        catch
        {
            return 0;
        }
    }

    static void Mensaje(string texto)
    {
        if (texto.Length > 0)
        {
            Console.WriteLine("\n=======================================================");
            Console.WriteLine($"JJ: > {texto}");
            Console.WriteLine("=======================================================");
            Console.WriteLine("\n JJ:> Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void Imprimir(Queue cola)
    {
        if (cola.Count > 0)
        {
            Console.WriteLine();
            foreach (int dato in cola)
            {
                Console.WriteLine("|    |");
                if (dato < 10)
                    Console.WriteLine($"| 0{dato} |");
                else
                    Console.WriteLine($"| {dato} |");
                Console.WriteLine("|____|");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        else
        {
            Mensaje("La cola está vacía");
        }
    }
}
