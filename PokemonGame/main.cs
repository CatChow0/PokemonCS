// Main function for the program
using PokemonCS;
class Program
{
    static void Main()
    {
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
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