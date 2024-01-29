// Class for player

using System;

// Player class

public class Player
{
    // initialize variables
    protected Pokemon[] team = new Pokemon[6];
    protected int currentPokemon = 0;
    protected string name; 

    // constructor
    public Player(string name)
    {
        this.name = name;
    }

    // getters and setters
    public Pokemon[] Team
    {
        get { return team; }
        set { team = value; }
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

    // get the starter pokemon
    public void GetStarter()
    {
        // create a new pokemon
        Pokemon pokemon = Pokemon.CreatePokemon();

        // add the pokemon to the team
        team[0] = pokemon;
    }

}