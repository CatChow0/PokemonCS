// Main function for the program

using PokemonCS;
using System;

class Program
{
    static void Main()
    {
        Console.SetWindowSize(width: Console.LargestWindowWidth, height: Console.LargestWindowHeight);
        Console.Title = "Pokemon";
        Console.CursorVisible = false;
        Console.Clear();

        // Set the buffer size
        Console.BufferWidth = 600;
        Console.BufferHeight = 200;


        //Print the intro
        Menu.SplashScreen();
    }

    
}