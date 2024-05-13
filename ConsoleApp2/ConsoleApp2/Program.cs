using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;



class Program
{
    static void Main()
    {
        Juego juego = new Juego();
        juego.Jugar();
    }
}

[Serializable]
class Movimiento
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Poder { get; set; }

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
    public List<Movimiento> Movimientos { get; set; }
    public string ArteASCII { get; set; }


    public Pokémon(string nombre, string tipo, int nivel, int ps, int ataque, int defensa, int velocidad, List<Movimiento> movimientos, string arteASCII)
    {
        Nombre = nombre;
        Tipo = tipo;
        Nivel = nivel;
        PS = ps;
        Ataque = ataque;
        Defensa = defensa;
        Velocidad = velocidad;
        Movimientos = movimientos;
        ArteASCII = arteASCII;
    }
}

[Serializable]
class Juego
{
    private Pokémon jugadorPokémon;
    private Pokémon oponentePokémon;
    private int puntuación;

    private List<Pokémon> pokémonDisponibles;
    private Random random;

    public Juego()
    {
        // Inicializar la lista de Pokémon disponibles
        pokémonDisponibles = new List<Pokémon>
        {
            new Pokémon("Pikachu", "Eléctrico", 5, 30, 15, 10, 20, new List<Movimiento> { new Movimiento("Impactrueno", "Eléctrico", 20), new Movimiento("Placaje", "Normal", 15) }, pikachuASCII),
            new Pokémon("Bulbasaur", "Planta/Veneno", 5, 32, 12, 15, 18, new List<Movimiento> { new Movimiento("Látigo Cepa", "Planta", 18), new Movimiento("Gruñido", "Normal", 10) }, BulbasaurASCII),
            new Pokémon("Squirtle", "Agua", 5, 28, 17, 14, 22, new List<Movimiento> { new Movimiento("Burbuja", "Agua", 15), new Movimiento("Arañazo", "Normal", 20) },SquirtleASCII  ),
            new Pokémon("Charmander", "Fuego", 5, 25, 18, 8, 15, new List<Movimiento> { new Movimiento("Ascuas", "Fuego", 25), new Movimiento("Garra Arañazo", "Normal", 20) },CharmanderASCII ),
            new Pokémon("Jigglypuff", "Normal/Hada", 5, 28, 12, 10, 20, new List<Movimiento> { new Movimiento("Canto", "Normal", 0), new Movimiento("Destructor", "Normal", 30) },JigglypuffASCII),
            new Pokémon("Geodude", "Roca/Tierra", 5, 35, 20, 15, 10, new List<Movimiento> { new Movimiento("Lanzarrocas", "Roca", 22), new Movimiento("Terremoto", "Tierra", 28) },GeodudeASCII),
            new Pokémon("Psyduck", "Agua", 5, 30, 16, 12, 18, new List<Movimiento> { new Movimiento("Confusión", "Psíquico", 18), new Movimiento("Pistón Agua", "Agua", 22) }, PsyduckASCII),
            new Pokémon("Machop", "Lucha", 5, 25, 18, 15, 12, new List<Movimiento> { new Movimiento("Karate Chop", "Lucha", 20), new Movimiento("Doble Filo", "Normal", 30) }, MachopASCII),
            new Pokémon("Meowth", "Normal", 5, 26, 15, 10, 18, new List<Movimiento> { new Movimiento("Látigo", "Normal", 18), new Movimiento("Zarpazo", "Normal", 22) }, MeowthASCII),
            new Pokémon("Abra", "Psíquico", 5, 20, 10, 8, 25, new List<Movimiento> { new Movimiento("Rayo Confuso", "Psíquico", 15), new Movimiento("Psicorrayo", "Psíquico", 25) }, AbraASCII),
            new Pokémon("Gastly", "Fantasma/Veneno", 5, 22, 16, 12, 18, new List<Movimiento> { new Movimiento("Lengüetazo", "Fantasma", 18), new Movimiento("Bola Sombra", "Fantasma", 25) }, GastlyASCII),
            // Agregar más Pokémon según sea necesario
        };
        random = new Random();
    }

    // Aqui las imagenes de los pokemones con arte ACSII 

    string pikachuASCII = @"
       \:.             .:/
        \``._________.''/ 
         \             / 
 .--.--, / .':.   .':. \
/__:  /  | '::' . '::' |
   / /   |`.   ._.   .'|
  / /    |.'         '.|
 /___-_-,|.\  \   /  /.|
      // |''\.;   ;,/ '|
      `==|:=         =:|
         `.          .'
           :-._____.-:
          `''       `''";


    string BulbasaurASCII = @"
          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⣿⣆⣠⣴⣶⡄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣠⣶⣿⠋⢹⣿⠟⣹⣿⣥⣤⡀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣤⣴⣶⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠛⠛⢉⣠⣴⣿⠏⠀⣿⡟⣽⡿⠃⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣶⡿⠟⠋⠉⠀⠀⠀⠀⠀⢀⣀⣤⣤⣤⣶⣶⠀⠘⠛⠛⠉⠀⠀⢰⣿⢱⣿⠃⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⡿⠋⠀⠀⠀⠀⠀⠀⠀⣠⣾⡿⠛⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠸⣿⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣠⣿⠟⠛⠿⣷⣶⣤⣀⣤⣤⣤⣤⣤⣿⣟⣀⣀⠀⠀⠀⣀⣠⣤⣾⣿⣿⣶⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣷⠀⢿⣧⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢰⣿⠋⠀⠀⣶⡿⠿⠛⠋⠉⠉⠉⠉⠉⠉⠙⠛⠛⠻⣿⣿⠿⠛⠉⠉⠀⠈⢻⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠘⣿⣧⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣿⣿⣶⠆⠀⠀⠀⠀⠀⣀⣤⣤⣶⡶⠶⢿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡀⠘⢿⣷⡀⠀⠀
⠀⠀⠀⠀⣸⣿⡿⠁⠀⠀⠀⢠⣶⣿⠟⠋⠉⠀⢀⣴⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣷⠀⠈⢿⣷⡀⠀
⠀⠀⠀⣴⣿⠋⠀⠀⠀⠀⣀⡈⢿⣷⣄⣀⣴⣾⠿⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠀⠈⢿⣷⠀
⠀⠀⣼⣿⣿⣿⣆⣤⡄⣿⣿⡇⠀⠈⠛⠛⠋⠁⠀⠀⠀⣤⡄⠀⢀⣠⣤⣤⣀⠀⠀⠀⠀⠀⠈⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠘⣿⡆
⠀⣰⣿⣿⣿⣿⣿⣿⡇⠿⠿⠃⠀⢀⣠⣶⣶⠀⠀⢀⣾⡟⠁⣴⣾⣿⡿⠙⢿⣷⡀⠀⠀⠀⠀⢹⣿⠻⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⢻⣧
⢀⣿⣿⢿⣿⣿⣿⠿⠇⠀⠀⠀⣤⣿⠟⢹⣿⠀⠀⢸⣿⢀⣾⡿⢹⣿⢱⣿⣿⣿⣷⠀⠀⠀⠀⢸⣿⠀⣨⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⢀⡘⠋⠀⠀⠀⢸⣿
⢸⣿⡟⢸⣿⣿⣿⠀⠀⠀⠀⠀⠙⢿⣷⣼⡟⠀⠀⠈⠁⣸⣿⠀⢸⡟⢸⣇⣸⡯⣿⡇⠀⠀⠀⠈⣿⠀⣿⣯⠈⠛⢿⣷⣤⡀⠀⣀⣴⣿⠋⠀⠀⠀⠀⢸⣿
⣿⡿⣷⣼⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⠀⣿⡇⠀⢸⣿⠘⢿⣿⠃⢸⡇⠀⠀⠀⠀⠿⠀⠘⣿⣦⠀⠀⠈⠻⣿⣿⣟⠋⠁⠀⠀⠀⠀⠀⣿⡏
⣿⣧⣍⠛⠿⠿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣧⣀⣸⣿⣦⣤⣶⣾⢿⣇⠀⠀⠀⠀⠀⠀⠀⠈⢿⣧⠀⠀⠀⠘⣿⢿⣷⣄⠀⠀⠀⢀⣼⣿⠃
⢻⣿⣿⣷⣤⣄⠀⢰⣦⠀⠀⢀⣤⡄⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⢉⣠⣤⣾⡿⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⠿⠶⠶⠾⠿⠀⠙⢿⣷⣤⣶⣿⡿⠁⠀
⠀⠙⠿⣿⣿⣿⣿⣿⣿⣦⣤⣌⣉⣁⣀⣀⣠⣤⣤⣤⣤⣤⣤⣶⣶⣶⣿⣿⠟⠋⠁⠀⢀⣼⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣿⡟⠁⠀⠀⠀
⠀⠀⠀⠈⠛⠿⣿⣿⣿⣿⣯⣍⣉⠉⠉⠉⠉⠉⠉⠉⠉⢁⣠⣴⣿⠟⠋⠁⠀⢀⣠⣴⣿⠟⠁⠀⠀⠀⠀⠀⢸⣿⠀⣠⣶⠆⢀⣀⠀⠀⠈⢻⣷⡀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠈⣿⠻⣿⣿⣿⣿⣿⣶⣶⣶⣶⣶⣶⠿⠟⠛⠉⢀⣀⣤⣴⣶⣿⣿⠋⠀⠀⣀⡀⠀⠀⠀⠀⠘⣿⣾⣟⣥⣾⡿⣿⡇⠀⠀⠈⣿⡇⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣿⡄⠀⣈⣽⣿⡻⠿⢿⣷⣶⣶⣶⠿⠿⠿⠿⠛⠛⠉⠉⣿⣿⠏⠀⣴⣿⢿⣇⠀⠀⠀⠀⢸⣿⣿⣿⠟⠁⠀⢹⡇⠀⠀⠀⢸⣷⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣿⣧⣾⠟⠋⢿⡇⠀⠈⠻⢿⣦⣄⡀⠀⠀⠀⠀⠀⠀⢠⣿⣷⣾⢿⣿⠿⠿⠟⠀⠀⠀⠀⣼⡿⠈⢿⣧⡀⠀⢸⣧⠀⠀⠀⢸⣿⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠸⣿⡏⠀⢀⣼⡿⠀⠀⠀⠀⠉⢻⣿⣷⣶⣤⣤⣀⣀⣾⡿⠋⠁⣾⡏⠀⠀⠀⠀⠀⠀⣼⣿⠃⠀⠈⠻⢿⣶⡿⠏⠀⠀⠀⣸⡿⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⡶⠾⠟⠁⠀⠀⠀⠀⢠⣿⠟⠀⠈⢿⣿⣛⢻⣿⠁⠀⢰⣿⠁⠀⠀⠀⠀⢀⣼⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⠇⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣷⣤⣄⠀⣀⡀⠀⣰⣿⠟⠀⠀⠀⠀⢹⣿⣿⣿⣷⣶⡿⠋⠀⠀⠀⠀⣠⣾⡿⠉⠹⣿⣄⡀⠀⠀⠀⠀⠀⠀⢀⣾⡿⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⣿⣿⣾⠿⠃⠀⠀⠀⠀⠀⠀⢠⣿⣷⣤⣶⣤⣀⣤⣄⣠⣾⣿⠏⠀⠀⠀⢹⣿⣿⣿⣿⣷⣾⣿⣷⣿⠟⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠁⠀⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠛⠛⢿⣿⣿⢿⣿⡿⠛⠋⠀⠀⠀⠀⠀⠀⠉⠁⠙⠛⠋⠙⠛⠋⠀⠀⠀⠀⠀⠀⠀";
    string SquirtleASCII = @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠈⠁⠀⠀⠈⠀⠠⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢠⡅⠀⠀⠀⠀⠀⢀⠤⢄⠀⠀⠁⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⣧⠀⠀⠀⠀⠀⠀⣾⣦⣾⡇⠀⠀⠰⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠘⠇⠀⠀⠀⠀⠀⠸⣟⣛⡁⠇⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠆⢄⣀⠤⠤⠤⠤⠄⢀⣀⣀⠤⠀⠀⢡⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠈⠢⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢢⢚⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⡀⠀⠘⡲⠤⢄⣐⣈⢀⣀⣂⠬⠞⠥⣦⠑⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⡀⠀⠂⠀⠀⢀⠊⠀⠀⠀⠀⠀⠈⡐⠁⠀⠀⠀⠈⣟⠪⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠈⡄⢰⠀⠀⠀⢀⠁⠀⠀⠀⠂⠄⠤⠴⠁⠀⠀⠀⠀⠀⡿⠐⠨⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠈⠤⠤⠁⠠⠠⡼⠀⠀⠀⠀⢸⠀⢀⠄⠈⠡⢀⢀⢀⠜⢨⠁⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠆⢡⠀⠀⠀⠘⠀⠐⠒⠤⣀⠠⠞⠊⠀⢸⠐⣀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⡰⠄⠀⠀⠉⠉⠀⠀⠀⠀⠃⡀⠀⢸⠀⢸⢲⢼⠃⠀⠄⠈⠀⠀⠀⠁⢢⠀
⠀⠀⠀⠀⠀⠄⠀⠢⠀⠀⠀⢀⠀⠀⠀⠀⠠⠉⠁⠀⠈⠪⣇⡎⡠⠁⠀⠀⣠⠤⣄⠀⠀⠆
⠀⠀⠀⠀⢠⠀⠀⠀⠑⢤⠀⠚⠠⢀⡀⠰⠁⠀⠀⠀⠀⠀⢻⠊⠀⠀⠀⡞⠀⠀⠀⠀⠀⡇
⠀⠀⠀⠀⢰⠀⠀⠀⠀⠀⡕⠂⠀⠤⠠⢽⡀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠂⠙⣄⡀⢀⢈⠔⠀
⠀⠀⠀⠐⣄⢠⠀⣀⠴⠐⠀⠀⠀⠀⠀⠀⠐⡀⠀⠀⠀⠀⢨⠁⠒⠂⠐⠀⠀⠙⠋⠀⠀⠀
⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢃⠠⡀⢀⡡⢈⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";
    string CharmanderASCII = @"";
    string JigglypuffASCII = @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡠⠄⠒⠒⠒⠠⢄⡀⠀⠀⠀⠀⢀⡠⠔⠊⠱⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠎⠁⠀⠀⠀⠀⠀⠀⠀⠈⠒⢤⠔⠊⠁⢀⣠⣶⡆⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠬⢢⣄⠀⠀⠀⠀⠀⠀⠀⠀
⡤⠀⠤⠤⠤⠤⠀⣀⣀⠀⠀⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠳⡀⣴⣿⣿⣿⡇⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡀⠀⠈⢳⡀⠀⠀⠀⠀⠀⠀
⡇⠀⣀⣀⣀⡀⠀⠀⠀⠈⠉⠐⠢⠞⠁⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⡙⠿⣿⣿⡇⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠇⠀⠀⠀⠀⠀⠀
⢃⠀⣿⣿⣿⣿⣿⣷⣦⡀⠀⠀⠀⠀⠀⠀⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢣⠀⠈⠻⢃⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠇⠀⠀⠘⠀⠀⠀⠀⠀⠀⠀
⢸⠀⢿⣿⣿⣿⣿⣿⠋⠀⠀⠀⠀⠀⠀⠀⠘⠦⣀⣀⣀⣀⣀⣤⡀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠘⢆⠀⠀⠀⠀⠀⠀⠀⡠⠔⠀⡀⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⢇⠸⣿⣿⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⢠⠋⠀⠩⣧⠀⠀⠀⢀⠆⠀⠀⠀⠀⠈⢧⠀⠀⠀⠀⠀⠀⠧⠤⠦⠚⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄
⠀⠘⡄⠻⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⡀⠀⢸⡀⠀⠀⠁⠁⠤⣠⠊⠀⡠⠪⢭⡭⢐⠈⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠊⠅
⠀⠀⠘⢤⠘⠃⠀⠀⠀⠀⠀⠀⢀⠤⠂⠉⠀⢶⣆⡠⢍⡐⢕⠂⠤⠤⠐⠋⠀⠀⡘⡄⠀⠀⢹⣧⠑⡙⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⣀⠀⠀⡰⠁⠀⢰
⠀⠀⠀⠀⢱⠀⠀⠀⠀⠀⠀⠠⠊⠀⠀⠀⠀⠀⢹⡭⢧⡈⢢⠑⡀⠀⠀⠀⠀⠀⡇⣧⣀⣀⡼⣞⡇⢡⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠢⠤⠨⠎⠀⠀⠀⠈
⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⡆⣄⠀⠀⠀⠀⠀⢸⡗⢮⡇⠈⠆⢃⠀⠀⠀⠀⠀⢡⢻⣟⣏⢧⡽⠃⡜⣼⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠸⠀⡿⣦⣀⣀⣀⣴⠻⣜⣣⡇⠀⡸⢘⠀⠀⠀⠀⠀⠀⠡⢑⠭⠉⠠⠜⠔⢸⠒⠂⠐⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠈⡆⠀⠀⠀⠀⠀⢇⠱⡙⢮⣳⣍⣖⣫⡼⠋⠀⢠⠃⠎⠀⠀⠀⠀⠀⠀⢀⠀⠁⠐⠀⠁⠀⡆⠀⢀⠞⠀⠀⠀⠀⠀⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢱⡀⠀⠀⠀⠀⠀⠢⡑⠤⡀⠈⠁⠀⠀⣀⠔⡡⠊⠀⠀⠀⡤⡤⠴⣲⠋⠀⠀⠀⠀⠀⣰⠥⠒⠁⠀⠀⠀⠀⠀⠀⠀⠡⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢻⡄⠀⠀⠀⠀⠀⠈⠐⠠⠭⠉⠭⠥⠐⠈⣠⠤⣄⠀⠰⣇⡶⠳⡏⠀⠀⠀⠀⠀⢠⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠡⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠻⡦⢀⠀⠀⠀⠀⠀⠐⠦⡀⠀⠀⢠⣿⣶⣦⡰⣷⠀⠘⠦⠜⠀⠀⠀⠀⠀⡠⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⠙⢦⡁⠢⢀⠀⠀⠀⠀⠈⠳⣴⣿⣿⣿⣿⣷⠟⠀⠀⠀⠀⠀⠀⠀⣠⠜⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠦⡀⠈⣐⣀⣀⣀⣀⣼⣿⠟⠋⠉⠀⠀⠀⠀⠀⠀⠀⣠⠞⠉⠁⠒⠒⠤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡨⠵⠂⠀⠘⡿⠿⠋⠁⠀⠀⠀⠀⠀⢀⣀⠤⠶⠭⠀⣀⣀⠀⠀⠤⠔⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⡠⠔⠉⠀⠀⠀⠀⠀⢀⡨⠝⠓⠒⠒⠒⠒⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠺⠤⠀⠤⠤⠤⠄⠒⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";
    string GeodudeASCII = @"";
    string PsyduckASCII = @"";
    string MachopASCII = @"";
    string MeowthASCII = @"";
    string AbraASCII = @"";
    string GastlyASCII = @"";

    public void Iniciar()
    {
        Console.WriteLine("¡Bienvenido al juego de Pokémon!");

        puntuación = 0;
    }




    private Pokémon SeleccionarPokémonAleatorio()
    {
        return pokémonDisponibles[random.Next(pokémonDisponibles.Count)];
    }



    private void SeleccionarMovimientosAleatorios(Pokémon pokémon)
    {
        var movimientosAleatorios = pokémonDisponibles[random.Next(pokémonDisponibles.Count)].Movimientos;
        pokémon.Movimientos.AddRange(movimientosAleatorios.Take(3));
    }

    public async Task IniciarModoHistoria()
    {
        Console.WriteLine("¡Bienvenido al modo historia de Pokémon!");
        MostrarTextoPocoAPoco();

        jugadorPokémon = pokémonDisponibles[0];

        RealizarCombate();

    }





    private void CombatesPorRondas()
    {
        try
        {
            // Inicializa los Pokémon del jugador y del oponente
            SeleccionarPokémonInicial();
            oponentePokémon = SeleccionarPokémonAleatorio();

            // Bucle para las rondas
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("|-------------------------------\\");
                Console.WriteLine("|Bienvenido a los combates pokemon||");
                Console.WriteLine("|-------------------------------//");
                // Muestra el número de ronda
                Console.WriteLine($"\n¡Ronda {i}!");

                // Combate
                Luchar();

                // Comprueba si el jugador ha ganado
                if (jugadorPokémon.PS <= 0)
                {
                    Console.WriteLine("¡Has perdido la ronda!");
                    break;
                }
            }

            // Comprueba si el jugador ha ganado el modo
            if (jugadorPokémon.PS > 0)
            {
                Console.WriteLine("¡Felicidades has ganado todas las rondas de Combates pokemon!");
            }
            else
            {
                Console.WriteLine("¡Intentalo Otra vez!");
            }
        }
        catch (Exception ex)
        {
            // La lista de Pokémon está vacía
            Console.WriteLine(ex.Message);
        }
    }

    public void MostrarMenú()
    {
        Console.WriteLine("_");
        Console.WriteLine(" _ __   ___ | | _____ _ __ ___   ___  _ __");
        Console.WriteLine("| '_ \\ / _ \\| |/ / _ \\ '_ ` _ \\ / _ \\| '_ \\");
        Console.WriteLine("| |_) | (_) |   <  __/ | | | | | (_) | | | |");
        Console.WriteLine("| .__/ \\___/|_|\\_\\___|_| |_| |_|\\___/|_| |_|");
        Console.WriteLine("|_|");



        Console.WriteLine("\n    Menú Principal:");
        Console.WriteLine("|_________________________|");
        Console.WriteLine("|1. Historia");
        Console.WriteLine("|_________________________|");
        Console.WriteLine("|2. Combates");
        Console.WriteLine("|_________________________|");
        Console.WriteLine("|3. Salir");
        Console.WriteLine("|-------------------------|");
    }


    private void CapturarPokémon(Pokémon entrenador, Pokémon capturado)
    {
        Console.WriteLine($"\n¡Felicidades! {entrenador.Nombre} ha capturado a {capturado.Nombre}.");

        // Lógica para agregar al Pokémon capturado al equipo del entrenador
    }

    private void SeleccionarPokémonInicial()
    {
        Console.WriteLine("\n¡Selecciona tu Pokémon para todas las rondas!");
        MostrarPokémonDisponibles();

        Console.Write("Elige a tu Pokémon: ");
        if (int.TryParse(Console.ReadLine(), out int opcionPokémon) && opcionPokémon >= 1 && opcionPokémon <= pokémonDisponibles.Count)
        {
            jugadorPokémon = pokémonDisponibles[opcionPokémon - 1];
        }
        else
        {
            Console.WriteLine("Opción no válida. Seleccionando un Pokémon aleatorio.");
            jugadorPokémon = SeleccionarPokémonAleatorio();
        }

        Console.WriteLine($"Has seleccionado a {jugadorPokémon.Nombre} como tu Pokémon para todas las rondas. ¡Que comience la aventura!");
    }


    private void MostrarPokémonDisponibles()
    {
        Console.WriteLine("Pokémon Disponibles:");
        for (int i = 0; i < pokémonDisponibles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pokémonDisponibles[i].Nombre}");
        }
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
                        IniciarModoHistoria();
                        break;
                    case 2:
                        CombatesPorRondas();
                        break;
                    case 3:
                        Console.WriteLine("Gracias por jugar. ¡Hasta luego!");
                        salir = true;
                        break;
                    case 4:
                        Console.WriteLine("¿Estás seguro de que quieres finalizar el juego? (Si/No)");
                        string respuesta = Console.ReadLine();

                        if (respuesta.ToUpper() == "Si")
                        {
                            salir = true;
                        }
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

    public void RealizarCombate()
    {
        try
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"\n¡Batalla {i}!");

                // Combate
                oponentePokémon = SeleccionarPokémonAleatorio();

                Console.WriteLine("\n¡Comienza un combate!");

                while (jugadorPokémon.PS > 0 && oponentePokémon.PS > 0)
                {
                    Console.Clear();
                    MostrarPelea(jugadorPokémon, oponentePokémon);

                    Console.WriteLine("\n¡Es tu turno!");
                    MostrarMovimientos(jugadorPokémon);

                    Console.Write("Elige un movimiento: ");
                    if (int.TryParse(Console.ReadLine(), out int opcionMovimiento) && opcionMovimiento >= 1 && opcionMovimiento <= jugadorPokémon.Movimientos.Count)
                    {
                        Movimiento movimientoJugador = jugadorPokémon.Movimientos[opcionMovimiento - 1];
                        int danioJugador = CalcularDanio(movimientoJugador.Poder, oponentePokémon.Defensa);
                        int danioOponente = CalcularDanio(oponentePokémon.Movimientos[random.Next(oponentePokémon.Movimientos.Count)].Poder, jugadorPokémon.Defensa);

                        oponentePokémon.PS -= danioJugador;
                        jugadorPokémon.PS -= danioOponente;

                        Console.WriteLine($"\nHas usado {movimientoJugador.Nombre} y has causado {danioJugador} puntos de daño a {oponentePokémon.Nombre}.");
                        Console.WriteLine($"{oponentePokémon.Nombre} te ha atacado con un movimiento aleatorio y te ha causado {danioOponente} puntos de daño.");

                        Console.WriteLine("\nPresiona Enter para continuar...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nOpción de movimiento no válida. Inténtalo de nuevo.");
                        continue;
                    }

                    MostrarPokémon(jugadorPokémon, "Jugador");
                    MostrarPokémon(oponentePokémon, "Oponente");
                }

                if (jugadorPokémon.PS <= 0)
                {
                    Console.WriteLine("\n¡Game Over!.");
                    break;
                }
                else
                {
                    Console.WriteLine($"\n¡Has derrotado al {oponentePokémon.Nombre} salvaje! ¡Felicidades!");
                    puntuación += 100;
                    MostrarPuntuacion();
                    Console.WriteLine("\nPresiona Enter para avanzar a la siguiente ronda...");
                    Console.ReadLine();
                }

                jugadorPokémon = pokémonDisponibles[0];
            }

            Console.WriteLine("¡Felicidades has ganado todas las batallas contra los pokemones salvajes!");
        }
        catch (Exception ex)
        {
            // La lista de Pokémon está vacía
            Console.WriteLine(ex.Message);
        }
    }


    static async Task MostrarTextoConRetraso(string texto)
    {
        foreach (char caracter in texto)
        {
            Console.Write(caracter);
            await Task.Delay(30);
        }
        Console.WriteLine();
    }

    public void MostrarTextoPocoAPoco()
    {
        string[] lineasTexto =
        {
            " En un mundo lleno de Pokémon, un joven entrenador llamado Ash ha comenzado su viaje Pokémon.",
            " Su sueño es convertirse en el Campeón Pokémon, y eligió a Pikachu como su primer compañero.",
            " Ahora Ash en su viaje se enferntara a muchos pokemones....",

            "\nPresiona Enter para comenzar el juego..."

    };

        foreach (var linea in lineasTexto)
        {
            MostrarTextoConRetraso(linea);
        }

        Console.ReadLine();
    }



    public void Luchar()
    {
        Console.WriteLine("\n¡Bienvenido a la batalla Pokémon!");
        Console.WriteLine($"Tu Pokémon: {jugadorPokémon.Nombre}");
        Console.WriteLine($"Oponente: {oponentePokémon.Nombre}");
        Console.WriteLine($"¡Un salvaje {oponentePokémon.Nombre} apareció!");

        while (jugadorPokémon.PS > 0 && oponentePokémon.PS > 0)
        {
            Console.Clear();
            MostrarPelea(jugadorPokémon, oponentePokémon);

            Console.WriteLine("\n¡Es tu turno!");
            MostrarMovimientos(jugadorPokémon);

            Console.Write("Elige un movimiento: ");
            if (int.TryParse(Console.ReadLine(), out int opcionMovimiento) && opcionMovimiento >= 1 && opcionMovimiento <= jugadorPokémon.Movimientos.Count)
            {
                Movimiento movimientoJugador = jugadorPokémon.Movimientos[opcionMovimiento - 1];
                int danioJugador = CalcularDanio(movimientoJugador.Poder, oponentePokémon.Defensa);
                int danioOponente = CalcularDanio(oponentePokémon.Movimientos[random.Next(oponentePokémon.Movimientos.Count)].Poder, jugadorPokémon.Defensa);

                oponentePokémon.PS -= danioJugador;
                jugadorPokémon.PS -= danioOponente;

                Console.WriteLine($"\nHas usado {movimientoJugador.Nombre} y has causado {danioJugador} puntos de daño a {oponentePokémon.Nombre}.");
                Console.WriteLine($"{oponentePokémon.Nombre} te ha atacado con un movimiento aleatorio y te ha causado {danioOponente} puntos de daño.");

                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nOpción de movimiento no válida. Inténtalo de nuevo.");
                continue;
            }

            MostrarPokémon(jugadorPokémon, "Jugador");
            MostrarPokémon(oponentePokémon, "Oponente");
        }
        if (jugadorPokémon.PS <= 0)
        {
            Console.WriteLine("\n¡Game Over!.");
        }
        else
        {
            Console.WriteLine($"\n¡Has derrotado al {oponentePokémon.Nombre} salvaje! ¡Felicidades!");
            puntuación += 100;
            MostrarPuntuacion();
            Console.WriteLine("\nPresiona Enter para avanzar a la siguiente ronda...");
            Console.ReadLine();
        }

        oponentePokémon = SeleccionarPokémonAleatorio();
    }


    private int CalcularDanio(int poderAtaque, int defensa)
    {
        int danio = poderAtaque - defensa;
        return danio > 0 ? danio : 0;
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
        Console.WriteLine($"   (PS: {jugador.PS}) vs. (PS: {oponente.PS})");
        Console.WriteLine("   " + new string('-', 46));
        Console.WriteLine($"   |{jugador.ArteASCII}{new string(' ', 1)}|{new string(' ', 29)}|");
        Console.WriteLine($"   |{new string(' ', 1)}{jugador.Nombre}{new string(' ', 7)}|{new string(' ', 14)}{oponente.Nombre}{new string(' ', 5)}|");
        Console.WriteLine("   |" + new string(' ', 15) + "|" + new string(' ', 29) + "|");
        Console.WriteLine("   " + new string('-', 46));
        Console.WriteLine("\nPresiona Enter para comenzar la pelea...");
        Console.ReadLine();

    }

}







/* es cambiar las opciones de los pokemones para que el usurio las pueda escojer del menu
* pero que siempre pikachu este en tu equipo como presoje pricipal
* mapas
* cambiar la historia
* niveles
* agregar modo torneo y dividir el modo campaña
* menus mas dinamicos con mas opciones
 */