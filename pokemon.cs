// Class for pokemon

using System;

// Pokemon class

public class Pokemon : Entity
{
    public static Pokemon[] pokemons;
    //constructor
    public Pokemon(string name, int health, int damage, int armor, string type, int level, int catchRate, bool IsCatchable, int maxHp, string attack, int dmg_attack, string attack_spe, int dmg_attack_spe) : base(name, health, armor, type, level, catchRate, IsCatchable, maxHp, attack, dmg_attack, attack_spe, dmg_attack_spe)
    {
    }

    // Create an pokemon and return it to the player
    public static void CreatePokemon()
    {
        // Create a new enemy
        Pokemon pikachu = new Pokemon("pikachu", 100, 10, 5, "Electric", 5, 250, false, 100, "Bolt Strike", 8, "Electro Ball", 18);
        Pokemon salamèche = new Pokemon("salamèche", 100, 10, 5, "Fire", 5, 250, true, 100, "Nitocharge", 8, "Flame Thrower", 18);
        Pokemon bulblizarre = new Pokemon("bulblizar", 100, 10, 5, "Grass", 5, 250, true, 100, "Seed Balls", 8, "Eco Sphere", 18);
        Pokemon carapuce = new Pokemon("carapuce", 100, 10, 5, "Water", 5, 250, true, 100, "Aqua Tail", 8, "Water Gun", 18);
        pokemons = new Pokemon[4] {pikachu,salamèche,bulblizarre,carapuce};

        // Return the enemy
        return;
    }

}