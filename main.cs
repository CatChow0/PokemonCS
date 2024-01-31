// Main function for the program

using System;

class Program
{
    private static string? name;
    static void Main()
    {
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.Title = "Pokemon";
        Console.CursorVisible = false;
        Console.Clear();

        name = Player.AskName();

        // Create a new player
        Player player = new Player(name);

        // Get the player's starter pokemon
        player.SetStarter();

        // Create an enemy
        Pokemon enemy = Pokemon.CreateEnemy();

        //Print the intro
        player.Intro();
        // Check the state of the fight
        Fight.StartRound(player,player.Team[player.CurrentPokemon], enemy);

        
    }

    
}