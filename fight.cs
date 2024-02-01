// Class for fight

using System;
using System.Security.Principal;

public class Fight {

    // variable for the player
    public static Player currentPlayer;
    public static Item Item;
    public static Pokemon currentEnemy;
    private static bool isRunning = true;


    //method for round
    public static void Round(Pokemon playerPokemon, Pokemon enemyPokemon)
    {
        //player attacks enemy
        enemyPokemon.Health -= playerPokemon.Damage;
        PrintStats();
        Console.SetCursorPosition(0, 35);
        DrawBorderLine();
        Console.WriteLine(playerPokemon.Name + " attacks " + enemyPokemon.Name + " for " + playerPokemon.Damage + " damage!");
        Console.WriteLine(enemyPokemon.Name + " has " + enemyPokemon.Health + " health remaining!");
        DrawBorderLine();
        Console.ReadKey();
        Console.Clear();

        //if enemy is dead
        if (enemyPokemon.Health <= 0)
        {
            Console.WriteLine(enemyPokemon.Name + " has died!");
            return;
        }


        //enemy attacks player
        
        playerPokemon.Health -= enemyPokemon.Damage;
        PrintStats();
        DrawBorderLine();
        Console.WriteLine(enemyPokemon.Name + " attacks " + playerPokemon.Name + " for " + enemyPokemon.Damage + " damage!");
        Console.WriteLine(playerPokemon.Name + " has " + playerPokemon.Health + " health remaining!");
        DrawBorderLine();
        Console.ReadKey();
        Console.Clear();

        //if player is dead
        if (playerPokemon.Health <= 0)
        {
            Console.WriteLine(playerPokemon.Name + " has died!");
            return;
        }

    }

    // method to print the menu
    public static void PrintMenu()
    {
        // print the pokemon info
        PrintStats();
        Console.WriteLine("What do you want to do?");
        DrawBorderLine();
        Console.WriteLine("1. Attack           2. Change Pokemon");
        Console.WriteLine("3. Item             4. Run");
        DrawBorderLine();
    }

    // method to get the player's choice
    public static int GetChoice()
    {
        // get the player's choice 
        string choice = Console.ReadLine();

        // if the choice is not a number
        if (!int.TryParse(choice, out int result))
        {
            // print an error message
            Console.WriteLine("That is not a valid choice!");
            return 0;
        }

        // return the player's choice
        return result;
    }

    // method to apply the player's choice
    public static void ApplyChoice(int choice, Pokemon playerPokemon, Pokemon enemyPokemon)
    {
        // if the player chose to attack
        if (choice == 1)
        {
            // call the round method
            Console.Clear();
            Round(playerPokemon, enemyPokemon);
        }

        // if the player chose to change pokemon
        else if (choice == 2)
        {
            Console.Clear();
            PrintStats();
            // change the player's pokemon
            currentPlayer.ChangePokemon();
        }

        // if the player chose to use an item
        else if (choice == 3)
        {
            Console.Clear();
            PrintStats();
            // print the player's items
            Item.PrintItemMenu(currentPlayer);
        }

        // if the player chose to run
        else if (choice == 4)
        {
            isRunning = false;
            // print a message
            Console.Clear();
            Console.WriteLine("You ran away!");
            Console.ReadKey();
        }

        // if the player chose an invalid option
        else
        {
            // print an error message
            Console.WriteLine("That is not a valid choice!");
        }
    }
    


    // method to start the round
    public static void StartRound(Player player, Pokemon playerPokemon, Pokemon enemyPokemon)
    {
        if(currentPlayer == null)
        {
            currentPlayer = player;
        }
        // print a message
        Console.WriteLine("You encountered a " + enemyPokemon.Name + "!");

        currentEnemy = enemyPokemon;



        // while both players are alive
        while ((playerPokemon.Health > 0 && enemyPokemon.Health > 0) && isRunning)
        {
            // print the menu
            PrintMenu();

            // get the player's choice
            int choice = GetChoice();

            // apply the player's choice
            ApplyChoice(choice, playerPokemon, currentEnemy);
        }
    }

    // method to go back to the fight menu
    public static void GoBack()
    {
        // print a message
        Console.WriteLine("You went back to the fight menu!");
        Round(currentPlayer.Team[currentPlayer.CurrentPokemon], currentEnemy);
    }

    public static void DrawBorderLine()
    {
        for (int i = 0; i < 198; i++)
        {
            Console.Write("=");
        }
        Console.Write("\n");

        
    }

    //method to print Stats of pokemon
    public static void PrintStats()
    {
        currentEnemy.PrintStats("Enemy");
        currentPlayer.Team[currentPlayer.CurrentPokemon].PrintStats("Player");
    }

    
}

