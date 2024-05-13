using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
class Movimiento
{
    public string Nombre { get; private set; }
    public string Tipo { get; private set; }
    public int Poder { get; private set; }

    public Movimiento(string nombre, string tipo, int poder)
    {
        Nombre = nombre;
        Tipo = tipo;
        Poder = poder;
    }
}

[Serializable]
class Pokémon
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Nivel { get; set; }
    public int PS { get; set; }
    public int Ataque { get; set; }
    public int Defensa { get; set; }
    public int Velocidad { get; set; }
    public List<Movimiento> Movimientos { get; private set; }

    public Pokémon(string nombre, string tipo, int nivel, int ps, int ataque, int defensa, int velocidad, List<Movimiento> movimientos)
    {
        Nombre = nombre;
        Tipo = tipo;
        Nivel = nivel;
        PS = ps;
        Ataque = ataque;
        Defensa = defensa;
        Velocidad = velocidad;
        Movimientos = movimientos;
    }
}

class Juego
{
    private Pokémon jugadorPokémon;
    private Pokémon oponentePokémon;
    private int puntuación;

    private List<Pokémon> pokémonDisponibles;
    private Random random;

    public Juego()
    {
        pokémonDisponibles = new List<Pokémon>
        {
            // Inicializar la lista de Pokémon disponibles...
            new Pokémon("Pikachu", "Eléctrico", 5, 30, 15, 10, 20, new List<Movimiento> { new Movimiento("Impactrueno", "Eléctrico", 20), new Movimiento("Placaje", "Normal", 15) }),
            new Pokémon("Bulbasaur", "Planta/Veneno", 5, 32, 12, 15, 18, new List<Movimiento> { new Movimiento("Látigo Cepa", "Planta", 18), new Movimiento("Gruñido", "Normal", 10) }),
            new Pokémon("Squirtle", "Agua", 5, 28, 17, 14, 22, new List<Movimiento> { new Movimiento("Burbuja", "Agua", 15), new Movimiento("Arañazo", "Normal", 20) }),
            new Pokémon("Charmander", "Fuego", 5, 25, 18, 8, 15, new List<Movimiento> { new Movimiento("Ascuas", "Fuego", 25), new Movimiento("Garra Arañazo", "Normal", 20) }),
            new Pokémon("Jigglypuff", "Normal/Hada", 5, 28, 12, 10, 20, new List<Movimiento> { new Movimiento("Canto", "Normal", 0), new Movimiento("Destructor", "Normal", 30) }),
            new Pokémon("Geodude", "Roca/Tierra", 5, 35, 20, 15, 10, new List<Movimiento> { new Movimiento("Lanzarrocas", "Roca", 22), new Movimiento("Terremoto", "Tierra", 28) }),
            new Pokémon("Psyduck", "Agua", 5, 30, 16, 12, 18, new List<Movimiento> { new Movimiento("Confusión", "Psíquico", 18), new Movimiento("Pistón Agua", "Agua", 22) }),
            new Pokémon("Machop", "Lucha", 5, 25, 18, 15, 12, new List<Movimiento> { new Movimiento("Karate Chop", "Lucha", 20), new Movimiento("Doble Filo", "Normal", 30) }),
            new Pokémon("Meowth", "Normal", 5, 26, 15, 10, 18, new List<Movimiento> { new Movimiento("Látigo", "Normal", 18), new Movimiento("Zarpazo", "Normal", 22) }),
            new Pokémon("Abra", "Psíquico", 5, 20, 10, 8, 25, new List<Movimiento> { new Movimiento("Rayo Confuso", "Psíquico", 15), new Movimiento("Psicorrayo", "Psíquico", 25) }),
            new Pokémon("Gastly", "Fantasma/Veneno", 5, 22, 16, 12, 18, new List<Movimiento> { new Movimiento("Lengüetazo", "Fantasma", 18), new Movimiento("Bola Sombra", "Fantasma", 25) }),
            // Agregar más Pokémon según sea necesario
        };

        random = new Random();
    }

    public void Iniciar()
    {
        Console.WriteLine("¡Bienvenido al juego de Pokémon!");

        jugadorPokémon = SeleccionarPokémonAleatorio();
        oponentePokémon = SeleccionarPokémonAleatorio();

        puntuación = 0;
    }

    private Pokémon SeleccionarPokémonAleatorio()
    {
        return pokémonDisponibles[random.Next(pokémonDisponibles.Count)];
    }

    private void SeleccionarMovimientosAleatorios(Pokémon pokémon)
    {
        var movimientosAleatorios = pokémonDisponibles[random.Next(pokémonDisponibles.Count)].Movimientos;
        pokémon.Movimientos.AddRange(movimientosAleatorios.Take(4));
    }

    public void MostrarMenú()
    {
        Console.WriteLine("\nMenú Principal:");
        Console.WriteLine("_________________________");
        Console.WriteLine("1. Jugar");
        Console.WriteLine("_________________________");
        Console.WriteLine("2. Ver Equipo Pokémon");
        Console.WriteLine("_________________________");
        Console.WriteLine("3. Ver Puntuación");
        Console.WriteLine("_________________________");
        Console.WriteLine("4. Salir");
        Console.WriteLine("-------------------------");
    }

    public void Jugar()
    {
        bool salir = false;

        while (!salir)
        {
            MostrarMenú();

            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            int opcionInt;
            if (int.TryParse(opcion, out opcionInt))
            {
                switch (opcionInt)
                {
                    case 1:
                        Console.WriteLine("\n¡Comencemos el juego!");
                        Luchar();
                        break;
                    case 2:
                        MostrarEquipoPokémon();
                        break;
                    case 3:
                        MostrarPuntuacion();
                        break;
                    case 4:
                        Console.WriteLine("Gracias por jugar. ¡Hasta luego!");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
            }
        }
    }

    public void Luchar()
    {
        Console.WriteLine($"\n¡Un salvaje {oponentePokémon.Nombre} apareció!");

        while (jugadorPokémon.PS > 0 && oponentePokémon.PS > 0)
        {
            Console.Clear();
            MostrarPelea(jugadorPokémon, oponentePokémon);

            Console.WriteLine("\n¡Es tu turno!");
            MostrarMovimientos(jugadorPokémon);

            int opcionMovimiento = ElegirMovimiento();
            Movimiento movimientoJugador = jugadorPokémon.Movimientos[opcionMovimiento - 1];
            int danioJugador = CalcularDanio(movimientoJugador.Poder, oponentePokémon.Defensa);
            int danioOponente = CalcularDanio(oponentePokémon.Movimientos[random.Next(oponentePokémon.Movimientos.Count)].Poder, jugadorPokémon.Defensa);

            oponentePokémon.PS -= danioJugador;
            jugadorPokémon.PS -= danioOponente;

            Console.WriteLine($"\nHas usado {movimientoJugador.Nombre} y has causado {danioJugador} puntos de daño a {oponentePokémon.Nombre}.");
            Console.WriteLine($"{oponentePokémon.Nombre} te ha atacado con un movimiento aleatorio y te ha causado {danioOponente} puntos de daño.");

            MostrarPokémon(jugadorPokémon, "Jugador");
            MostrarPokémon(oponentePokémon, "Oponente");

            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine();
        }

        Console.Clear();
        MostrarPelea(jugadorPokémon, oponentePokémon);
        if (jugadorPokémon.PS <= 0)
        {
            Console.Clear();
            MostrarPelea(jugadorPokémon, oponentePokémon);
            Console.WriteLine("\n¡Has sido derrotado! Game Over.");
        }
        else
        {
            Console.Clear();
            MostrarPelea(jugadorPokémon, oponentePokémon);
            Console.WriteLine($"\n¡Has derrotado al {oponentePokémon.Nombre} salvaje! ¡Felicidades!");
            puntuación += 100;
            MostrarPuntuacion();
        }

        jugadorPokémon = SeleccionarPokémonAleatorio();
        oponentePokémon = SeleccionarPokémonAleatorio();
    }

    private int CalcularDanio(int poderAtaque, int defensa)
    {
        int danio = poderAtaque - defensa;
        return danio > 0 ? danio : 0;
    }

    public void MostrarEquipoPokémon()
    {
        Console.WriteLine("\nEquipo Pokémon:");
        MostrarPokémon(jugadorPokémon, "Jugador");
        Console.WriteLine("------------------------|");
    }

    public void MostrarPuntuacion()
    {
        Console.WriteLine($"\nPuntuación Actual: {puntuación}");
        Console.WriteLine("------------------------|");
    }

    public void MostrarPokémon(Pokémon pokémon, string jugador)
    {
        Console.WriteLine($"\n{jugador}'s Pokémon - {pokémon.Nombre}");
        Console.WriteLine($"Nivel: {pokémon.Nivel}");
        Console.WriteLine($"PS: {pokémon.PS}");
        Console.WriteLine($"Ataque: {pokémon.Ataque}");
        Console.WriteLine($"Defensa: {pokémon.Defensa}");
        Console.WriteLine($"Velocidad: {pokémon.Velocidad}");
        Console.WriteLine($"Tipo: {pokémon.Tipo}");
        Console.WriteLine("Movimientos:");
        MostrarMovimientos(pokémon);
    }

    public void MostrarMovimientos(Pokémon pokémon)
    {
        for (int i = 0; i < pokémon.Movimientos.Count; i++)
        {
            Movimiento movimiento = pokémon.Movimientos[i];
            Console.WriteLine($"{i + 1}. {movimiento.Nombre} (Tipo: {movimiento.Tipo}, Poder: {movimiento.Poder})");
        }
    }

    public void MostrarPelea(Pokémon jugador, Pokémon oponente)
    {
        Console.WriteLine("Batalla Pokémon");
        Console.WriteLine("---------------");
        Console.WriteLine($"{jugador.Nombre} (PS: {jugador.PS}) vs. {oponente.Nombre} (PS: {oponente.PS})");
        Console.WriteLine("   " + new string('-', 46));
        Console.WriteLine("   |" + new string(' ', 15) + "|" + new string(' ', 29) + "|");
        Console.WriteLine($"   |{new string(' ', 1)}{jugador.Nombre}{new string(' ', 7)}|{new string(' ', 14)}{oponente.Nombre}{new string(' ', 5)}|");
        Console.WriteLine("   |" + new string(' ', 15) + "|" + new string(' ', 29) + "|");
        Console.WriteLine("   " + new string('-', 46));
        Console.WriteLine("\nPresiona Enter para comenzar la pelea...");
        Console.ReadLine();
    }

    private int ElegirMovimiento()
    {
        Console.Write("Elige un movimiento: ");
        if (int.TryParse(Console.ReadLine(), out int opcionMovimiento) && opcionMovimiento >= 1 && opcionMovimiento <= jugadorPokémon.Movimientos.Count)
        {
            return opcionMovimiento;
        }
        else
        {
            Console.WriteLine("\nOpción de movimiento no válida. Inténtalo de nuevo.");
            return ElegirMovimiento();
        }
    }

    public static void Main()
    {
        Juego juego = new Juego();
        juego.Iniciar();
        juego.Jugar();
    }
}
