// Class for pokemon

using System;

// Pokemon class

public class Pokemon : Entity
{
    //constructor
    public Pokemon(string name, int health, int damage, int armor, string type, int level, int catchRate, bool IsCatchable, int maxHp, string attack, int dmg_attack, string attack_spe, int dmg_attack_spe) : base(name, health, armor, type, level, catchRate, IsCatchable, maxHp, attack, dmg_attack, attack_spe, dmg_attack_spe)
    {
    }

    // Create an pokemon using info from file and return it to the player
    public static Pokemon CreatePokemon(int lineIndex)
    {
        string[] lines = System.IO.File.ReadAllLines("pokedex.txt");
        string[] info = lines[lineIndex].Split(',');
        Pokemon pokemon = new Pokemon(info[0], int.Parse(info[1]), int.Parse(info[2]), int.Parse(info[3]), info[4], int.Parse(info[5]), int.Parse(info[6]), bool.Parse(info[7]), int.Parse(info[8]));
        return pokemon;

    }
}