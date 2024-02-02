// Main function for the program

using System;

class Program
{

    public static Player player;
    static void Main()
    {
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.Title = "Pokemon";
        Console.CursorVisible = false;
        Console.Clear();

        //Print the intro
        Intro.PrintIntro();
        // Create an enemy
        player = Intro.player;

        // display the map
        Map.ReadMap();
        // make the player move
        Map.SpawnPlayer(156, 69);

        
    }

    
}