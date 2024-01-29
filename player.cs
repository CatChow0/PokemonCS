// Class for player

using System;

// Player class

public class Player
{

    // initialize variables
    public Pokemon[] Team = new Pokemon[6];
    public int currentPokemon = 0;
    public string name; 

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


    // get the starter pokemon
    public void SetStarter()
    {
        // create a new pokemon
        Pokemon pokemon = Pokemon.CreatePokemon();

        // add the pokemon to the team
        Team[0] = pokemon;
    }

}