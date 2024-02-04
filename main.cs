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

        //Print the intro
        Menu.SplachScreen();
    }

    
}