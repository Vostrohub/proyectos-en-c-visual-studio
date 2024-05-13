using System;

class Program
{
    static void Main()
    {
        // Inicializar contadores de vocales y palabras
        int vowelCount = 0, wordCount = 0;
        char ch;
        bool isWord = false;

        // Solicitar al usuario que ingrese el texto
        Console.WriteLine("Ingrese el texto: ");

        // Leer el texto carácter por carácter hasta que se encuentre el símbolo '$'
        while ((ch = (char)Console.Read()) != '$')
        {
            // Convertir el carácter a minúsculas
            ch = Char.ToLower(ch);

            // Si el carácter es una vocal, incrementar el contador de vocales
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            {
                vowelCount++;
            }

            // Si el carácter es un espacio en blanco o un punto, y la palabra anterior no ha sido contada, incrementar el contador de palabras
            if (Char.IsWhiteSpace(ch) || ch == '.')
            {
                if (isWord)
                {
                    wordCount++;
                    isWord = false;
                }
            }
            // Si el carácter no es un espacio en blanco ni un punto, se considera que estamos en una palabra
            else
            {
                isWord = true;
            }
        }

        // Imprimir el número de vocales y palabras
        Console.WriteLine("Número de vocales: " + vowelCount);
        Console.WriteLine("Número de palabras: " + wordCount);
    }
}
