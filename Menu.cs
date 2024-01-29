//Class for the menu
using System;

public class Menu
{

    //method for menu
    public static void ShowMenu()
    {

        //print menu
        Console.WriteLine("1. Fight");
        Console.WriteLine("2. Exit");

        Console.WriteLine("What would you like to do?");
        
        //get user input
        int input = GetInput();
        Console.WriteLine("You chose " + input);
        
        // Apply the user's choice
        MenuChoice(input, playerPokmeon, enemyPokemon);
    }

    //method for user input
    public static int GetInput()
    {
        //get user input
        int input = Convert.ToInt32(Console.ReadLine());

        //return user input
        return input;
    }

    //method for menu
    public static void MenuChoice(int input, Entity player, Entity enemy)
    {
        //if user chooses 1
        if (input == 1)
        {
            //call fight method
            Fight.CheckState(player, enemy);
        }
        //if user chooses 2
        else if (input == 2)
        {
            //exit program
            Environment.Exit(0);
        }
    }

}