using System;

namespace DiasDeLaSemana
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solicitamos al usuario un número del 1 al 7
            Console.WriteLine("Ingrese un número del 1 al 7:");
            int numero = int.Parse(Console.ReadLine());

            // Utilizamos un switch para verificar el número digitado
            string dia = "Número inválido";
            switch (numero)
            {
                case 1:
                    dia = "Domingo";
                    break;
                case 2:
                    dia = "Lunes";
                    break;
                case 3:
                    dia = "Martes";
                    break;
                case 4:
                    dia = "Miércoles";
                    break;
                case 5:
                    dia = "Jueves";
                    break;
                case 6:
                    dia = "Viernes";
                    break;
                case 7:
                    dia = "Sábado";
                    break;
                default:
                    break;
            }

            // Mostramos el día de la semana correspondiente
            Console.WriteLine($"El día de la semana correspondiente es {dia}");
        }
    }
}
