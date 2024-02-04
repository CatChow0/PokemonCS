// Class for pokemon

using System;

// Pokemon class

public class Pokemon : Entity
{
    //constructor
    public Pokemon(string name, int health, int damage, int armor, string type, int level, int catchRate, bool IsCatchable, int maxHp, string attack, int dmg_attack, string attack_spe, int dmg_attack_spe, int xp) : base(name, health, armor, type, level, catchRate, IsCatchable, maxHp, attack, dmg_attack, attack_spe, dmg_attack_spe, xp)
    {
    }

    // Create an pokemon using info from file and return it to the player
    public static Pokemon CreatePokemon(int lineIndex)
    {
        string[] lines = System.IO.File.ReadAllLines("pokedex.txt");
        string[] info = lines[lineIndex].Split(',');
        Pokemon pokemon = new Pokemon(info[0], int.Parse(info[1]), int.Parse(info[2]), int.Parse(info[3]), info[4], int.Parse(info[5]), int.Parse(info[6]), bool.Parse(info[7]), int.Parse(info[8]), info[9], int.Parse(info[10]), info[11], int.Parse(info[12]), int.Parse(info[13]));
        return pokemon;

    }

    // method to add xp to the pokemon
    public void AddXp(int xp)
    {
        this.xp += xp;
        if (this.xp >= 100)
        {
            this.level += 1;
            this.xp = 0;
            this.maxHp += 5;
            this.health = this.maxHp;
            this.armor += 5;
            this.dmg_attack += 2;
            this.dmg_attack_spe += 2;
            Console.WriteLine("Congratulations! " + this.name + " leveled up to level " + this.level + "!");
        }
    }

    // method to calculate the xp earned by defeating an enemy based on the level of the enemy and the level of the pokemon
    public int CalculateXp(int enemyLevel)
    {
        int xp = 0;
        if (enemyLevel > this.level)
        {
            xp = (enemyLevel - this.level) * 10;
        }
        else
        {
            xp = (this.level - enemyLevel) * 10;
        }
        return xp;
    }


}