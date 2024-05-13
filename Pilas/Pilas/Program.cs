// Importamos las bibliotecas necesarias
using System;
using System.Collections;

class MainClass
{
    // Método principal del programa
    static void Main()
    {
        // Llamamos al método StringReverse y mostramos el resultado en la consola
        Console.WriteLine(StringReverse("hola como va todo cracks!"));
    }

    // Método que recibe una cadena de texto y devuelve la misma cadena invertida
    public static string StringReverse(string cadena)
    {
        // Variable para almacenar el resultado
        string response = "";
        // Convertimos la cadena de texto en un array de caracteres
        char[] caracteres = cadena.ToCharArray();
        // Creamos una nueva pila
        Stack miPila = new Stack();

        // Recorremos el array de caracteres
        foreach (var item in caracteres)
        {
            // Apilamos cada caracter en la pila
            miPila.Push(item);
        }

        // Utilizamos un bucle for para desapilar los elementos
        for (int i = 0; i < caracteres.Length; i++)
        {
            // Desapilamos un caracter y lo añadimos al resultado
            response += miPila.Pop();
        }

        // Devolvemos el resultado
        return response;
    }
}
