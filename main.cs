// Main function for the program

using System;

class Program
{
    
    static void Main()
    {
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.Title = "Pokemon";
        Console.CursorVisible = false;
        Console.Clear();

        // Create an enemy
        Pokemon enemy = Pokemon.CreateEnemy();

        //Print the intro
        player.Intro();
        // Check the state of the fight
        Fight.StartRound(player,player.Team[player.CurrentPokemon], enemy);

        
    }

    
}