// Class for fight

using System;

public class Fight {

    // variable for the player
    public static Player currentPlayer;
    public static Item Item;
    public static Enemy currentEnemy;


    //method for round
    public static void Round(Pokemon playerPokemon, Enemy enemyPokemon)
    {
        
        //player attacks enemy
        enemyPokemon.Health -= playerPokemon.Damage;
        Console.WriteLine(playerPokemon.Name + " attacks " + enemyPokemon.Name + " for " + playerPokemon.Damage + " damage!");
        Console.WriteLine(enemyPokemon.Name + " has " + enemyPokemon.Health + " health remaining!");

        //if enemy is dead
        if (enemyPokemon.Health <= 0)
        {
            Console.WriteLine(enemyPokemon.Name + " has died!");
            return;
        }


        //enemy attacks player
        playerPokemon.Health -= enemyPokemon.Damage;
        Console.WriteLine(enemyPokemon.Name + " attacks " + playerPokemon.Name + " for " + enemyPokemon.Damage + " damage!");
        Console.WriteLine(playerPokemon.Name + " has " + playerPokemon.Health + " health remaining!");

        //if player is dead
        if (playerPokemon.Health <= 0)
        {
            Console.WriteLine(playerPokemon.Name + " has died!");
            return;
        }
        
    }

    //method for fight
    public static void CheckState(Pokemon playerPokemon, Enemy enemyPokemon)
    {
        
        //while both players are alive
        while (playerPokemon.Health > 0 && enemyPokemon.Health > 0)
        {
            //call round method
            Round(playerPokemon, enemyPokemon);
        }

       
    }

    // method to print the menu
    public static void PrintMenu()
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Change Pokemon");
        Console.WriteLine("3. Item");
        Console.WriteLine("4. Run");
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
    public static void ApplyChoice(int choice, Pokemon playerPokemon, Enemy enemyPokemon)
    {
        // if the player chose to attack
        if (choice == 1)
        {
            // call the round method
            Round(playerPokemon, enemyPokemon);
        }

        // if the player chose to change pokemon
        else if (choice == 2)
        {
            // change the player's pokemon
            currentPlayer.ChangePokemon();
        }

        // if the player chose to use an item
        else if (choice == 3)
        {
            // print the player's items
            Item.PrintItemMenu(currentPlayer);
        }

        // if the player chose to run
        else if (choice == 4)
        {
            // print a message
            Console.WriteLine("You ran away!");
        }

        // if the player chose an invalid option
        else
        {
            // print an error message
            Console.WriteLine("That is not a valid choice!");
        }
    }
    


    // method to start the round
    public static void StartRound(Player player, Pokemon playerPokemon, Enemy enemyPokemon)
    {
        if(currentPlayer == null)
        {
            currentPlayer = player;
        }
        // print a message
        Console.WriteLine("You encountered a " + enemyPokemon.Name + "!");

        currentEnemy = enemyPokemon;



        // while both players are alive
        while (playerPokemon.Health > 0 && enemyPokemon.Health > 0)
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

    
}