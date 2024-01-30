// Main function for the program

using System;

class Program
{
    private static string? name;
    static void Main()
    {
        name = Player.AskName();

        // Create a new player
        Player player = new Player(name);

        // Get the player's starter pokemon
        player.SetStarter();

        // Create an enemy
        Enemy enemy = Enemy.CreateEnemy();

        //Print the intro
        player.Intro();
        // Check the state of the fight
        Fight.StartRound(player,player.Team[player.CurrentPokemon], enemy);

        
    }

    
}