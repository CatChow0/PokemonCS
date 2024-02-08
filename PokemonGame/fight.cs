// Class for fight

using System;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace PokemonCS
{
    public class Fight
    {

        // variable for the player
        public static Player? currentPlayer;
        public static Item? Item;
        public static Pokemon? currentEnemy;
        public static Pokemon? playerPokemon;
        public static int damage;
        public static bool isRunning = false;


        //method for round
        public static void Round(Pokemon playerPokemon, Pokemon enemyPokemon, string attack_type)
        {
            //player attacks enemy
            if (attack_type == "1")
            {
                damage = playerPokemon.Dmg_Attack;
            }
            else if (attack_type == "2")
            {
                damage = playerPokemon.Dmg_Attack2;
            }
            else if (attack_type == "3")
            {
                damage = playerPokemon.Dmg_Attack3;
            }
            else if (attack_type == "4")
            {
                damage = playerPokemon.Dmg_Attack_Spe;
            }
            else
            {
                damage = playerPokemon.Dmg_Attack;
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
                        damage = playerPokemon.Dmg_Attack;
                    }
                    else if (attack_type == "2")
                    {
                        damage = playerPokemon.Dmg_Attack_Spe;
                    }
                    break;

            }
            enemyPokemon.Health -= damage;
            PrintStats();
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
                int xp = playerPokemon.CalculateXp(enemyPokemon.Level);
                currentPlayer.Team[currentPlayer.CurrentPokemon].AddXp(xp);
                currentPlayer.Team[currentPlayer.CurrentPokemon].PrintStats("Player");
                DrawBorderLine();
                Console.WriteLine("You defeated " + enemyPokemon.Name + "!");
                Console.WriteLine("You earned " + xp + " xp!");
                DrawBorderLine();
                Console.ReadKey();
                Console.Clear();
                Map.ReadMap();
                Map.SpawnPlayer(Map.xPos, Map.yPos);
                return;
            }


            //enemy attacks player
            Random random = new();
            int attack_type_random = random.Next(1, 5);

            if (attack_type_random == 1)
            {
                damage = playerPokemon.Dmg_Attack;
            }
            else if (attack_type_random == 2)
            {
                damage = playerPokemon.Dmg_Attack2;
            }
            else if (attack_type_random == 3)
            {
                damage = playerPokemon.Dmg_Attack3;
            }
            else if (attack_type_random == 4)
            {
                damage = playerPokemon.Dmg_Attack_Spe;
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
                        damage = playerPokemon.Dmg_Attack;
                    }
                    else if (attack_type_random == 2)
                    {
                        damage = playerPokemon.Dmg_Attack_Spe;
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
                //if the player has more pokemon
                if (currentPlayer.Team.Length > 1)
                {
                    currentPlayer.ChangePokemon();
                    playerPokemon = currentPlayer.Team[currentPlayer.CurrentPokemon];
                    Console.Clear();
                    PrintStats();
                    DrawBorderLine();
                    Console.WriteLine("You changed to " + playerPokemon.Name + "!");
                    DrawBorderLine();
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("You have no more pokemon!");
                    Console.WriteLine("You blacked out!");
                    Console.ReadKey();
                    Console.Clear();
                    Map.ReadMap();
                    Map.SpawnPlayer(Map.xPos, Map.yPos);
                    return;
                }
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
                Console.WriteLine("1. Basic Attack" + playerPokemon.Attack + " " + playerPokemon.Use_nb_baseAtk + "/" + playerPokemon.Max_nb_base_Atk);
                Console.WriteLine("2. " + playerPokemon.Attack2 + " " + playerPokemon.Use_nb_Atk + "/" + playerPokemon.Max_nb_Atk1);
                Console.WriteLine("3. " + playerPokemon.Attack3 + " " + playerPokemon.Use_nb_Atk2 + "/" + playerPokemon.Max_nb_Atk2);
                Console.WriteLine("4. " + playerPokemon.Attack_Spe + " " + playerPokemon.Use_nb_Atk_Spe + "/" + playerPokemon.Max_nb_Atk_Spe);
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
                Console.Clear();
                Map.ReadMap();
                Map.SpawnPlayer(Map.xPos, Map.yPos);
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
        public static void StartRound(Player player, Pokemon enemyPokemon)
        {
            currentPlayer ??= player;

            playerPokemon ??= player.Team[player.CurrentPokemon];

            currentEnemy ??= enemyPokemon;

            if (isRunning == false)
            {
                isRunning = true;
            }
            // print a message
            Console.WriteLine("You encountered a " + enemyPokemon.Name + "!");
            playerPokemon.Use_nb_baseAtk = playerPokemon.Max_nb_base_Atk;
            playerPokemon.Use_nb_Atk = playerPokemon.Max_nb_Atk1;
            playerPokemon.Use_nb_Atk2 = playerPokemon.Max_nb_Atk2;
            playerPokemon.Use_nb_Atk_Spe = playerPokemon.Max_nb_Atk_Spe;

            // while both players are alive
            while (playerPokemon.Health > 0 && enemyPokemon.Health > 0 && isRunning)
            {
                // print the menu
                PrintMenu();

                // get the player's choice
                int choice = GetChoice();

                playerPokemon = player.Team[player.CurrentPokemon];

                // apply the player's choice
                ApplyChoice(choice, playerPokemon, currentEnemy);
            }
        }

        // method to go back to the fight menu
        public static void GoBack()
        {
            // print a message
            Console.Clear();
            PrintStats();
            DrawBorderLine();
            Console.WriteLine("You went back to the fight menu!");
            DrawBorderLine();
            Console.ReadKey();
            Console.Clear();
            PrintMenu();
        }

        public static void DrawBorderLine()
        {
            Console.Write("\n");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("▬");
            }
            Console.Write("\n\n");


        }

        // create a method to read sprites and print it in a fight
        public static void enemy_sprite(Pokemon enemyPokemon)
        {
            // read the sprite
            StreamReader sr = new StreamReader("sprite_ascii\\"+ enemyPokemon.Name + ".txt");
            string line = sr.ReadLine();
            int x,y;
            while (line != null)
            {
                (x, y) = Console.GetCursorPosition();
                Console.SetCursorPosition(135, y);
                //write the line to console window
                Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine();

            }
            sr.Close();
        }

        //second sprite
        public static void player_pokemon_sprite(Pokemon playerPokemon)
        {
            // read the sprite
            StreamReader sr = new StreamReader("sprite_ascii\\" + playerPokemon.Name + ".txt");
            string line = sr.ReadLine();
            int x, y;
            while (line != null)
            {
                (x, y) = Console.GetCursorPosition();
                Console.SetCursorPosition(30, y);
                //write the line to console window
                Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine();

            }
            sr.Close();
        }

        //method to print Stats of pokemon
        public static void PrintStats()
        {
            currentEnemy.PrintStats("Enemy");
            enemy_sprite(currentEnemy);
            player_pokemon_sprite(playerPokemon);
            currentPlayer.Team[currentPlayer.CurrentPokemon].PrintStats("Player");
        }
    }
}