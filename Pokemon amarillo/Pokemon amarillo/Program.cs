using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_amarillo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crea el jugador.
            Player player = new Player();
            player.Name = "Ash";
            player.Level = 1;

            // Crea el equipo del jugador.
            List<Pokemon> team = new List<Pokemon>();
            team.Add(new pokemon("Pikachu", Type.Electric, 30, 50, 50, 90));

            // Crea el mapa del juego.
            Map map = new Map();
            map.Tiles = new List<Tile>();
            map.GameObjects = new List<GameObject>();

            // Crea el motor de juego.
            GameEngine gameEngine = new GameEngine();

            // Inicia el juego.
            gameEngine.Run(player, team, map);
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public List<Pokemon> Team { get; set; }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
    }

    public class Map
    {
        public List<Tile> Tiles { get; set; }
        public List<GameObject> GameObjects { get; set; }
    }

    public class GameEngine
    {
        public void Run(Player player, List<Pokemon> team, Map map)
        {
            // Bucle principal del juego.
            while (true)
            {
                // Actualiza el estado del juego.
                player.Update();
                team.ForEach(x => x.Update());
                map.Update();

                // Renderiza los gráficos.
                map.Render();
                team.ForEach(x => x.Render());

                // Reproduce el sonido.
                map.PlaySounds();
                team.ForEach(x => x.PlaySounds());

                // Comprueba si el juego ha terminado.
                if (player.IsDead)
                {
                    // El jugador ha perdido.
                    break;
                }

                // Comprueba si el jugador ha ganado.
                if (player.HasWon)
                {
                    // El jugador ha ganado.
                    break;
                }
            }
        }
    }

    public enum Type
    {
        Normal,
        Fire,
        Water,
        Electric,
        Grass,
        Ice,
        Fighting,
        Poison,
        Ground,
        Flying,
        Psychic,
        Bug,
        Rock,
        Ghost,
        Dragon,
        Dark,
        Fairy
    }

    public class Tile
    {
        public Type Type { get; set; }
        public bool IsWalkable { get; set; }
    }

    public class GameObject
    {
        public Type Type { get; set; }
        public Position Position { get; set; }
    }

    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}