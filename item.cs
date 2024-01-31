//Class fot the item to use in fight

using System;
using System.Text.RegularExpressions;

public class Item
{

    // method to print the item
    public static void PrintItemMenu(Player currentPlayer)
    {
        Console.WriteLine("What item do you want to use?");
        Console.WriteLine("=====================================");
        Console.WriteLine("1. Potion");
        Console.WriteLine("2. Pokeball");
        Console.WriteLine("3. Back");
        Console.WriteLine("=====================================");
        
        // get the input from the player
        string choice = Console.ReadLine();
        // Do thing based on the player's choice
        switch (choice)
        {
            case "1":
                // Print the potion menu
                PrintPotionMenu(currentPlayer);
                break;
            case "2":
                // Print the pokeball menu
                PrintPokeballMenu(currentPlayer);
                break;
            case "3":
                // go back to the fight menu
                Fight.GoBack();
                break;
            default:
                // Print an error message
                Console.WriteLine("That is not a valid choice!");
                break;
        }
    }

    // method to print the potion menu
    public static void PrintPotionMenu(Player currentPlayer)
    {
        Console.WriteLine("What potion do you want to use?");
        Console.WriteLine("=====================================");
        Console.WriteLine("1. Standard Potion : x" + currentPlayer.potion[0]);
        Console.WriteLine("2. Super Potion    : x" + currentPlayer.potion[1]);
        Console.WriteLine("3. Hyper Potion    : x" + currentPlayer.potion[2]);
        Console.WriteLine("4. Back");
        Console.WriteLine("=====================================");

        // get the input from the player
        string choice = Console.ReadLine();
        // Do thing based on the player's choice
        switch (choice)
        {
            case "1":
                // Use a standard potion
                Potion.UsePotion(currentPlayer, currentPlayer.Team[currentPlayer.CurrentPokemon], "standard");
                break;
            case "2":
                // Use a super potion
                Potion.UsePotion(currentPlayer, currentPlayer.Team[currentPlayer.CurrentPokemon], "super");
                break;
            case "3":
                // Use a hyper potion
                Potion.UsePotion(currentPlayer, currentPlayer.Team[currentPlayer.CurrentPokemon], "hyper");
                break;
            case "4":
                // go back to the item menu
                Fight.GoBack();
                break;
            default:
                // Print an error message
                Console.WriteLine("That is not a valid choice!");
                break;
        }
    }

    // method to print the pokeball menu
    public static void PrintPokeballMenu(Player currentPlayer)
    {
        Console.WriteLine("What pokeball do you want to use?");
        Console.WriteLine("=====================================");
        Console.WriteLine("1. Pokeball   : x" + currentPlayer.pokeball[0]);
        Console.WriteLine("2. Great Ball : x" + currentPlayer.pokeball[1]);
        Console.WriteLine("3. Ultra Ball : x" + currentPlayer.pokeball[2]);
        Console.WriteLine("4. Back");
        Console.WriteLine("=====================================");

        // get the input from the player
        string choice = Console.ReadLine();
        // Do thing based on the player's choice
        switch (choice)
        {
            case "1":
                // Use a pokeball
                Pokeball.UsePokeball(currentPlayer, currentPlayer.Team[currentPlayer.CurrentPokemon], "standard");
                break;
            case "2":
                // Use a great ball
                Pokeball.UsePokeball(currentPlayer, currentPlayer.Team[currentPlayer.CurrentPokemon], "great");
                break;
            case "3":
                // Use an ultra ball
                Pokeball.UsePokeball(currentPlayer, currentPlayer.Team[currentPlayer.CurrentPokemon], "ultra");
                break;
            case "4":
                // go back to the item menu
                Fight.GoBack();
                break;
            default:
                // Print an error message
                Console.WriteLine("That is not a valid choice!");
                break;
        }
    }



    //Subclass for the potion
    public class Potion
    {

        
        //Method to use the potion
        public static void UsePotion(Player player, Pokemon playerPokemon, string potion_type)
        {
            int type_int = 0;
            //link the potion type to an int
            switch (potion_type)
            {
                case "standard":
                    type_int = 0;
                    break;
                case "super":
                    type_int = 1;
                    break;
                case "hyper":
                    type_int = 2;
                    break;
                default:
                    break;

            }

            switch(type_int)
            {
                case 0:
                    //If the player has a potion
                    if (player.Potion[type_int] > 0)
                    {
                        //Add 20 health to the player
                        playerPokemon.Health += 20;
                        //Remove 1 potion from the player
                        player.Potion[type_int] -= 1;
                        //If the player has more than 100 health
                        if (playerPokemon.Health > 100)
                        {
                            //Set the health to 100
                            playerPokemon.Health = 100;
                        }
                        //Print the health of the player
                        Console.WriteLine(playerPokemon.Name + " has " + playerPokemon.Health + " health remaining!");
                    }
                    //If the player doesn't have a potion
                    else
                    {
                        //Print that the player doesn't have a potion
                        Console.WriteLine(playerPokemon.Name + " doesn't have a potion!");
                    }
                    break;
                case 1:
                    //If the player has a potion
                    if (player.Potion[type_int] > 0)
                    {
                        //Add 50 health to the player
                        playerPokemon.Health += 50;
                        //Remove 1 potion from the player
                        player.Potion[type_int] -= 1;
                        //If the player has more than 100 health
                        if (playerPokemon.Health > 100)
                        {
                            //Set the health to 100
                            playerPokemon.Health = 100;
                        }
                        //Print the health of the player
                        Console.WriteLine(playerPokemon.Name + " has " + playerPokemon.Health + " health remaining!");
                    }
                    //If the player doesn't have a potion
                    else
                    {
                        //Print that the player doesn't have a potion
                        Console.WriteLine(playerPokemon.Name + " doesn't have a potion!");
                    }
                    break;
                case 2:
                    //If the player has a potion
                    if (player.Potion[type_int] > 0)
                    {
                        //Add 100 health to the player
                        playerPokemon.Health += 100;
                        //Remove 1 potion from the player
                        player.Potion[type_int] -= 1;
                        //If the player has more than 100 health
                        if (playerPokemon.Health > 100)
                        {
                            //Set the health to 100
                            playerPokemon.Health = 100;
                        }
                        //Print the health of the player
                    }
                    break;
                default:
                    break;
            }
        }
    }

    // Subclass for the pokeball
    public class Pokeball
    {

        //set an int list for the pokeball capture rate
        protected static float[] BallRate = new float[3] { 1, 1.5f, 2 };
        protected static float CaptureRate;

        //Method to use the pokeball
        public static void UsePokeball(Player player, Pokemon playerPokemon, string pokeball_type)
        {
            int type_int = 0;
            //link the pokeball type to an int
            switch (pokeball_type)
            {
                case "standard":
                    type_int = 0;
                    break;
                case "great":
                    type_int = 1;
                    break;
                case "ultra":
                    type_int = 2;
                    break;
                default:
                    break;

            }

            switch (type_int)
            {
                case 0:
                    CatchPokemon(player, playerPokemon, type_int);
                    break;
                case 1:
                    CatchPokemon(player, playerPokemon, type_int);
                    break;
                case 2:
                    CatchPokemon(player, playerPokemon, type_int);
                    break;
                default:
                    break;
            }
        }


        //method to catch the pokemon
        public static void CatchPokemon(Player player, Pokemon enemyPokemon, int type_int)
        {

            //If the player has a pokeball
            if (player.Pokeball[type_int] > 0)
            {
                //Remove 1 pokeball from the player
                player.Pokeball[type_int] -= 1;
            }
            else
            {
                //Print that the player doesn't have a pokeball
                Console.WriteLine(player.Name + " doesn't have a pokeball!");
            }

            //random number generator
            Random rnd = new Random();
            //random number
            CaptureRate = ((1 + (enemyPokemon.MaxHp * 3 - enemyPokemon.Health * 2) * (int)Math.Floor(enemyPokemon.CatchRate * BallRate[type_int])) / (enemyPokemon.MaxHp * 3)) / 256;
            
            //Divide the capture rate
            int result = (1048560 / (int)Math.Sqrt(Math.Sqrt(16711680 / CaptureRate)));
            //Round the result to lower
            result = (int)Math.Floor((double)result);

            //random number between 0 and 65535
            int CaptureChance = rnd.Next(0, 65535);
            //If the capture chance is lower than the capture rate
            if (result < CaptureRate)
            {
                player.AddPokemon(enemyPokemon);
            }
            //If the capture chance is higher than the capture rate
            else
            {
                //Print that the player hasn't caught the pokemon
                Console.WriteLine("The pokemon broke free!");
            }

            
        }
    }

}