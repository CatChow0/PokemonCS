// Class for player
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
        public static void SetStarter(string choice, Player CurrentPlayer)
        {
            
            switch (choice)
            {
                case "1":
                    //if the player is test
                    if (CurrentPlayer.Name == "Test")
                    {
                        CurrentPlayer.Team[0] = Pokemon.CreatePokemon(2);
                        break;
                    }
                    Console.Clear();
                    Fight.DrawBorderLine();
                    Console.WriteLine("You chose Salamèche!");
                    CurrentPlayer.Team[0] = Pokemon.CreatePokemon(2);
                    Fight.DrawBorderLine();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    //if the player is test
                    if (CurrentPlayer.Name == "Test")
                    {
                        CurrentPlayer.Team[0] = Pokemon.CreatePokemon(5);
                        break;
                    }
                    Console.Clear();
                    Fight.DrawBorderLine();
                    Console.WriteLine("You chose Bulbizarre!");
                    CurrentPlayer.Team[0] = Pokemon.CreatePokemon(5);
                    Fight.DrawBorderLine();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    //if the player is test
                    if (CurrentPlayer.Name == "Test")
                    {
                        CurrentPlayer.Team[0] = Pokemon.CreatePokemon(8);
                        break;
                    }
                    Console.Clear();
                    Fight.DrawBorderLine();
                    Console.WriteLine("You chose Carapuce!");
                    CurrentPlayer.Team[0] = Pokemon.CreatePokemon(8);
                    Fight.DrawBorderLine();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Fight.DrawBorderLine();
                    Console.WriteLine("Please enter a number.");
                    Fight.DrawBorderLine();
                    Menu.StarterMenu();
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

        // Get Random Item
        public static void GetRandomItem(Player currentPlayer)
        {
            Random random = new();
            int index = random.Next(0, 1);
            string item;
            if (index == 0)
            {
                 item = "Potion";
            }
            else
            {
                 item = "Pokeball";
            }

            // Get the type of the item
            int type = random.Next(0, 99);
            string type_item;
            if (type > 89)
            {
                type_item = "ultra";
            }
            else if (type > 69 && type < 89)
            {
                type_item = "great";
            }
            else
            {
                type_item = "standard";
            }

            // get the amount of the item based on the type
            int amount = 0;
            switch (type_item)
            {
                case "standard":
                    amount = random.Next(1, 5);
                    break;
                case "great":
                    amount = random.Next(1, 3);
                    break;
                case "ultra":
                    amount = 1;
                    break;
            }

            // add the item to the player
            currentPlayer.AddItem(amount, item, type_item);
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
        public static void CheckStep(Player currentPlayer)
        {
            if (CheckEgg(currentPlayer))
            {
                currentPlayer.Step += 1;
                if (currentPlayer.Step >= 1000 && Map.mapType =="map")
                {
                    Pokemon.HatchEgg();
                    currentPlayer.Step = 0;
                }
            }
            else
            {
                return;
            }
        }

        // check if the player got an egg in his team
        public static bool CheckEgg(Player currentPlayer)
        {
            for (int i = 0; i < currentPlayer.Team.Length; i++)
            {
                if (currentPlayer.Team[i] != null && currentPlayer.Team[i].Name == "Egg")
                {
                    return true;
                }
            }
            return false;
        }

        // method to heal and restore the use_nb for the player's team
        public void HealTeam()
        {
            for (int i = 0; i < Team.Length; i++)
            {
                if (Team[i] != null)
                {
                    // set the current health to the max;
                    Team[i].Health = Team[i].MaxHp;
                    // set the use_nb to the max;
                    Team[i].Use_nb_baseAtk = Team[i].Max_nb_base_Atk;
                    Team[i].Use_nb_Atk = Team[i].Max_nb_Atk1;
                    Team[i].Use_nb_Atk2 = Team[i].Max_nb_Atk2;
                    Team[i].Use_nb_Atk_Spe = Team[i].Max_nb_Atk_Spe;
                }
            }
        }

        // method to check if the player's team is alive
        public bool CheckTeamState()
        {
            bool isAlive = true;
            //while a pokemon is alive in team return true
            while (isAlive)
            {
                for (int i = 0; i < Team.Length; i++)
                {
                    if (Team[i].health <= 0 && Team[i] != null)
                    {
                        isAlive = false;
                    }
                }
            }

            return isAlive;
        }


    }


}