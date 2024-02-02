// Class for fight

using System;
using System.Security.Principal;

public class Fight {

    // variable for the player
    public static Player currentPlayer;
    public static Item Item;
    public static Pokemon currentEnemy;
    public static int damage;
    private static bool isRunning = true;
    string attack_choice = "1";


    //method for round
    public static void Round(Pokemon playerPokemon, Pokemon enemyPokemon, string attack_type)
    {
        //player attacks enemy
        if (attack_type == "1")
        {
            damage = playerPokemon.dmg_Attack;
        }
        else if (attack_type == "2")
        {
            damage = playerPokemon.dmg_Attack_Spe;
        }
        else
        {
            damage = playerPokemon.dmg_Attack;
        }

        switch (playerPokemon.Type)
        {
            case "Fire":
                if (enemyPokemon.Type == "Grass")
                {
                    damage *= 2;
                }
                else if (enemyPokemon.Type == "Water" || enemyPokemon.Type == "Fire")
                {
                    damage /= 2;
                }
                break;
            case "Water":
                if (enemyPokemon.Type == "Fire")
                {
                    damage *= 2;
                }
                else if (enemyPokemon.Type == "Grass" || enemyPokemon.Type == "Water")
                {
                    damage /= 2;
                }
                break;
            case "Electric":
                if (enemyPokemon.Type == "Water")
                {
                    damage *= 2;
                }
                else if (enemyPokemon.Type == "Grass" || enemyPokemon.Type == "Electric")
                {
                    damage /= 2;
                }
                break;
            case "Grass":
                if (enemyPokemon.Type == "Water")
                {
                    damage *= 2;
                }
                else if (enemyPokemon.Type == "Fire" || enemyPokemon.Type == "Grass")
                {
                    damage /= 2;
                }
                break;
            default:
                if (attack_type == "1")
                {
                    damage = playerPokemon.dmg_Attack;
                }
                else if (attack_type == "2")
                {
                    damage = playerPokemon.dmg_Attack_Spe;
                }
                break;

        }
        enemyPokemon.Health -= damage;
        PrintStats();
        Console.SetCursorPosition(0, 35);
        DrawBorderLine();
        if (attack_type == "1")
        {
            Console.WriteLine(playerPokemon.Name + " attacks " + enemyPokemon.Name + " with " + enemyPokemon.Attack + " for " + damage + " damage!");
        }
        else if (attack_type == "2")
        {
            Console.WriteLine(playerPokemon.Name + " attacks " + enemyPokemon.Name + " with " + enemyPokemon.Attack_Spe + " for " + damage + " damage!");
        }
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
        Random random = new Random();
        int attack_type_random = random.Next(1, 3);

        if (attack_type_random == 1)
        {
            damage = playerPokemon.dmg_Attack;
        }
        else if (attack_type_random == 2)
        {
            damage = playerPokemon.dmg_Attack_Spe;
        }

        switch (enemyPokemon.Type)
        {
            case "Fire":
                if (playerPokemon.Type == "Grass")
                {
                    damage *= 2;
                }
                else if (playerPokemon.Type == "Water" || playerPokemon.Type == "Fire")
                {
                    damage /= 2;
                }
                break;
            case "Water":
                if (playerPokemon.Type == "Fire")
                {
                    damage *= 2;
                }
                else if (playerPokemon.Type == "Grass" || playerPokemon.Type == "Water")
                {
                    damage /= 2;
                }
                break;
            case "Electric":
                if (playerPokemon.Type == "Water")
                {
                    damage *= 2;
                }
                else if (playerPokemon.Type == "Grass" || playerPokemon.Type == "Electric")
                {
                    damage /= 2;
                }
                break;
            case "Grass":
                if (playerPokemon.Type == "Water")
                {
                    damage *= 2;
                }
                else if (playerPokemon.Type == "Fire" || playerPokemon.Type == "Grass")
                {
                    damage /= 2;
                }
                break;
            default:
                if (attack_type_random == 1)
                {
                    damage = playerPokemon.dmg_Attack;
                }
                else if (attack_type_random == 2)
                {
                    damage = playerPokemon.dmg_Attack_Spe;
                }
                break;

        }
        playerPokemon.Health -= damage;
        PrintStats();
        DrawBorderLine();
        if (attack_type_random == 1)
        {
            Console.WriteLine(enemyPokemon.Name + " attacks " + playerPokemon.Name + " with " + enemyPokemon.Attack + " for " + damage + " damage!");
        }
        else if (attack_type_random == 2)
        {
            Console.WriteLine(enemyPokemon.Name + " attacks " + playerPokemon.Name + " with " + enemyPokemon.Attack_Spe + " for " + damage + " damage!");
        }
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
            // Choice of the attack
            Console.Clear();
            PrintStats();
            Console.WriteLine("What attack do you want to use?");
            DrawBorderLine();
            Console.WriteLine("1. " + playerPokemon.Attack + "           2. " + playerPokemon.Attack_Spe);
            DrawBorderLine();

            string attack_choice = Console.ReadLine();

            // if the choice is not 1 or 2
            switch (attack_choice)
            {
                case "1":
                    Console.WriteLine(playerPokemon.Name + " use " + playerPokemon.Attack);
                    break;

                case "2":
                    Console.WriteLine(playerPokemon.Name + " use " + playerPokemon.Attack_Spe);
                    break;

                default:
                    Console.WriteLine("That is not a valid choice, " + playerPokemon.Name + " is confused and choose to attack with " + playerPokemon.Attack);
                    break;
            }

            // call the round method with attack choice
            Console.ReadKey();
            Console.Clear();
            Round(playerPokemon, enemyPokemon, attack_choice);
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
        PrintMenu();
    }

    public static void DrawBorderLine()
    {
        for (int i = 0; i < 198; i++)
        {
            Console.Write("▬");
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