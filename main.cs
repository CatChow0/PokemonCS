// Main function for the program

using System;

class Program
{
    static void Main()
    {
        // Ask the player for their name
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Console.WriteLine(name);

        // Create a new player
        Player player = new Player(name);

        // Get the player's starter pokemon
        player.GetStarter();

        // Create an enemy
        Enemy enemy = Enemy.CreateEnemy();

        //show menu
        Menu.ShowMenu();
    }
}