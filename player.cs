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
        // create a new pokemon
        Pokemon pokemon = Pokemon.CreatePokemon();

        // add the pokemon to the team
        Team[0] = pokemon;

        return pokemon;
    }

    // Ask player name
    public static string AskName()
    {
        // Ask the player for their name
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        if(name != null)
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
    public void Intro()
    {
        Console.WriteLine("Welcome to the world of Pokemon!");
        Console.WriteLine("You will start with 3 pokeballs and 3 potions!");
        AddItem(3,"Pokeball", "standard");
        AddItem(3,"Potion", "standard");
        Console.WriteLine("Good luck on your journey!");
        Console.WriteLine("Press any key to continue...");
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

    // Add potion to the player
    public void AddPotion(int amount, int type)
    {
        potion[type] += amount;
    }

}