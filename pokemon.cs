// Class for pokemon

using System;
using System.Diagnostics.Metrics;
using System.Drawing;

// Pokemon class

public class Pokemon : Entity
{
    //constructor
    public Pokemon(string name, int health, int armor, string type, int level, int catchRate, bool isCatchable, int maxHp, string attack, int dmg_attack, string attack2, int dmg_attack2, string attack3, int dmg_attack3, string attack_spe, int dmg_attack_spe, int xp, int use_nb_base_atk, int use_nb_atk, int use_nb_atk2, int use_nb_atk_spe, int max_nb_base_atk, int max_nb_atk, int max_nb_atk2, int max_nb_atk_spe) : base(name, health, armor, type, level, catchRate, isCatchable, maxHp, attack, dmg_attack, attack2, dmg_attack2, attack3, dmg_attack3, attack_spe, dmg_attack_spe, xp, use_nb_base_atk, use_nb_atk, use_nb_atk2, use_nb_atk_spe, max_nb_base_atk, max_nb_atk, max_nb_atk2, max_nb_atk_spe)
    {
    }

    // Create an pokemon using info from file and return it to the player
    public static Pokemon CreatePokemon(int lineIndex)
    {
        string[] lines = System.IO.File.ReadAllLines("pokedex.txt");
        string[] info = lines[lineIndex].Split(',');
        Pokemon pokemon = new Pokemon(info[0], int.Parse(info[1]), int.Parse(info[2]), info[3], int.Parse(info[4]), int.Parse(info[5]), bool.Parse(info[6]), int.Parse(info[7]), info[8], int.Parse(info[9]), info[10], int.Parse(info[11]), info[12], int.Parse(info[13]), info[14], int.Parse(info[15]), int.Parse(info[16]), int.Parse(info[17]), int.Parse(info[18]), int.Parse(info[19]), int.Parse(info[20]), int.Parse(info[21]), int.Parse(info[22]), int.Parse(info[23]), int.Parse(info[24]));
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
            this.dmg_attack2 += 2;
            this.dmg_attack3 += 2;
            this.dmg_attack_spe += 2;
            this.use_nb_base_atk = max_nb_base_atk;
            this.use_nb_atk = max_nb_atk;
            this.use_nb_atk2 = max_nb_atk2;
            this.use_nb_atk_spe = max_nb_atk_spe;

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