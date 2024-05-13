using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Ingrese el tipo de servicio (Básica, Intermedia, Residencial):");
        string tipoServicio = Console.ReadLine();

        Console.WriteLine("Ingrese las horas trabajadas:");
        int horasTrabajadas = Convert.ToInt32(Console.ReadLine());

        double costo = CalcularCosto(tipoServicio, horasTrabajadas);

        Console.WriteLine($"El costo total es: {costo}");
    }

    public static double CalcularCosto(string tipoServicio, int horasTrabajadas)
    {
        double costo = 0;

        switch (tipoServicio.ToLower())
        {
            case "básica":
                if (horasTrabajadas > 10)
                {
                    costo = 10 * 20 + (horasTrabajadas - 10) * 25;
                }
                else
                {
                    costo = horasTrabajadas * 20;
                }
                break;

            case "intermedia":
                if (horasTrabajadas > 15)
                {
                    costo = 15 * 30 + (horasTrabajadas - 15) * 40;
                }
                else
                {
                    costo = horasTrabajadas * 30;
                }
                break;

            case "residencial":
                if (horasTrabajadas > 20)
                {
                    costo = 20 * 50 + (horasTrabajadas - 20) * 60;
                }
                else
                {
                    costo = horasTrabajadas * 50;
                }
                break;

            default:
                Console.WriteLine("Tipo de servicio no reconocido.");
                break;
        }

        return costo;
    }
}
