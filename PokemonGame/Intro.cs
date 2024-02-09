//Class intro
namespace PokemonCS
{
    public class Intro
    {

        private static string? name;
        public static Player? player;
        //method to print the intro
        public static void PrintIntro()
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Welcome to the world of Pokemon!");
            Console.WriteLine("My name is Oak! People call me the Pokemon Prof!");
            Console.WriteLine("This world is inhabited by creatures called Pokemon!");
            Console.WriteLine("For some people, Pokemon are pets. Others use them for fights.");
            Console.WriteLine("Myself...I study Pokemon as a profession.");
            Console.WriteLine("First, what is your name?");
            Console.WriteLine("Please enter your name: ");
            Fight.DrawBorderLine();

            name = Player.AskName();
            // Create a new player
            player = new Player(name);
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Right! So your name is " + player.Name + "!");
            Console.WriteLine("Your very own Pokemon legend is about to unfold!");
            Console.WriteLine("A world of dreams and adventures with Pokemon awaits! Let's go!");
            Console.WriteLine("Press any key to continue...");
            Fight.DrawBorderLine();
            Console.ReadKey();

            //Dialogue to chose betwenn the starter pokemon
            Menu.StarterMenu();

            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("You will start with 10 pokeballs and 10 potions and 1000$");
            player.AddItem(10, "Pokeball", "standard");
            player.AddItem(10, "Potion", "standard");
            player.money = 1000;
            Console.WriteLine("Good luck on your journey!");
            Console.WriteLine("Press any key to continue...");
            Fight.DrawBorderLine();
            Console.ReadKey();
            Console.Clear();

            // display the map
            Map.ReadMap();
            // make the player move
            Map.SpawnPlayer(156, 69);

        }

    }
}