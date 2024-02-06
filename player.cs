// Class for player

using System;

namespace PokemonCS
{

    // Player class

    public class Player
    {

        // initialize variables
        public Pokemon[] Team = new Pokemon[6];
        public int currentPokemon = 0;
        public string name;
        public int money = 0;
        public int[] potion = new int[3];
        public int[] pokeball = new int[3];
        public int Step = 0;

        // constructor
        public Player(string name)
        {
            this.name = name;
        }

        // getters and setters

        public Pokemon[] PlayerTeam
        {
            get { return Team; }
            set { Team = value; }
        }

        public int CurrentPokemon
        {
            get { return currentPokemon; }
            set { currentPokemon = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public int[] Potion
        {
            get { return potion; }
            set { potion = value; }
        }

        public int[] Pokeball
        {
            get { return pokeball; }
            set { pokeball = value; }
        }

        public int PlayerStep
        {
            get { return Step; }
            set { Step = value; }
        }


        // get the starter pokemon
        public void SetStarter()
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Now, you will chose your starter pokemon!");
            Console.WriteLine("You can chose between:");
            Console.WriteLine("1. Salamèche          2. Bulbizarre          3. Carapuce");
            Console.WriteLine("Press the number of the pokemon you want to chose!");
            Fight.DrawBorderLine();
            // get the player's choice
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Fight.DrawBorderLine();
                    Console.WriteLine("You chose Salamèche!");
                    Team[0] = Pokemon.CreatePokemon(2);
                    break;
                case "2":
                    Team[0] = Pokemon.CreatePokemon(5);
                    break;
                case "3":
                    Team[0] = Pokemon.CreatePokemon(8);
                    break;
                default:
                    Fight.DrawBorderLine();
                    Console.WriteLine("Please enter a number.");
                    Fight.DrawBorderLine();
                    SetStarter();
                    break;
            }

            return;
        }

        // Ask player name
        public static string AskName()
        {
            // Ask the player for their name
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            if (name != null)
            {
                Console.WriteLine("Hi " + name + "!");
            }
            else
            {
                AskName();
            }
            return name;
        }

        // method to change pokemon
        public void ChangePokemon()
        {
            // print the player's team
            PrintTeam();

            // ask the player which pokemon they want to switch to
            Console.WriteLine("Which pokemon do you want to switch to?");
            string choice = Console.ReadLine();

            // if the choice is not a number
            if (!int.TryParse(choice, out int result))
            {
                // print an error message
                Console.WriteLine("That is not a valid choice!");
                return;
            }

            // if the choice is not in the team
            if (result > Team.Length || result < 0)
            {
                // print an error message
                Console.WriteLine("That is not a valid choice!");
                return;
            }

            // if the choice is the current pokemon
            if (result == currentPokemon)
            {
                // print an error message
                Console.WriteLine("That pokemon is already in battle!");
                return;
            }

            // switch the pokemon
            currentPokemon = result - 1;

            // print a message
            Console.Clear();
            Fight.PrintStats();
            Fight.DrawBorderLine();
            Console.WriteLine("You switched to " + Team[currentPokemon].Name + "!");
            Fight.DrawBorderLine();
            Console.ReadKey();
            Console.Clear();
        }

        // method to print the player's team
        public void PrintTeam()
        {
            // print the player's team
            Console.WriteLine("Your team:");
            for (int i = 0; i < Team.Length; i++)
            {
                // if the pokemon is not null
                if (Team[i] != null)
                {
                    // print the pokemon's name
                    Console.WriteLine(i + 1 + ". " + Team[i].Name);
                }
            }
        }

        // Add item to the player
        public void AddItem(int amount, string item, string type)
        {

            int type_id = 0;
            switch (type)
            {
                case "standard":
                    type_id = 0;
                    break;
                case "great":
                    type_id = 1;
                    break;
                case "ultra":
                    type_id = 2;
                    break;
                default:
                    Console.WriteLine("Error in the type of the item");
                    break;
            }

            if (item == "Pokeball")
            {
                pokeball[type_id] += amount;
            }
            else if (item == "Potion")
            {
                potion[type_id] += amount;
            }
        }

        //method to add a new pokemon to the team in a free slot
        public void AddPokemon(Pokemon pokemon)
        {
            //loop through the team
            for (int i = 0; i < Team.Length; i++)
            {
                //if the slot is empty
                if (Team[i] == null)
                {
                    //add the pokemon to the team
                    Team[i] = pokemon;
                    //print a message
                    Console.Clear();
                    Fight.PrintStats();
                    Fight.DrawBorderLine();
                    Console.WriteLine("You caught " + pokemon.Name + "!");
                    Fight.DrawBorderLine();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
        }

        // method to buy an item
        public void BuyItem(int amount, string item, string type)
        {
            // ask the number of items the player wants to buy
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("How many " + item + " do you want to buy?");
            Fight.DrawBorderLine();
            string choice = Console.ReadLine();
            // if the choice is not a number
            if (!int.TryParse(choice, out int result))
            {
                // print an error message
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("That is not a valid choice!");
                Fight.DrawBorderLine();
                Console.ReadKey();
                Console.Clear();
                Menu.PrintBuyMenu(Intro.player);
                return;
            }
            // calculate the total cost
            int total = amount * result;
            // if the player have enough money
            if (money >= total)
            {
                // subtract the amount from the player's money
                money -= total;
                // add the amount to the player
                AddItem(result, item, type);
                // print a message
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("You bought " + result + " " + item + "!");
                Fight.DrawBorderLine();
                Console.ReadKey();
                Console.Clear();
                Menu.PrintBuyMenu(Intro.player);
            }
            else
            {
                // print an error message
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("You don't have enough money!");
                Fight.DrawBorderLine();
                Console.ReadKey();
                Console.Clear();
                Menu.PrintBuyMenu(Intro.player);
            }
        }

        // method to sell an item
        public void SellItem(int amount, string item, string type)
        {
            // ask the number of items the player wants to sell
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("How many " + item + " do you want to sell?");
            Fight.DrawBorderLine();
            string choice = Console.ReadLine();
            // if the choice is not a number
            if (!int.TryParse(choice, out int result))
            {
                // print an error message
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("That is not a valid choice!");
                Fight.DrawBorderLine();
                Console.ReadKey();
                Console.Clear();
                Menu.PrintSellMenu(Intro.player);
                return;
            }
            // calculate the total cost
            int total = amount * result;
            // add the amount to the player's money
            money += total;
            // subtract the amount from the player
            AddItem(-result, item, type);
            // print a message
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("You sold " + result + " " + item + "!");
            Fight.DrawBorderLine();
            Console.ReadKey();
            Console.Clear();
            Menu.PrintSellMenu(Intro.player);
        }

        // Check the step number
        public static void CheckStep()
        {
            if (CheckEgg())
            {
                Intro.player.Step += 1;
                if (Intro.player.Step >= 1000 && Map.mapType =="map")
                {
                    Pokemon.HatchEgg();
                    Intro.player.Step = 0;
                }
            }
            else
            {
                return;
            }
        }

        // check if the player got an egg in his team
        public static bool CheckEgg()
        {
            for (int i = 0; i < Intro.player.Team.Length; i++)
            {
                if (Intro.player.Team[i] != null && Intro.player.Team[i].Name == "Egg")
                {
                    return true;
                }
            }
            return false;
        }

    }


}