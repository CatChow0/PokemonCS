// Class for player

using System;

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

    // constructor
    public Player(string name)
    {
        this.name = name;
    }

    // getters and setters

    public Pokemon[] team
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


    // get the starter pokemon
    public Pokemon SetStarter()
    {
        Pokemon.CreatePokemon();
        Pokemon pokemon = null;
        Console.Clear();
        Fight.DrawBorderLine();
        Console.WriteLine("Now, you will chose your starter pokemon!");
        Console.WriteLine("You can chose between:");
        Console.WriteLine("1. Salamèche          2. Bulbizarre          3. Carapuce");
        Console.WriteLine("Press the number of the pokemon you want to chose!");
        Fight.DrawBorderLine();
        // get the player's choice
        string choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
                Fight.DrawBorderLine();
                Console.WriteLine("You chose Salamèche!");
                Team[0] = Pokemon.pokemons[1];
                break;
            case "2":
                Team[0] = Pokemon.pokemons[2];
                break;
            case "3":
                Team[0] = Pokemon.pokemons[3];
                break;
            default:
                Fight.DrawBorderLine();
                Console.WriteLine("Please enter a number.");
                Fight.DrawBorderLine();
                break;
        }

        return pokemon;
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
        Console.WriteLine("You switched to " + Team[currentPokemon].Name + "!");
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

    // Intro to the game and give 3 standard pokeballs and 3 standard potions
    public void PrintStartScreen()
    {
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
    }
    
    // Add item to the player
    public void AddItem(int amount,string item, string type)
    {

        int type_id = 0;
        switch(type)
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

        if(item == "Pokeball")
        {
            pokeball[type_id] += amount;
        }
        else if(item == "Potion")
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
                Console.WriteLine("You caught " + pokemon.Name + "!");
                //stop the loop
                break;
            }
        }
    }

}