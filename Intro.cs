//Class intro

using System.Xml.Linq;

public class Intro
{

    private static string? name;
    //method to print the intro
    public static void PrintIntro()
    {
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
        Player player = new Player(name);
        Console.Clear();
        Fight.DrawBorderLine();
        Console.WriteLine("Right! So your name is " + player.Name + "!");
        Console.WriteLine("Your very own Pokemon legend is about to unfold!");
        Console.WriteLine("A world of dreams and adventures with Pokemon awaits! Let's go!");
        Console.WriteLine("Press any key to continue...");
        Fight.DrawBorderLine();
        Console.ReadKey();

        //Dialogue to chose betwenn the starter pokemon
        Console.Clear();
        Fight.DrawBorderLine();
        Console.WriteLine("You will start with 3 pokeballs and 3 potions!");
        player.AddItem(300, "Pokeball", "standard");
        player.AddItem(3, "Potion", "standard");
        Console.WriteLine("Good luck on your journey!");
        Console.WriteLine("Press any key to continue...");

        player.SetStarter();
    }

}