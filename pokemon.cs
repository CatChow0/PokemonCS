// Class for pokemon

using System;

// Pokemon class

protected class Pokemon : Entity
{
    //constructor
    public Pokemon(string name, int health, int damage, int armor, string type) : base(name, health, damage, armor, type)
    {
    }

    // Create an pokemon and return it to the player
    public static Pokemon CreatePokemon()
    {
        // Create a new pokemon
        Pokemon pokemon = new Pokemon("Pikachu", 100, 10, 5, "Electric");

        // Return the pokemon
        return pokemon;
    }
    
}