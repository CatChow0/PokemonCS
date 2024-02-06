// Class for pokemon

using System;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace PokemonCS
{

    // Pokemon class

    public class Pokemon : Entity
    {

        private static readonly string[] lines = File.ReadAllLines("pokedex.txt");
        //constructor
        public Pokemon(string name, int health, int armor, string type, int level, int catchRate, bool isCatchable, int maxHp, string attack, int dmg_attack, string attack2, int dmg_attack2, string attack3, int dmg_attack3, string attack_spe, int dmg_attack_spe, int xp, int use_nb_base_atk, int use_nb_atk, int use_nb_atk2, int use_nb_atk_spe, int max_nb_base_atk, int max_nb_atk, int max_nb_atk2, int max_nb_atk_spe) : base(name, health, armor, type, level, catchRate, isCatchable, maxHp, attack, dmg_attack, attack2, dmg_attack2, attack3, dmg_attack3, attack_spe, dmg_attack_spe, xp, use_nb_base_atk, use_nb_atk, use_nb_atk2, use_nb_atk_spe, max_nb_base_atk, max_nb_atk, max_nb_atk2, max_nb_atk_spe)
        {
        }

        // Create an pokemon using info from file and return it to the player
        public static Pokemon CreatePokemon(int lineIndex)
        {
            string[] info = lines[lineIndex].Split(',');
            Pokemon pokemon = new (info[0], int.Parse(info[1]), int.Parse(info[2]), info[3], int.Parse(info[4]), int.Parse(info[5]), bool.Parse(info[6]), int.Parse(info[7]), info[8], int.Parse(info[9]), info[10], int.Parse(info[11]), info[12], int.Parse(info[13]), info[14], int.Parse(info[15]), int.Parse(info[16]), int.Parse(info[17]), int.Parse(info[18]), int.Parse(info[19]), int.Parse(info[20]), int.Parse(info[21]), int.Parse(info[22]), int.Parse(info[23]), int.Parse(info[24]));
            return pokemon;

        }

        // method to add xp to the pokemon
        public void AddXp(int xp)
        {
            this.xp += xp;
            if (this.xp >= 100)
            {
                level += 1;
                this.xp = 0;
                maxHp += 5;
                health = maxHp;
                armor += 5;
                dmg_attack += 2;
                dmg_attack2 += 2;
                dmg_attack3 += 2;
                dmg_attack_spe += 2;
                use_nb_base_atk = max_nb_base_atk;
                use_nb_atk = max_nb_atk;
                use_nb_atk2 = max_nb_atk2;
                use_nb_atk_spe = max_nb_atk_spe;

                Console.WriteLine("Congratulations! " + name + " leveled up to level " + level + "!");
            }
        }

        // method to calculate the xp earned by defeating an enemy based on the level of the enemy and the level of the pokemon
        public int CalculateXp(int enemyLevel)
        {
            if (enemyLevel > level)
            {
                xp = (enemyLevel - level) * 10;
            }
            else
            {
                xp = (level - enemyLevel) * 10;
            }
            return xp;
        }

        // Add an egg to the player's team
        public static void AddEgg()
        {
            Pokemon egg = new ("Egg", 0, 0, "Normal", 1, 0, true, 0, "Tackle", 0, "Tackle", 0, "Tackle", 0, "Tackle", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            for (int i = 0; i < Intro.player.Team.Length; i++)
            {
                if (Intro.player.Team[i] == null )
                {
                    Intro.player.Team[i] = egg;
                    return;
                }

            }
            // Print a message
            Console.Clear();
            Fight.DrawBorderLine();
            Console.WriteLine("Your team is full! You can't carry more than 6 pokemons!");
            Fight.DrawBorderLine();
            Console.ReadKey();
            Console.Clear();
            
        }

        // method to hatch the egg and create a new pokemon
        public static void HatchEgg()
        {
            // Create a new random pokemon
            Random random = new ();
            int index = random.Next(0, 10);
            Pokemon pokemon = CreatePokemon(index);
            //look for the egg in the player's team
            for (int i = 0; i < Intro.player.Team.Length; i++)
            {
                if (Intro.player.Team[i].name == "Egg")
                {
                    Intro.player.Team[i] = pokemon;
                    break;
                }
            }



            Parallel.Invoke(() =>
            {
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("The egg is hatching...");
                Fight.DrawBorderLine();
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("Congratulations! Your egg hatched into a " + pokemon.name + "!");
                Fight.DrawBorderLine();
                Console.ReadKey();
                Console.Clear();
                Map.ColorMap();
                Map.SpawnPlayer(Map.xPos, Map.yPos);
            });
        }

    }
}