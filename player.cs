// Class for player

using System;

// Player class

protected class Player : Entity
{
    //constructor
    public Player(string name, int health, int damage, int armor, string type) : base(name, health, damage, armor, type)
    {
    }

    // create pokemon team
    public static Pokemon[] CreateTeam()
    {
        // Create a new array of pokemon
        Pokemon[] team = new Pokemon[6];

        // Create a new pokemon
        Pokemon pokemon = Pokemon.CreatePokemon();

        // Add the pokemon to the team
        team[0] = pokemon;

        // Return the team
        return team;
    }

}