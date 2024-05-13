using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_1
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Ingrese el tipo de servicio(Basicas, Intermedia, Residenciales):");
            string tipoServicio = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Ingrese las horas trabajadas");
            int horasTrabajadas = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            double costo = CalcularCosto(tipoServicio, horasTrabajadas);

            Console.WriteLine($"El costo total es: {costo}");
        }

        private static double CalcularCosto(string tipoServicio, int horasTrabajadas)
        {
            

            double costo = 0;

            switch (tipoServicio.ToLower())
            {
                case "basicas":
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
                    if(horasTrabajadas > 15)
                    {
                        costo = 15 * 30 + (horasTrabajadas - 15) * 40;
                    }
                    else
                    {
                        costo = horasTrabajadas * 30;
                    }
                    break;
                case "residenciales":
                    if(horasTrabajadas > 20)
                    {
                        costo = 20 * 50 + (horasTrabajadas - 20) * 60;
                    }
                    break;

                default:
                    Console.WriteLine("Tipo de servicio no reconocido");
                    break;
         
            }
            return costo;
        } 
    }
}
/* 
 * servivios Basicas, Intermedios y Residenciales
 * Basicas se cobra a 20 y si pasa 10 se cobran a 25
 * Intermedios se cobra a 30 y si pasa de 15 a 40
 * Resinednciales se cobra a 50 y si pasa de 20 a 60
 * */