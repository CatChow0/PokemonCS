// Class for pokemon

using System;
using System.Diagnostics.Metrics;
using System.Drawing;

// Pokemon class

public class Pokemon : Entity
{
    public static Pokemon[] pokemons;
    //constructor
    public Pokemon(string name, int health, int armor, string type, int level, int catchRate, bool isCatchable, int maxHp, string attack, int dmg_attack, string attack2, int dmg_attack2, string attack3, int dmg_attack3, string attack_spe, int dmg_attack_spe) : base(name, health, armor, type, level, catchRate, IsCatchable, maxHp, attack, dmg_attack, attack2, dmg_attack2, attack3, dmg_attack3, attack_spe, dmg_attack_spe)
    {
    }

    // Create an pokemon and return it to the player
    public static void CreatePokemon()
    {
        // Create a new enemy
        Pokemon pikachu = new Pokemon("pikachu", 100, 5, "Electric", 5, 250, false, 100, "Bolt Strike", 8, "Electro Ball", 18, "Quick Attack", 5, "Thunder", 18);
        Pokemon salamèche = new Pokemon("salamèche", 140, 5, "Fire", 5, 250, false, 140, "Flamethrower", 18, "Ember", 5, "Scratch", 5, "Fire Blast", 18);
        Pokemon bulbizarre = new Pokemon("bulbizarre", 120, 5, "Grass", 5, 250, false, 120, "Razor Leaf", 18, "Vine Whip", 5, "Tackle", 5, "Solar Beam", 18);
        Pokemon carapuce = new Pokemon("carapuce", 160, 5, "Water", 5, 250, false, 160, "Hydro Pump", 18, "Bubble", 5, "Tackle", 5, "Surf", 18);
        pokemons = new Pokemon[4] {pikachu,salamèche,bulbizarre,carapuce};

        // Return the enemy
        return;
    }

}