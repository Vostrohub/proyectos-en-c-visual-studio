using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Stack miPila = new Stack();
        int opcion = 0;
        do
        {
            Console.WriteLine("1. Agregar elemento a la pila");
            Console.WriteLine("2. Eliminar elemento de la pila");
            Console.WriteLine("3. Vaciar la pila");
            Console.WriteLine("4. Mostrar la pila");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Write("Introduce un número entero del 1 al 99: ");
                        int numero = Convert.ToInt32(Console.ReadLine());
                        if (numero >= 1 && numero <= 99)
                        {
                            miPila.Push(numero);
                        }
                        else
                        {
                            Console.WriteLine("Número inválido. Introduce un número del 1 al 99.");
                        }
                        break;
                    case 2:
                        if (miPila.Count > 0)
                        {
                            Console.WriteLine("Elemento eliminado: " + miPila.Pop());
                        }
                        else
                        {
                            Console.WriteLine("La pila está vacía.");
                        }
                        break;
                    case 3:
                        miPila.Clear();
                        Console.WriteLine("La pila ha sido vaciada.");
                        break;
                    case 4:
                        Console.WriteLine("Elementos de la pila:");
                        foreach (var item in miPila)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Elige una opción del 1 al 5.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Introduce un número entero.");
            }
        } while (opcion != 5);
    }
}
