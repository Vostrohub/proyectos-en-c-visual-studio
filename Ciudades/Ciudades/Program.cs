using System;
using System.Collections.Generic;

namespace BusquedaDeCiudades
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declarar variables
            int total = 0;
            string nombreCiudad;

            // Leer el número de nombres de ciudades
            Console.WriteLine("Ingrese el número de nombres de ciudades:");
            total = int.Parse(Console.ReadLine());

            // Declarar una lista para almacenar los nombres de ciudades
            List<string> nombres = new List<string>();

            // Leer los nombres de ciudades
            for (int i = 0; i < total; i++)
            {
                Console.WriteLine("Ingrese el nombre de la ciudad #" + (i + 1) + ":");
                nombres.Add(Console.ReadLine());
            }

            // Leer el nombre de la ciudad que se va a buscar
            Console.WriteLine("Ingrese el nombre de la ciudad que desea buscar:");
            nombreCiudad = Console.ReadLine();

            // Buscar la ciudad
            if (nombres.Contains(nombreCiudad))
            {
                Console.WriteLine("El nombre de la ciudad se encuentra en la lista");
            }
            else
            {
                Console.WriteLine("El nombre de la ciudad no se encuentra en la lista");
            }

            Console.WriteLine("Ingresa la ciudad que quiere eliminar");
            string ciudadAEliminar = Console.ReadLine();

            if (nombres.Remove(ciudadAEliminar))
            {
                Console.WriteLine("La ciudad ha sido eliminada de la lista.");
            }
            else
            {
                Console.WriteLine("La ciudad no se encuentra en la lista");
            }

            // Recorrer y mostrar todos los elementos del arreglo después de la eliminación
            foreach (string nombre in nombres)
            {
                Console.WriteLine(nombre);
            }

            Console.WriteLine("La ciudad que quiere agregar");
            string ciudadAAgregar = Console.ReadLine();

            if (!nombres.Contains(ciudadAAgregar))
            {
                nombres.Add(ciudadAAgregar);
                Console.WriteLine("La ciudad ha sido agregada a la lista.");
            }
            else
            {
                Console.WriteLine("La ciudad ya está en la lista.");
            }

            // Recorrer y mostrar todos los elementos del arreglo después de agregar una ciudad
            foreach (string nombre in nombres)
            {
                Console.WriteLine(nombre);
            }
        }
    }
}
