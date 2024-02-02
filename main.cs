// Main function for the program

using System;

class Program
{

    private static Player player;
    static void Main()
    {
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.Title = "Pokemon";
        Console.CursorVisible = false;
        Console.Clear();

        //Print the intro
        Intro.PrintIntro();
        // Create an enemy
        Fight.currentEnemy = Pokemon.CreatePokemon(0);
        player = Intro.player;
        // Check the state of the fight
        //Fight.StartRound(player, Fight.currentEnemy);

        // display the map
        Map.ReadMap();
        // make the player move
        Map.SpawnPlayer(156, 69);

        
    }

    
}