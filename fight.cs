﻿// Class for fight

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
            damage = playerPokemon.dmg_Attack2;
        }
        else if (attack_type == "3")
        {
            damage = playerPokemon.dmg_Attack3;
        }
        else if (attack_type == "4")
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
            Console.WriteLine(playerPokemon.Name + " attacks " + enemyPokemon.Name + " with " + playerPokemon.Attack + " for " + damage + " damage!");
        }
        else if (attack_type == "2")
        {
            Console.WriteLine(playerPokemon.Name + " attacks " + enemyPokemon.Name + " with " + playerPokemon.Attack2 + " for " + damage + " damage!");
        }
        else if (attack_type == "3")
        {
            Console.WriteLine(playerPokemon.Name + " attacks " + enemyPokemon.Name + " with " + playerPokemon.Attack3 + " for " + damage + " damage!");
        }
        else if (attack_type == "4")
        {
            Console.WriteLine(playerPokemon.Name + " attacks " + enemyPokemon.Name + " with " + playerPokemon.Attack_Spe + " for " + damage + " damage!");
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
        int attack_type_random = random.Next(1, 5);

        if (attack_type_random == 1)
        {
            damage = playerPokemon.dmg_Attack;
        }
        else if (attack_type_random == 2)
        {
            damage = playerPokemon.dmg_Attack2;
        }
        else if (attack_type_random == 3)
        {
            damage = playerPokemon.dmg_Attack3;
        }
        else if (attack_type_random == 4)
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
            Console.WriteLine(enemyPokemon.Name + " attacks " + playerPokemon.Name + " with " + enemyPokemon.Attack2 + " for " + damage + " damage!");
        }
        else if (attack_type_random == 3)
        {
            Console.WriteLine(enemyPokemon.Name + " attacks " + playerPokemon.Name + " with " + enemyPokemon.Attack3 + " for " + damage + " damage!");
        }
        else if (attack_type_random == 4)
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
            Console.WriteLine("1. Basic Attack" + playerPokemon.Attack + " " + playerPokemon.Use_nb_baseAtk + "/30");
            Console.WriteLine("2. " + playerPokemon.Attack2 + " " + playerPokemon.Use_nb_Atk + "/50");
            Console.WriteLine("3. " + playerPokemon.Attack3 + " " + playerPokemon.Use_nb_Atk2 + "/50");
            Console.WriteLine("4. " + playerPokemon.Attack_Spe + " " + playerPokemon.Use_nb_Atk_Spe + "/10");
            DrawBorderLine();

            string attack_choice = Console.ReadLine();

            // if the choice is not 1 or 2
            switch (attack_choice)
            {
                case "1":
                    if (playerPokemon.Use_nb_baseAtk > 0)
                    {
                        Console.WriteLine(playerPokemon.Name + " use " + playerPokemon.Attack);
                        playerPokemon.Use_nb_baseAtk -= 1;
                        ApplyAttack(playerPokemon, enemyPokemon, attack_choice);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can no longer use this attack");
                        Console.ReadKey();
                        ApplyChoice(choice, playerPokemon, enemyPokemon);
                        break;
                    }

                case "2":
                    if (playerPokemon.Use_nb_Atk > 0)
                    {
                        Console.WriteLine(playerPokemon.Name + " use " + playerPokemon.Attack2);
                        playerPokemon.Use_nb_Atk -= 1;
                        ApplyAttack(playerPokemon, enemyPokemon, attack_choice);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can no longer use this attack");
                        Console.ReadKey();
                        ApplyChoice(choice, playerPokemon, enemyPokemon);
                        break;
                    }

                case "3":
                    if (playerPokemon.Use_nb_Atk2 > 0)
                    {
                        Console.WriteLine(playerPokemon.Name + " use " + playerPokemon.Attack3);
                        playerPokemon.Use_nb_Atk2 -= 1;
                        ApplyAttack(playerPokemon, enemyPokemon, attack_choice);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can no longer use this attack");
                        Console.ReadKey();
                        ApplyChoice(choice, playerPokemon, enemyPokemon);
                        break;
                    }

                case "4":
                    if (playerPokemon.Use_nb_Atk_Spe > 0)
                    {
                        Console.WriteLine(playerPokemon.Name + " use " + playerPokemon.Attack_Spe);
                        playerPokemon.Use_nb_Atk_Spe -= 1;
                        ApplyAttack(playerPokemon, enemyPokemon, attack_choice);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can no longer use this attack");
                        Console.ReadKey();
                        ApplyChoice(choice, playerPokemon, enemyPokemon);
                        break;
                    }

                default:
                        Console.WriteLine("That is not a valid choice");
                        Console.ReadKey();
                        ApplyChoice(choice, playerPokemon, enemyPokemon);
                        break;
            }
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
    
    public static void ApplyAttack(Pokemon playerPokemon, Pokemon enemyPokemon, string attack_choice)
    {
        // call the round method with attack choice
        Console.ReadKey();
        Console.Clear();
        Round(playerPokemon, enemyPokemon, attack_choice);
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
        playerPokemon.Use_nb_baseAtk = 30;
        playerPokemon.Use_nb_Atk = 50;
        playerPokemon.Use_nb_Atk2 = 50;
        playerPokemon.Use_nb_Atk_Spe = 10;

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