using System;
using System.Linq;

namespace EnseñarVocales
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializar un arreglo de palabras con dos palabras para cada vocal
            string[][] palabras = new string[][]
            {
                new string[] {"árbol", "águila"},
                new string[] {"elefante", "estrella"},
                new string[] {"índice", "iguana"},
                new string[] {"órgano", "oso"},
                new string[] {"último", "uña"},
            };

            // Presentar al usuario un menú con las 5 vocales
            char[] vocales = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char vocal in vocales)
            {
                Console.WriteLine(vocal + ": ");
            }

            // Solicitar al usuario que ingrese una vocal
            Console.WriteLine("Ingrese una vocal: ");
            char vocalIngresada = char.Parse(Console.ReadLine());

            // Verificar si la vocal ingresada es válida
            if (!vocales.Contains(vocalIngresada))
            {
                Console.WriteLine("Vocal inválida.");
                return;
            }

            // Mostrar al usuario dos palabras que inicien con la vocal ingresada
            string[] palabrasParaVocal = palabras[Array.IndexOf(vocales, vocalIngresada)];
            Console.WriteLine("Dos palabras que inicien con la vocal '{0}' son: {1} y {2}", vocalIngresada, palabrasParaVocal[0], palabrasParaVocal[1]);
        }
    }
}
