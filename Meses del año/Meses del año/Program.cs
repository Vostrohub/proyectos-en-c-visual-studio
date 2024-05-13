using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meses_del_año
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solicita al usuario un numero del 1 al 12
            Console.WriteLine("Ingresa un numero del 1 al 12: ");
            int numero = int.Parse(Console.ReadLine());

            string Mes = "Numero invalido";
            switch (numero) 
            {
                case 1:
                    Mes = "Enero";
                    break;

                case 2:
                    Mes = "Febrero";
                    break;

                case 3:
                    Mes = "Marzo";
                    break;

                case 4:
                    Mes = "Abril";
                    break;

                case 5:
                    Mes = "Mayo";
                    break;

                case 6:
                    Mes = "Junio";
                    break;

                case 7:
                    Mes = "Julio";
                    break;

                case 8:
                    Mes = "Agosto";
                    break;

                case 9:
                    Mes = "Septiembre";
                    break;

                case 10:
                    Mes = "Octubre";
                    break;

                case 11:
                    Mes = "Noviembre";
                    break;

                case 12:
                    Mes = "Diciembre";
                    break;
            }
            //se muestra el mes del año correspondiente
            Console.WriteLine($"El mes del año correspondiente es {Mes}");
        }
    }
}
