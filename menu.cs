// Class for menu
using System;

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
        Console.WriteLine("4. Save Game");
        Console.WriteLine("5. Exit Game");
        Console.WriteLine("Please enter your choice: ");
        Fight.DrawBorderLine();
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Clear();
                Map.ReadMap();
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
                Console.WriteLine("Pokeballs: " + Intro.player.Pokeball[0]);
                Console.WriteLine("Press any key to continue...");
                Fight.DrawBorderLine();
                Console.ReadKey();
                PauseMenu();
                break;
            case "4":
                // Save game
                SaveGame();
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice");
                Console.ReadKey();
                PauseMenu();
                break;
        }
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
                Console.WriteLine((i + 1) + ". " + Intro.player.Team[i].Name + " Lv: " + Intro.player.Team[i].Level + " HP: " + Intro.player.Team[i].Health + "/" + Intro.player.Team[i].MaxHp);
            }
            else
            {
                Console.WriteLine((i + 1) + ". Empty");
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



    //method to save the game in a file
    public static void SaveGame()
    {
        //Open the data file and write the player's info
        string path = "data.txt";
        string[] lines = new string[15];

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

        // append to lines the info of the player's team while checking if the pokemon is null
        for (int i = 0; i < 6; i++)
        {
            if (Intro.player.Team[i] != null)
            {
                lines[i + 9] = Intro.player.Team[i].Name + "," + Intro.player.Team[i].Health + "," + "10" + "," + Intro.player.Team[i].Armor + "," + Intro.player.Team[i].Type + "," + Intro.player.Team[i].Level + "," + Intro.player.Team[i].CatchRate + "," + Intro.player.Team[i].IsCatchable + "," + Intro.player.Team[i].MaxHp + "," + Intro.player.Team[i].Attack + "," + Intro.player.Team[i].dmg_Attack + "," + Intro.player.Team[i].Attack_Spe + "," + Intro.player.Team[i].dmg_Attack_Spe + "," + Intro.player.Team[i].Xp;
            }
            else
            {
                lines[i + 9] = "null";
            }
        }

        //write the lines to the file
        System.IO.File.WriteAllLines(path, lines);

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

    //method to load the game from a file
    public static void LoadGame()
    {
        //Open the data file and read the player's info
        string path = "data.txt";
        string[] lines = System.IO.File.ReadAllLines(path);

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

        // append to the player's team the info from the file while checking if the pokemon is null
        for (int i = 0; i < 6; i++)
        {
            if (lines[i + 9] != "null")
            {
                string[] info = lines[i + 9].Split(',');
                Intro.player.Team[i] = new Pokemon(info[0], int.Parse(info[1]), int.Parse(info[2]), int.Parse(info[3]), info[4], int.Parse(info[5]), int.Parse(info[6]), bool.Parse(info[7]), int.Parse(info[8]), info[9], int.Parse(info[10]), info[11], int.Parse(info[12]), int.Parse(info[13]));
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
        Map.ReadMap();
        Map.SpawnPlayer(Map.xPos, Map.yPos);
    }


    public static void SplachScreen()
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
