// Class for pokemon

using System;

// Pokemon class

public class Pokemon : Entity
{
    //constructor
    public Pokemon(string name, int health, int damage, int armor, string type, int level) : base(name, health, damage, armor, type, level)
    {
    }

    // Create an pokemon and return it to the player
    public static Pokemon CreatePokemon()
    {
        // Create a new pokemon
        Pokemon pokemon = new Pokemon("Pikachu", 100, 10, 5, "Electric" , 5);

        // Return the pokemon
        return pokemon;
    }
    
}