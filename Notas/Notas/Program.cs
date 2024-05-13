using System;

class Program
{
    static void Main()
    {
        int i = 0;
        int aprobadas = 0;
        int desaprobadas = 0;
        double sumaTotal = 0;
        double sumaAprobadas = 0;
        double sumaDesaprobadas = 0;

        Console.Write("Ingrese el número de notas: ");
        int N = Convert.ToInt32(Console.ReadLine());

        while (i < N)
        {
            Console.Write("Ingrese la nota {0}: ", i + 1);
            double nota = Convert.ToDouble(Console.ReadLine());
            sumaTotal += nota;

            if (nota >= 70)
            {
                aprobadas++;
                sumaAprobadas += nota;
            }
            else
            {
                desaprobadas++;
                sumaDesaprobadas += nota;
            }

            i++;
        }

        double promedioTotal = sumaTotal / N;
        double promedioAprobadas = aprobadas > 0 ? sumaAprobadas / aprobadas : 0;
        double promedioDesaprobadas = desaprobadas > 0 ? sumaDesaprobadas / desaprobadas : 0;

        Console.WriteLine("Número de notas desaprobadas: {0}", desaprobadas);
        Console.WriteLine("Número de notas aprobadas: {0}", aprobadas);
        Console.WriteLine("Promedio de todas las notas: {0}", promedioTotal);
        Console.WriteLine("Promedio de notas aprobadas: {0}", promedioAprobadas);
        Console.WriteLine("Promedio de notas desaprobadas: {0}", promedioDesaprobadas);
    }
}
