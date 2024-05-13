using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notasss
{
    internal class Program
    {
        static void Main()
        {
            int i = 0;
            int aprobadas = 0;
            int desaprobadas = 0;
            double sumaTotal = 0;
            double sumaAprobadas = 0;
            double sumaDesaprobadas = 0;

            Console.WriteLine("Ingrese el numero de notas: ");
            int N = int.Parse(Console.ReadLine());

            while (i < N) 
            {
                Console.WriteLine("Ingrese la nota {0}: ", i + 1);
                double nota = int.Parse(Console.ReadLine());
                sumaTotal += nota;

                if (nota >= 5.0) 
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
            double promedioAprobadas = aprobadas > 0 ? sumaAprobadas / aprobadas :0;
            double promedioDesaprobadas = desaprobadas > 0 ? sumaDesaprobadas / desaprobadas :0;

            Console.WriteLine("Numero de notas desaprobadas: {0}, desaprobadas");
            Console.WriteLine("Numero de notas aprobadas: {0}, aprobadas ");
            Console.WriteLine("Promedio de todas las notas {0}, promedioTotal");
            Console.WriteLine("Promedio de notas aprobadas: {0}, promedioAprobadas");
            Console.WriteLine("Promedio de notas desaprobadas: {0}, promedioDesaprobadas");
            

        }
    }
}
