// Class for pokemon
namespace PokemonCS
{

    // Pokemon class

    public class Pokemon : Entity
    {
        private static readonly string[] lines = File.ReadAllLines("pokedex.txt");
        //constructor
        public Pokemon(string name, int health, int armor, string type, int level, int catchRate, bool isCatchable, int maxHp, string attack, int dmg_attack, string attack2, int dmg_attack2, string attack3, int dmg_attack3, string attack_spe, int dmg_attack_spe, int xp, int use_nb_base_atk, int use_nb_atk, int use_nb_atk2, int use_nb_atk_spe, int max_nb_base_atk, int max_nb_atk, int max_nb_atk2, int max_nb_atk_spe, bool CanEvolve) : base(name, health, armor, type, level, catchRate, isCatchable, maxHp, attack, dmg_attack, attack2, dmg_attack2, attack3, dmg_attack3, attack_spe, dmg_attack_spe, xp, use_nb_base_atk, use_nb_atk, use_nb_atk2, use_nb_atk_spe, max_nb_base_atk, max_nb_atk, max_nb_atk2, max_nb_atk_spe, CanEvolve)
        {
        }

        // Create an pokemon using info from file and return it to the player
        public static Pokemon CreatePokemon(int lineIndex)
        {
            string[] info = lines[lineIndex].Split(',');
            Pokemon pokemon = new (info[0], int.Parse(info[1]), int.Parse(info[2]), info[3], int.Parse(info[4]), int.Parse(info[5]), bool.Parse(info[6]), int.Parse(info[7]), info[8], int.Parse(info[9]), info[10], int.Parse(info[11]), info[12], int.Parse(info[13]), info[14], int.Parse(info[15]), int.Parse(info[16]), int.Parse(info[17]), int.Parse(info[18]), int.Parse(info[19]), int.Parse(info[20]), int.Parse(info[21]), int.Parse(info[22]), int.Parse(info[23]), int.Parse(info[24]), bool.Parse(info[25]));
            return pokemon;

        }

        // method to add xp to the pokemon
        public void AddXp(int XpEarn)
        {
            xp += XpEarn;
            if (xp >= 100)
            {
                level += 1;
                xp = 0;
                maxHp += 2;
                health = maxHp;
                armor += 2;
                dmg_attack += 2;
                dmg_attack2 += 2;
                dmg_attack3 += 2;
                dmg_attack_spe += 2;
                use_nb_base_atk = max_nb_base_atk;
                use_nb_atk = max_nb_atk;
                use_nb_atk2 = max_nb_atk2;
                use_nb_atk_spe = max_nb_atk_spe;

                Fight.DrawBorderLine();
                Console.WriteLine("Congratulations! " + name + " leveled up to level " + level + "!");
                Console.WriteLine("Your " + name + " has now " + maxHp + " HP, " + armor + " armor and does " + dmg_attack + " damage with " + attack + "!");
                Console.WriteLine("Press any key to continue...");
                Fight.DrawBorderLine();
                Console.ReadKey();
                Console.Clear();
                // check if the pokemon can evolve
                if ((level == 10 || level == 15) && CanEvolve)
                {
                    Evolve(name, Intro.player);
                }

            }
        }

        // method to evolve the pokemon
        public static void Evolve(string name, Player currentPlayer)
        {

            //Search for the pokemon evolution in the pokedex lines based on the name of the pokemon
            string[] info = new string[26];
            for (int i = 0; i < lines.Length; i++)
            {
                info = lines[i].Split(',');
                if (info[0] == name)
                {
                    info = lines[i + 1].Split(',');
                    break;
                }
            }

            Pokemon pokemon = new(info[0], int.Parse(info[1]), int.Parse(info[2]), info[3], int.Parse(info[4]), int.Parse(info[5]), bool.Parse(info[6]), int.Parse(info[7]), info[8], int.Parse(info[9]), info[10], int.Parse(info[11]), info[12], int.Parse(info[13]), info[14], int.Parse(info[15]), int.Parse(info[16]), int.Parse(info[17]), int.Parse(info[18]), int.Parse(info[19]), int.Parse(info[20]), int.Parse(info[21]), int.Parse(info[22]), int.Parse(info[23]), int.Parse(info[24]), bool.Parse(info[25]));

            //look for the pokemon in the player's team
            for (int i = 0; i < currentPlayer.Team.Length; i++)
            {
                if (currentPlayer.Team[i].name == name)
                {
                    currentPlayer.Team[i] = pokemon;
                    break;
                }
            }

            if (currentPlayer.Name == "Test")
            {
                return;
            }
            Parallel.Invoke(() =>
            {
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("Congratulations! Your " + name + " evolved into a " + pokemon.name + "!");
                Fight.DrawBorderLine();
                Console.ReadKey();
                Console.Clear();
                Map.ColorMap();
                Map.SpawnPlayer(Map.xPos, Map.yPos);
            });
        }



        // method to calculate the xp earned by defeating an enemy based on the level of the enemy and the level of the pokemon
        public int CalculateXp(int enemyLevel)
        {
            int XpEarn;
            if (enemyLevel > level)
            {
                XpEarn = (enemyLevel - level) * 10;
            }
            else
            {
                XpEarn = (level - enemyLevel) * 10;
            }
            return XpEarn;
        }

        // Add an egg to the player's team
        public static void AddEgg(Player currentPlayer)
        {
            Pokemon egg = new ("Egg", 0, 0, "Normal", 1, 0, true, 0, "Tackle", 0, "Tackle", 0, "Tackle", 0, "Tackle", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false);
            for (int i = 0; i < currentPlayer.Team.Length; i++)
            {
                if (currentPlayer.Team[i] == null )
                {
                    currentPlayer.Team[i] = egg;
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

        //method to check the type advantage of the pokemon against the enemy pokemon type and return the damage multiplier(based on the type chart)
        public static float CheckTypeAdvantages(string atkType, string defType)
        {

            switch (atkType)
            {
                case "Normal":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 1;
                        case "Water":
                            return 1;
                        case "Grass":
                            return 1;
                        case "Ice":
                            return 1;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 1;
                        case "Ground":
                            return 1;
                        case "Flying":
                            return 1;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 1;
                        case "Rock":
                            return 0.5f;
                        case "Ghost":
                            return 0;
                        case "Dragon":
                            return 1;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Electric":
                    switch (defType)
                    {
                        case "Electric":
                            return 0.5f;
                        case "Fire":
                            return 1;
                        case "Water":
                            return 2;
                        case "Grass":
                            return 0.5f;
                        case "Ice":
                            return 1;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 1;
                        case "Ground":
                            return 0;
                        case "Flying":
                            return 2;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 1;
                        case "Rock":
                            return 1;
                        case "Ghost":
                            return 1;
                        case "Dragon":
                            return 0.5f;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Fire":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 0.5f;
                        case "Water":
                            return 0.5f;
                        case "Grass":
                            return 2;
                        case "Ice":
                            return 2;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 1;
                        case "Ground":
                            return 1;
                        case "Flying":
                            return 1;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 2;
                        case "Rock":
                            return 0.5f;
                        case "Ghost":
                            return 1;
                        case "Dragon":
                            return 0.5f;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Water":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 2;
                        case "Water":
                            return 0.5f;
                        case "Grass":
                            return 0.5f;
                        case "Ice":
                            return 1;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 1;
                        case "Ground":
                            return 2;
                        case "Flying":
                            return 1;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 1;
                        case "Rock":
                            return 2;
                        case "Ghost":
                            return 1;
                        case "Dragon":
                            return 0.5f;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Grass":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 0.5f;
                        case "Water":
                            return 2;
                        case "Grass":
                            return 0.5f;
                        case "Ice":
                            return 2;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 0.5f;
                        case "Ground":
                            return 2;
                        case "Flying":
                            return 0.5f;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 0.5f;
                        case "Rock":
                            return 2;
                        case "Ghost":
                            return 1;
                        case "Dragon":
                            return 0.5f;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Ice":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 0.5f;
                        case "Water":
                            return 0.5f;
                        case "Grass":
                            return 2;
                        case "Ice":
                            return 0.5f;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 1;
                        case "Ground":
                            return 2;
                        case "Flying":
                            return 2;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 1;
                        case "Rock":
                            return 1;
                        case "Ghost":
                            return 1;
                        case "Dragon":
                            return 2;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Fighting":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 1;
                        case "Water":
                            return 1;
                        case "Grass":
                            return 1;
                        case "Ice":
                            return 2;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 0.5f;
                        case "Ground":
                            return 1;
                        case "Flying":
                            return 0.5f;
                        case "Psychic":
                            return 0.5f;
                        case "Bug":
                            return 0.5f;
                        case "Rock":
                            return 2;
                        case "Ghost":
                            return 0;
                        case "Dragon":
                            return 1;
                        case "Normal":
                            return 2;
                    }
                    break;
                case "Poison":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 1;
                        case "Water":
                            return 1;
                        case "Grass":
                            return 2;
                        case "Ice":
                            return 1;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 0.5f;
                        case "Ground":
                            return 0.5f;
                        case "Flying":
                            return 1;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 1;
                        case "Rock":
                            return 0.5f;
                        case "Ghost":
                            return 0.5f;
                        case "Dragon":
                            return 1;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Ground":
                    switch (defType)
                    {
                        case "Electric":
                            return 2;
                        case "Fire":
                            return 2;
                        case "Water":
                            return 1;
                        case "Grass":
                            return 0.5f;
                        case "Ice":
                            return 1;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 2;
                        case "Ground":
                            return 1;
                        case "Flying":
                            return 0;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 0.5f;
                        case "Rock":
                            return 2;
                        case "Ghost":
                            return 1;
                        case "Dragon":
                            return 1;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Flying":
                    switch (defType)
                    {
                        case "Electric":
                            return 0.5f;
                        case "Fire":
                            return 1;
                        case "Water":
                            return 1;
                        case "Grass":
                            return 2;
                        case "Ice":
                            return 1;
                        case "Fighting":
                            return 2;
                        case "Poison":
                            return 1;
                        case "Ground":
                            return 1;
                        case "Flying":
                            return 1;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 2;
                        case "Rock":
                            return 0.5f;
                        case "Ghost":
                            return 1;
                        case "Dragon":
                            return 1;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Psychic":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 1;
                        case "Water":
                            return 1;
                        case "Grass":
                            return 1;
                        case "Ice":
                            return 1;
                        case "Fighting":
                            return 2;
                        case "Poison":
                            return 2;
                        case "Ground":
                            return 1;
                        case "Flying":
                            return 1;
                        case "Psychic":
                            return 0.5f;
                        case "Bug":
                            return 1;
                        case "Rock":
                            return 1;
                        case "Ghost":
                            return 1;
                        case "Dragon":
                            return 1;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Bug":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 0.5f;
                        case "Water":
                            return 1;
                        case "Grass":
                            return 2;
                        case "Ice":
                            return 1;
                        case "Fighting":
                            return 0.5f;
                        case "Poison":
                            return 0.5f;
                        case "Ground":
                            return 1;
                        case "Flying":
                            return 0.5f;
                        case "Psychic":
                            return 2;
                        case "Bug":
                            return 1;
                        case "Rock":
                            return 1;
                        case "Ghost":
                            return 0.5f;
                        case "Dragon":
                            return 1;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Rock":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 1;
                        case "Water":
                            return 1;
                        case "Grass":
                            return 1;
                        case "Ice":
                            return 2;
                        case "Fighting":
                            return 0.5f;
                        case "Poison":
                            return 1;
                        case "Ground":
                            return 0.5f;
                        case "Flying":
                            return 2;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 2;
                        case "Rock":
                            return 1;
                        case "Ghost":
                            return 1;
                        case "Dragon":
                            return 1;
                        case "Normal":
                            return 1;
                    }
                    break;
                case "Ghost":
                    switch (defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 1;
                        case "Water":
                            return 1;
                        case "Grass":
                            return 1;
                        case "Ice":
                            return 1;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 1;
                        case "Ground":
                            return 1;
                        case "Flying":
                            return 1;
                        case "Psychic":
                            return 2;
                        case "Bug":
                            return 1;
                        case "Rock":
                            return 1;
                        case "Ghost":
                            return 2;
                        case "Dragon":
                            return 1;
                        case "Normal":
                            return 0;
                    }
                    break;
                case "Dragon":
                    switch(defType)
                    {
                        case "Electric":
                            return 1;
                        case "Fire":
                            return 1;
                        case "Water":
                            return 1;
                        case "Grass":
                            return 1;
                        case "Ice":
                            return 1;
                        case "Fighting":
                            return 1;
                        case "Poison":
                            return 1;
                        case "Ground":
                            return 1;
                        case "Flying":
                            return 1;
                        case "Psychic":
                            return 1;
                        case "Bug":
                            return 1;
                        case "Rock":
                            return 1;
                        case "Ghost":
                            return 1;
                        case "Dragon":
                            return 2;
                        case "Normal":
                            return 1;
                    }
                    break;

            }
            return 1;
        }
    }
}