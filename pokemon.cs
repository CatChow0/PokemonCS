// Class for pokemon

using System;

// Pokemon class

public class Pokemon : Entity
{
    //constructor
    public Pokemon(string name, int health, int damage, int armor, string type, int level, int catchRate, bool IsCatchable, int maxHp) : base(name, health, damage, armor, type, level, catchRate, IsCatchable, maxHp)
    {
    }

    // Create an pokemon and return it to the player
    public static Pokemon CreatePokemon()
    {
        Pokemon pikachu = new Pokemon("Pikachu", 100, 10, 5, "Electric", 5, 250, false, 100);
        // Create a new pokemon
        Pokemon[] pokemon = new Pokemon[1] {pikachu};

        // Return the pokemon
        return pokemon;
    }

    public static Pokemon CreateEnemy()
    {
        // Create a new enemy
        Pokemon enemy = new Pokemon("salamèche", 100, 10, 5, "Fire", 5, 250, true, 100);

        // Return the enemy
        return enemy;
    }

}