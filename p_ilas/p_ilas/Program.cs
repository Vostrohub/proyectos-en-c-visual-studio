using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_ilas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string palabra;

            Stack miPila = new Stack();
            miPila.Push("Hola");
            miPila.Push("Hoy");
            miPila.Push("yo");

            for (byte i = 0 ; i < 3  ; i++) 
            {
                palabra = (string)miPila.Pop();
                Console.WriteLine(palabra);

            }

        }
    }
}
