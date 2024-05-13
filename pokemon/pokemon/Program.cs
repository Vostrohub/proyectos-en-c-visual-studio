using System;
using System;

namespace Pokemon
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public Posicion Posicion { get; set; }
        public Pokemon PokemonActual { get; set; }

        public Jugador(string nombre)
        {
            this.Nombre = nombre;
            this.Nivel = 1;
            this.Posicion = new Posicion(0, 0);
            this.PokemonActual = null;
        }
    }

    public class Pokemon
    {
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public int Salud { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }

        public Pokemon(string nombre, int tipo, int salud, int ataque, int defensa)
        {
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Salud = salud;
            this.Ataque = ataque;
            this.Defensa = defensa;
        }
    }

    public class Mapa
    {
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public Jugador Jugador { get; set; }

        public Mapa(int ancho, int alto)
        {
            this.Ancho = ancho;
            this.Alto = alto;
            this.Jugador = null;
        }

        public void AgregarJugador(Jugador jugador)
        {
            Jugador = jugador;
        }
    }

    public class Posicion
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Posicion(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class Interfaz
    {
        public static void MostrarMenuPrincipal()
        {
            Console.WriteLine("Bienvenido al juego de Pokémon");
            Console.WriteLine("1. Mover al jugador");
            Console.WriteLine("2. Enfrentar a un Pokémon");
            Console.WriteLine("3. Capturar un Pokémon");
            Console.WriteLine("q. Salir del juego");
        }

        public static void MostrarMapa(Mapa mapa)
        {
            Console.WriteLine($"Mapa - Jugador en posición ({mapa.Jugador.Posicion.X}, {mapa.Jugador.Posicion.Y})");
        }

        public static void MostrarEstadisticasJugador(Jugador jugador)
        {
            Console.WriteLine($"Jugador: {jugador.Nombre} - Nivel {jugador.Nivel}");
        }

        public static void MostrarEstadisticasPokemon(Pokemon pokemon)
        {
            Console.WriteLine($"Pokémon: {pokemon.Nombre} - Salud: {pokemon.Salud} - Ataque: {pokemon.Ataque} - Defensa: {pokemon.Defensa}");
        }

        public static void MostrarBatalla(Pokemon pokemonJugador, Pokemon pokemonSalvaje)
        {
            Console.WriteLine($"Batalla entre {pokemonJugador.Nombre} y {pokemonSalvaje.Nombre}");
            // Implementa la lógica para mostrar detalles de la batalla
        }
    }

    public class Program
    {
        public static Jugador jugador;
        public static Mapa mapa;

        public static void Main()
        {
            IniciarJuego();
            BuclePrincipal();
        }

        public static void IniciarJuego()
        {
            // Cargar datos
            // ...

            // Crear jugador
            jugador = new Jugador("Ash Ketchum");

            // Crear mapa
            mapa = new Mapa(10, 10);
            mapa.AgregarJugador(jugador);

            // Mostrar menú principal
            Interfaz.MostrarMenuPrincipal();
        }

        public static void MoverJugador(int x, int y)
        {
            // Actualizar la posición del jugador
            jugador.Posicion.X = x;
            jugador.Posicion.Y = y;

            // Comprobar si el jugador está en un área segura
            // ...

            // Si el jugador está en un área segura,
            // ...

            // Si el jugador está en un área peligrosa,
            // ...
        }

        public static void EnfrentarPokemon()
        {
            // Crear Pokémon salvaje
            Pokemon pokemonSalvaje = new Pokemon("Pikachu", 1, 100, 10, 10);

            // Mostrar batalla
            Interfaz.MostrarBatalla(jugador.PokemonActual, pokemonSalvaje);

            // Jugar batalla
            // ...

            // Actualizar estado del jugador
            // ...
        }

        public static void CapturarPokemon()
        {
            // ...
        }

        public static void BuclePrincipal()
        {
            while (true)
            {
                // Actualizar la interfaz
                Interfaz.MostrarMapa(mapa);
                Interfaz.MostrarEstadisticasJugador(jugador);

                // Leer la entrada del jugador
                string entrada = Console.ReadLine();

                // Ejecutar la acción del jugador
                switch (entrada)
                {
                    case "1":
                        Console.WriteLine("Ingresa la dirección de movimiento (ej. 'derecha', 'izquierda', 'arriba', 'abajo'):");
                        string direccion = Console.ReadLine().ToLower();

                        // Mover al jugador en función de la dirección
                        switch (direccion)
                        {
                            case "derecha":
                                MoverJugador(jugador.Posicion.X + 1, jugador.Posicion.Y);
                                break;
                            case "izquierda":
                                MoverJugador(jugador.Posicion.X - 1, jugador.Posicion.Y);
                                break;
                            case "arriba":
                                MoverJugador(jugador.Posicion.X, jugador.Posicion.Y - 1);
                                break;
                            case "abajo":
                                MoverJugador(jugador.Posicion.X, jugador.Posicion.Y + 1);
                                break;
                            default:
                                Console.WriteLine("Dirección no válida.");
                                break;
                        }
                        break;
                    case "2":
                        EnfrentarPokemon();
                        break;
                    case "3":
                        CapturarPokemon();
                        break;
                    case "q":
                        Console.WriteLine("Gracias por jugar. ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Entrada no válida. Introduce una opción válida.");
                        break;
                }
            }
        }
    }
}
