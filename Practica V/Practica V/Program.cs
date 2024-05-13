using System;

class Program
{
    // Variable global para almacenar el valor capturado en la opción 1
    static int valorGlobal;

    static void Main()
    {
        int opcion;

        do
        {
            MostrarMenu();
            Console.Write("Seleccione una opción (1-5): ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CapturarValor();
                    break;

                case 2:
                    ProcedimientoTablaMultiplicar();
                    break;

                case 3:
                    ProcedimientoMostrarEvaluacionPrimo();
                    break;

                case 4:
                    ProcedimientoDiagonalesMatriz();
                    break;

                case 5:
                    Console.Clear();
                    Console.WriteLine("Fin del Programa");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }

            if (opcion != 5)
            {
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

        } while (opcion != 5);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("Menú Principal");
        Console.WriteLine("------------------");
        Console.WriteLine("1 - Capturar Valor");
        Console.WriteLine("2 - Generar Tabla de Multiplicar");
        Console.WriteLine("3 - Determinar Si es Primo o No Primo");
        Console.WriteLine("4 - Capturar una Matriz 4 x 4: Desplegar la Diagonal Principal y Secundaria");
        Console.WriteLine("5 - Salir del Programa");
    }

    static void CapturarValor()
    {
        Console.Write("Introduce un valor numérico entero: ");
        valorGlobal = int.Parse(Console.ReadLine());
        Console.WriteLine($"Valor capturado: {valorGlobal}");
    }

    static void ProcedimientoTablaMultiplicar()
    {
        Console.WriteLine($"Tabla de Multiplicar de {valorGlobal}:");
        for (int i = 1; i <= 12; i++)
        {
            Console.WriteLine($"{valorGlobal} * {i} = {valorGlobal * i}");
        }
    }

    static void ProcedimientoMostrarEvaluacionPrimo()
    {
        Console.WriteLine(EsPrimo(valorGlobal) ? $"{valorGlobal} es Primo" : $"{valorGlobal} no es Primo");
    }

    static bool EsPrimo(int numero)
    {
        if (numero < 2) return false;
        for (int i = 2; i <= Math.Sqrt(numero); i++)
        {
            if (numero % i == 0)
                return false;
        }
        return true;
    }

    static void ProcedimientoDiagonalesMatriz()
    {
        // Aquí puedes implementar la lógica para capturar o generar la matriz 4x4
        // y luego mostrar las diagonales principal y secundaria.
        // Puedes utilizar una matriz 4x4 predefinida para simplificar el ejemplo.

        int[,] matriz = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16}
        };

        Console.WriteLine("Diagonal Principal:");
        for (int i = 0; i < 4; i++)
        {
            Console.Write(matriz[i, i] + " ");
        }

        Console.WriteLine("\nDiagonal Secundaria:");
        for (int i = 0; i < 4; i++)
        {
            Console.Write(matriz[i, 3 - i] + " ");
        }
    }
}
