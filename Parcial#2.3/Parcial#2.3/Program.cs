using System;

class Program
{
    static void Main()
    {
        // Inicializar contadores de votos
        int votesA = 0, votesB = 0, nullVotes = 0, totalVotes;

        // Solicitar al usuario el número total de votantes
        Console.WriteLine("Ingrese el número total de votantes: ");
        totalVotes = Convert.ToInt32(Console.ReadLine());

        // Leer el voto de cada votante
        for (int i = 0; i < totalVotes; i++)
        {
            Console.WriteLine("Ingrese el voto del votante " + (i + 1) + ": ");
            int vote = Convert.ToInt32(Console.ReadLine());

            // Contar los votos para cada candidato y los votos nulos
            if (vote == 1)
            {
                votesA++;
            }
            else if (vote == 2)
            {
                votesB++;
            }
            else
            {
                nullVotes++;
            }
        }

        // Mostrar el número de votos para cada candidato y el número de votos nulos
        Console.WriteLine("Votos para A: " + votesA);
        Console.WriteLine("Votos para B: " + votesB);
        Console.WriteLine("Votos nulos: " + nullVotes);

        // Determinar el candidato ganador
        if (votesA > votesB)
        {
            Console.WriteLine("El candidato ganador es A");
        }
        else if (votesB > votesA)
        {
            Console.WriteLine("El candidato ganador es B");
        }
        else
        {
            Console.WriteLine("Hay un empate entre los candidatos A y B");
        }
    }
}
