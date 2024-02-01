// Class for pokemon

using System;

// Pokemon class

public class Pokemon : Entity
{
    public static Pokemon[] pokemons;
    //constructor
    public Pokemon(string name, int health, int damage, int armor, string type, int level, int catchRate, bool IsCatchable, int maxHp) : base(name, health, damage, armor, type, level, catchRate, IsCatchable, maxHp)
    {
    }

    // Create an pokemon and return it to the player
    public static void CreatePokemon()
    {
        // Create a new enemy
        Pokemon pikachu = new Pokemon("pikachu", 100, 10, 5, "Electric", 5, 250, false, 100);
        Pokemon salamèche = new Pokemon("salamèche", 100, 10, 5, "Fire", 5, 250, true, 100);
        Pokemon bulblizarre = new Pokemon("bulblizar", 100, 10, 5, "Grass", 5, 250, true, 100);
        Pokemon carapuce = new Pokemon("carapuce", 100, 10, 5, "Water", 5, 250, true, 100);
        pokemons = new Pokemon[4] {pikachu,salamèche,bulblizarre,carapuce};

        // Return the enemy
        return;
    }

}