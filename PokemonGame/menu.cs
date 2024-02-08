// Class for menu
namespace PokemonCS
{

    // Menu class
    public class Menu
    {
        //Start screen menu for new game or load game
        public static void StartMenu()
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Welcome to Pokemon!");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Please enter your choice: ");
            Fight.DrawBorderLine();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Intro.PrintIntro();
                    break;
                case "2":
                    // Load game
                    LoadGame();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    StartMenu();
                    break;
            }
        }

        //method for pause menu
        public static void PauseMenu()
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("1. Continue");
            Console.WriteLine("2. Team");
            Console.WriteLine("3. Bag");
            Console.WriteLine("4.Pokedex");
            Console.WriteLine("5. Save Game");
            Console.WriteLine("6. Exit Game");
            Console.WriteLine("Please enter your choice: ");
            Fight.DrawBorderLine();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Map.CheckMap();
                    Map.SpawnPlayer(Map.xPos, Map.yPos);
                    break;
                case "2":
                    // Show team and can use potion to restore hp
                    TeamMenu();
                    break;
                case "3":
                    // Bag
                    Console.Clear();
                    Fight.DrawBorderLine();
                    Console.WriteLine("Your bag:");
                    Console.WriteLine("Potions: " + Intro.player.Potion[0]);
                    Console.WriteLine("Super Potions: " + Intro.player.Potion[1]);
                    Console.WriteLine("Hyper Potions: " + Intro.player.Potion[2]);
                    Console.WriteLine("Pokeballs: " + Intro.player.Pokeball[0]);
                    Console.WriteLine("Great Balls: " + Intro.player.Pokeball[1]);
                    Console.WriteLine("Ultra Balls: " + Intro.player.Pokeball[2]);
                    Console.WriteLine("Money : " + Intro.player.Money);
                    Console.WriteLine("Press any key to continue...");
                    Fight.DrawBorderLine();
                    Console.ReadKey();
                    PauseMenu();
                    break;
                case "4":
                    // Pokedex
                    PokedexMenu();
                    break;
                case "5":
                    // Save game
                    SaveGame(false);
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    PauseMenu();
                    break;
            }
        }
        public static void PokedexMenu()
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Pokedex: \n ");

            // Read data from pokedex.txt
            string pokedexPath = "pokedex.txt";

            if (File.Exists(pokedexPath))
            {
                string[] pokedexEntries = File.ReadAllLines(pokedexPath);

                // Display Pokémon names
                for (int i = 0; i < pokedexEntries.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {pokedexEntries[i].Split(',')[0]}");
                }

                Console.WriteLine("Enter the number of the Pokémon to view its stats (or 0 to exit): ");

                // Get user choice
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= pokedexEntries.Length)
                {
                    // Display Pokémon stats
                    DisplayPokemonStats(pokedexEntries[choice - 1]);
                }
                else if (choice == 0)
                {
                    PauseMenu();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    PokedexMenu();
                }
            }
            else
            {
                Console.WriteLine("Pokedex is empty.");
            }

            Console.WriteLine("Press any key to continue...");
            Fight.DrawBorderLine();
            Console.ReadKey();
            PokedexMenu();
        }
        private static void DisplayPokemonStats(string pokemonData)
        {
            string[] info = pokemonData.Split(',');

            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine($"Name: {info[0]}");
            Console.WriteLine($"Type: {info[3]}");
            Console.WriteLine($"Health: {info[1]}/{info[7]}");
            Console.WriteLine($"Attack: {info[10]}");
            Console.WriteLine($"Special Attack: {info[12]}");
            Fight.DrawBorderLine();
        }
        //Starter selection menu
        public static void StarterMenu()
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
            Player.SetStarter(choice, Intro.player);
        }

        //method to show the team
        public static void TeamMenu()
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Your team:");
            for (int i = 0; i < 6; i++)
            {
                if (Intro.player.Team[i] != null)
                {
                    Console.WriteLine(i + 1 + ". " + Intro.player.Team[i].Name + " Lv: " + Intro.player.Team[i].Level + " HP: " + Intro.player.Team[i].Health + "/" + Intro.player.Team[i].MaxHp);
                }
                else
                {
                    Console.WriteLine(i + 1 + ". Empty");
                }
            }
            Fight.DrawBorderLine();
            Console.WriteLine("More info : 1 - 6 || Exit : 7");
            Fight.DrawBorderLine();
            string teamChoice = Console.ReadLine();
            //check if choice is a number
            if (int.TryParse(teamChoice, out int result))
            {
                if (result >= 1 && result <= 6)
                {
                    if (Intro.player.Team[result - 1] != null)
                    {
                        Console.Clear();
                        Fight.DrawBorderLine();
                        Console.WriteLine("Name: " + Intro.player.Team[result - 1].Name);
                        Console.WriteLine("Level: " + Intro.player.Team[result - 1].Level);
                        Console.WriteLine("Health: " + Intro.player.Team[result - 1].Health + "/" + Intro.player.Team[result - 1].MaxHp);
                        Console.WriteLine("Attack: " + Intro.player.Team[result - 1].Attack);
                        Console.WriteLine("Special Attack: " + Intro.player.Team[result - 1].Attack_Spe);
                        Console.WriteLine("Type: " + Intro.player.Team[result - 1].Type);
                        Console.WriteLine("Xp : " + Intro.player.Team[result - 1].Xp + "/100");
                        Console.ResetColor();
                        Fight.DrawBorderLine();
                        Console.WriteLine("Use Potion : 1 || Rename : 2 || Exit : 3");
                        Fight.DrawBorderLine();
                        string choice = Console.ReadLine();
                        // Check if choice is a number
                        if (int.TryParse(choice, out int result2))
                        {
                            if (result2 == 1)
                            {
                                // Use potion
                                if (Intro.player.Potion[0] > 0)
                                {
                                    Item.PrintPotionMenu(Intro.player);
                                    TeamMenu();
                                }
                                else
                                {
                                    Console.WriteLine("You don't have any potions!");
                                    Console.ReadKey();
                                    TeamMenu();
                                }
                            }
                            else if (result2 == 2)
                            {
                                // Rename pokemon
                                Console.Clear();
                                Fight.DrawBorderLine();
                                Console.WriteLine("Enter the new name for " + Intro.player.Team[result - 1].Name + ":");
                                Fight.DrawBorderLine();
                                string newName = Console.ReadLine();
                                string oldName = Intro.player.Team[result - 1].Name;
                                Intro.player.Team[result - 1].Name = newName;
                                Console.Clear();
                                Fight.DrawBorderLine();
                                Console.WriteLine("You renamed " + oldName + " to " + newName + "!");
                                Console.WriteLine("Press any key to continue...");
                                Fight.DrawBorderLine();
                                Console.ReadKey();
                                TeamMenu();
                            }
                            else if (result2 == 3)
                            {
                                TeamMenu();
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice");
                                Console.ReadKey();
                                TeamMenu();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                            Console.ReadKey();
                            TeamMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Empty slot");
                        Console.ReadKey();
                        TeamMenu();
                    }
                }
                else if (result == 7)
                {
                    PauseMenu();
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    TeamMenu();
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
                Console.ReadKey();
                TeamMenu();
            }


            Console.Clear();
        }

        // method to show the vendor menu
        public static void VendorMenu()
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Welcome to the PokeShop!");
            Console.WriteLine("1. Buy");
            Console.WriteLine("2. Sell");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Please enter your choice: ");
            Fight.DrawBorderLine();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Buy
                    PrintBuyMenu(Intro.player);
                    VendorMenu();
                    break;
                case "2":
                    // Sell
                    PrintSellMenu(Intro.player);
                    VendorMenu();
                    break;
                case "3":
                    Console.Clear();
                    Map.ReadHouse();
                    Map.SpawnPlayer(Map.xPos, Map.yPos);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    VendorMenu();
                    break;
            }
        }

        // method to print the buy menu
        public static void PrintBuyMenu(Player player)
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Welcome to the PokeShop!");
            Console.WriteLine("Your Money :" + player.Money);
            Console.WriteLine("1. Potion - 100$");
            Console.WriteLine("2. Super Potion - 200$");
            Console.WriteLine("3. Hyper Potion - 300$");
            Console.WriteLine("4. Pokeball - 200$");
            Console.WriteLine("5. Great Ball - 300$");
            Console.WriteLine("6. Ultra Ball - 400$");
            Console.WriteLine("7. Pokemon Egg - 1000$");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Please enter your choice: ");
            Fight.DrawBorderLine();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Buy potion
                    player.BuyItem(100, "Potion", "standard");
                    break;
                case "2":
                    // Buy super potion
                    player.BuyItem(200, "Potion", "great");
                    break;
                case "3":
                    // Buy hyper potion
                    player.BuyItem(300, "Potion", "ultra");
                    break;
                case "4":
                    // Buy pokeball
                    player.BuyItem(200, "Pokeball", "standard");
                    break;
                case "5":
                    // Buy great ball
                    player.BuyItem(300, "Pokeball", "great");
                    break;
                case "6":
                    // Buy ultra ball
                    player.BuyItem(400, "Pokeball", "ultra");
                    break;
                case "7":
                    // Buy egg
                    if (player.Money >= 1000)
                    {
                        player.Money -= 1000;
                        Pokemon.AddEgg(Intro.player);
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money!");
                        Console.ReadKey();
                        PrintBuyMenu(player);
                    }
                    break;
                case "8":
                    VendorMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    PrintBuyMenu(player);
                    break;
            }

        }

        // method to print the sell menu
        public static void PrintSellMenu(Player player)
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Welcome to the PokeShop!");
            Console.WriteLine("1. Sell Item");
            Console.WriteLine("2. Sell Pokemon");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Please enter your choice: ");
            Fight.DrawBorderLine();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Sell item
                    PrintSellItemMenu(player);
                    break;
                case "2":
                    // Sell pokemon
                    PrintSellPokemonMenu(player);
                    break;
                case "3":
                    VendorMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    PrintSellMenu(player);
                    break;
            }
        }

        // method to print the sell item menu
        public static void PrintSellItemMenu(Player player)
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Welcome to the PokeShop!");
            Console.WriteLine("Your Money :" + player.Money);
            Console.WriteLine("1. Potion - 50$");
            Console.WriteLine("2. Super Potion - 100$");
            Console.WriteLine("3. Hyper Potion - 150$");
            Console.WriteLine("4. Pokeball - 100$");
            Console.WriteLine("5. Great Ball - 150$");
            Console.WriteLine("6. Ultra Ball - 200$");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Please enter your choice: ");
            Fight.DrawBorderLine();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Sell potion
                    player.SellItem(50, "Potion", "standard");
                    break;
                case "2":
                    // Sell super potion
                    player.SellItem(100, "Potion", "great");
                    break;
                case "3":
                    // Sell hyper potion
                    player.SellItem(150, "Potion", "ultra");
                    break;
                case "4":
                    // Sell pokeball
                    player.SellItem(100, "Pokeball", "standard");
                    break;
                case "5":
                    // Sell great ball
                    player.SellItem(150, "Pokeball", "great");
                    break;
                case "6":
                    // Sell ultra ball
                    player.SellItem(200, "Pokeball", "ultra");
                    break;
                case "7":
                    VendorMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    PrintSellItemMenu(player);
                    break;
            }
        }

        // method to print the sell pokemon menu
        public static void PrintSellPokemonMenu(Player player)
        {
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Welcome to the PokeShop!");
            Console.WriteLine("Your team:");
            for (int i = 0; i < 6; i++)
            {
                if (player.Team[i] != null)
                {
                    Console.WriteLine(i + 1 + ". " + player.Team[i].Name + " Lv: " + player.Team[i].Level + " HP: " + player.Team[i].Health + "/" + player.Team[i].MaxHp);
                }
                else
                {
                    Console.WriteLine(i + 1 + ". Empty");
                }
            }
            Fight.DrawBorderLine();
            Console.WriteLine("Please enter the number of the pokemon you want to sell: ");
            string choice = Console.ReadLine();
            // Check if choice is a number
            if (int.TryParse(choice, out int result))
            {
                if (result >= 1 && result <= 6)
                {
                    if (player.Team[result - 1] != null)
                    {
                        Console.Clear();
                        Fight.DrawBorderLine();
                        Console.WriteLine("You sold " + player.Team[result - 1].Name + " for " + player.Team[result - 1].Level * 100 + "$!");
                        player.Money += player.Team[result - 1].Level * 100;
                        player.Team[result - 1] = null;
                        Console.WriteLine("Press any key to continue...");
                        Fight.DrawBorderLine();
                        Console.ReadKey();
                        PrintSellMenu(player);
                    }
                    else
                    {
                        Console.WriteLine("Empty slot");
                        Console.ReadKey();
                        PrintSellMenu(player);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    PrintSellMenu(player);
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
                Console.ReadKey();
                PrintSellPokemonMenu(player);
            }
        }

        //method to save the game in a file
        public static void SaveGame(bool hidden)
        {
            //Open the data file and write the player's info
            string path = "data.txt";
            string[] lines = new string[22];

            lines[0] = Intro.player.Name;

            // append to lines the info of the player's inventory
            for (int i = 0; i < 3; i++)
            {
                lines[i + 1] = Intro.player.Potion[i].ToString();
            }

            for (int i = 0; i < 3; i++)
            {
                lines[i + 4] = Intro.player.Pokeball[i].ToString();
            }

            // append to lines the info of the player's position
            lines[7] = Map.xPos.ToString();
            lines[8] = Map.yPos.ToString();
            // Update the player's position in the map
            if (Map.mapType == "house")
            {
                Map.xHouse = Map.xPos;
                Map.yHouse = Map.yPos;
            }
            else if (Map.mapType == "map")
            {
                Map.xMap = Map.xPos;
                Map.yMap = Map.yPos;
            }
            lines[9] = Map.yMap.ToString();
            lines[10] = Map.xMap.ToString();
            lines[11] = Map.yHouse.ToString();
            lines[12] = Map.xHouse.ToString();
            lines[13] = Map.mapType;

            // append to lines the player's money
            lines[14] = Intro.player.Money.ToString();
            lines[15] = Intro.player.Step.ToString();

            // append to lines the info of the player's team while checking if the pokemon is null
            for (int i = 0; i < 6; i++)
            {
                if (Intro.player.Team[i] != null)
                {
                    lines[i + 16] = Intro.player.Team[i].Name + "," + Intro.player.Team[i].Health + "," + Intro.player.Team[i].Armor + "," + Intro.player.Team[i].Type + "," + Intro.player.Team[i].Level + "," + Intro.player.Team[i].CatchRate + "," + Intro.player.Team[i].IsCatchable + "," + Intro.player.Team[i].MaxHp + "," + Intro.player.Team[i].Attack + "," + Intro.player.Team[i].Dmg_Attack + "," + Intro.player.Team[i].Attack2 + "," + Intro.player.Team[i].Dmg_Attack2 + "," + Intro.player.Team[i].Attack3 + "," + Intro.player.Team[i].Dmg_Attack3 + "," + Intro.player.Team[i].Attack_Spe + "," + Intro.player.Team[i].Dmg_Attack_Spe + "," + Intro.player.Team[i].Xp + "," + Intro.player.Team[i].Use_nb_baseAtk + "," + Intro.player.Team[i].Use_nb_Atk + "," + Intro.player.Team[i].Use_nb_Atk2 + "," + Intro.player.Team[i].Use_nb_Atk_Spe + "," + Intro.player.Team[i].Max_nb_base_Atk + "," + Intro.player.Team[i].Max_nb_Atk1 + "," + Intro.player.Team[i].Max_nb_Atk2 + "," + Intro.player.Team[i].Max_nb_Atk_Spe + "," + Intro.player.Team[i].canEvolve;
                }
                else
                {
                    lines[i + 16] = "null";
                }
            }

            //write the lines to the file
            File.WriteAllLines(path, lines);

            if (hidden == false)
            {
                // Save the game
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("Game saved!");
                Console.WriteLine("Press any key to continue...");
                Fight.DrawBorderLine();
                Console.ReadKey();
                Console.Clear();
                PauseMenu();
            }
        }

        //method to load the game from a file
        public static void LoadGame()
        {
            //Open the data file and read the player's info
            string path = "data.txt";
            string[] lines = File.ReadAllLines(path);

            // create a new player
            Intro.player = new Player(lines[0]);

            // append to the player's inventory the info from the file
            for (int i = 0; i < 3; i++)
            {
                Intro.player.Potion[i] = int.Parse(lines[i + 1]);
            }

            for (int i = 0; i < 3; i++)
            {
                Intro.player.Pokeball[i] = int.Parse(lines[i + 4]);
            }

            // append to the player's position the info from the file
            Map.xPos = int.Parse(lines[7]);
            Map.yPos = int.Parse(lines[8]);
            Map.yMap = int.Parse(lines[9]);
            Map.xMap = int.Parse(lines[10]);
            Map.yHouse = int.Parse(lines[11]);
            Map.xHouse = int.Parse(lines[12]);
            Map.mapType = lines[13];

            // append to the player's money the info from the file
            Intro.player.Money = int.Parse(lines[14]);
            Intro.player.Step = int.Parse(lines[15]);

            // append to the player's team the info from the file while checking if the pokemon is null
            for (int i = 0; i < 6; i++)
            {
                if (lines[i + 16] != "null")
                {
                    string[] info = lines[i + 16].Split(',');
                    Intro.player.Team[i] = new Pokemon(info[0], int.Parse(info[1]), int.Parse(info[2]), info[3], int.Parse(info[4]), int.Parse(info[5]), bool.Parse(info[6]), int.Parse(info[7]), info[8], int.Parse(info[9]), info[10], int.Parse(info[11]), info[12], int.Parse(info[13]), info[14], int.Parse(info[15]), int.Parse(info[16]), int.Parse(info[17]), int.Parse(info[18]), int.Parse(info[19]), int.Parse(info[20]), int.Parse(info[21]), int.Parse(info[22]), int.Parse(info[23]), int.Parse(info[24]), bool.Parse(info[25]));
                }
            }

            // Load the game
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Game loaded!");
            Console.WriteLine("Press any key to continue...");
            Fight.DrawBorderLine();
            Console.ReadKey();
            Console.Clear();
            Map.CheckMap();
            Map.SpawnPlayer(Map.xPos, Map.yPos);
        }


        public static void SplashScreen()
        {
            // Intro to the game and give 3 standard pokeballs and 3 standard potions
            string asciiArt = "\t\t\t                                  ,'\\\n" +
                                  "\t\t\t    _.----.        ____         ,'  _\\   ___    ___     ____\n" +
                                  "\t\t\t_,-'       `.     |    |  /`.   \\,-'    |   \\  /   |   |    \\  |`.\n" +
                                  "\t\t\t\\      __    \\    '-.  | /   `.  ___    |    \\/    |   '-.   \\ |  |\n" +
                                  "\t\t\t \\.    \\ \\   |  __  |  |/    ,','_  `.  |          | __  |    \\|  |\n" +
                                  "\t\t\t   \\    \\/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |\n" +
                                  "\t\t\t    \\     ,-'/  /   \\    ,'   | \\/ / ,`.|         /  /   \\  |     |\n" +
                                  "\t\t\t     \\    \\ |   \\_/  |   `-.  \\    `'  /|  |    ||   \\_/  | |\\    |\n" +
                                  "\t\t\t      \\    \\ \\      /       `-.`.___,-' |  |\\  /| \\      /  | |   |\n" +
                                  "\t\t\t       \\    \\ `.__,'|  |`-._    `|      |__| \\/ |  `.__,'|  | |   |\n" +
                                  "\t\t\t        \\_.-'       |__|    `-._ |              '-.|     '-.| |   |\n" +
                                  "\t\t\t                                `'                            '-._|\n" +
                                  "                                             Press any key to continue...\n" +
                                  "\t\t\t\t\t             `;,;.;,;.;.'\n" +
                                  "\t\t\t\t\t              ..:;:;::;: \n" +
                                  "\t\t\t\t\t        ..--''' '' ' ' '''--.  \n" +
                                  "\t\t\t\t\t      /' .   .'        '.   .`\\\n" +
                                  "\t\t\t\t\t     | /    /            \\   '.|\n" +
                                  "\t\t\t\t\t     | |   :             :    :|\n" +
                                  "\t\t\t\t\t   .'| |   :             :    :|\n" +
                                  "\t\t\t\t\t ,: /\\ \\.._\\ __..===..__/_../ /`.\n" +
                                  "\t\t\t\t\t|'' |  :.|  `'          `'  |.'  ::.\n" +
                                  "\t\t\t\t\t|   |  ''|    :'';          | ,  `''\\\n" +
                                  "\t\t\t\t\t|.:  \\/  | /'-.`'   ':'.-'\\ |  \\,   |\n" +
                                  "\t\t\t\t\t| '  /  /  | / |...   | \\ |  |  |';'|\n" +
                                  "\t\t\t\t\t \\ _ |:.|  |_\\_|`.'   |_/_|  |.:| _ |\n" +
                                  "\t\t\t\t\t/,.,.|' \\__       . .      __/ '|.,.,\\\n" +
                                  "\t\t\t\t\t     | ':`.`----._____.---'.'   |\n" +
                                  "\t\t\t\t\t      \\   `:\"\"\"------ - '\"\"' |   | \n" +
                                  "\t\t\t\t\t       ',-,-',             .'-=,=,";

            Console.WriteLine(asciiArt);
            Console.ReadKey();
            Console.Clear();
            StartMenu();
        }


    }
}