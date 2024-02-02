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
        Pokemon enemy = Pokemon.pokemons[1];
        player = Intro.player;
        // Check the state of the fight
        //Fight.StartRound(player,player.Team[player.CurrentPokemon], enemy);

        // display the map
        Map.ReadMap();
        // make the player move
        Map.SpawnPlayer();

        
    }

    
}