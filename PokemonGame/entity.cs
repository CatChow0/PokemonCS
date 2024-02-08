namespace PokemonCS
{

    // Entity class
    public class Entity
    {
        //set variables for entitys
        protected string name;
        protected int health;
        protected int armor;
        protected string type;
        protected int level;
        protected int catchRate;
        protected bool isCatchable;
        protected int maxHp;
        protected string attack;
        protected int dmg_attack;
        protected string attack2;
        protected int dmg_attack2;
        protected string attack3;
        protected int dmg_attack3;
        protected string attack_spe;
        protected int dmg_attack_spe;
        public int xp;
        protected int use_nb_base_atk;
        protected int use_nb_atk;
        protected int use_nb_atk2;
        protected int use_nb_atk_spe;
        protected int max_nb_base_atk;
        protected int max_nb_atk;
        protected int max_nb_atk2;
        protected int max_nb_atk_spe;
        protected bool CanEvolve;

        //constructor
        public Entity(string name, int health, int armor, string type, int level, int catchRate, bool isCatchable, int maxHp, string attack, int dmg_attack, string attack2, int dmg_attack2, string attack3, int dmg_attack3, string attack_spe, int dmg_attack_spe, int xp, int use_nb_base_atk, int use_nb_atk, int use_nb_atk2, int use_nb_atk_spe, int max_nb_base_atk, int max_nb_atk, int max_nb_atk2, int max_nb_atk_spe, bool CanEvolve)
        {
            this.name = name;
            this.health = health;
            this.armor = armor;
            this.type = type;
            this.level = level;
            this.catchRate = catchRate;
            this.isCatchable = isCatchable;
            this.maxHp = maxHp;
            this.attack = attack;
            this.dmg_attack = dmg_attack;
            this.attack2 = attack2;
            this.dmg_attack = dmg_attack2;
            this.attack3 = attack3;
            this.dmg_attack = dmg_attack3;
            this.attack_spe = attack_spe;
            this.dmg_attack_spe = dmg_attack_spe;
            this.xp = xp;
            this.use_nb_base_atk = use_nb_base_atk;
            this.use_nb_atk = use_nb_atk;
            this.use_nb_atk = use_nb_atk2;
            this.use_nb_atk_spe = use_nb_atk_spe;
            this.max_nb_base_atk = max_nb_base_atk;
            this.max_nb_atk = max_nb_atk;
            this.max_nb_atk2 = max_nb_atk2;
            this.max_nb_atk_spe = max_nb_atk_spe;
            this.CanEvolve = CanEvolve;
        }

        //getters and setters
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int CatchRate
        {
            get { return catchRate; }
            set { catchRate = value; }
        }

        public bool IsCatchable
        {
            get { return isCatchable; }
            set { isCatchable = value; }
        }

        public int MaxHp
        {
            get { return maxHp; }
            set { maxHp = value; }
        }

        public string Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int Dmg_Attack
        {
            get { return dmg_attack; }
            set { dmg_attack = value; }
        }

        public string Attack2
        {
            get { return attack2; }
            set { attack2 = value; }
        }

        public int Dmg_Attack2
        {
            get { return dmg_attack2; }
            set { dmg_attack2 = value; }
        }

        public string Attack3
        {
            get { return attack3; }
            set { attack3 = value; }
        }

        public int Dmg_Attack3
        {
            get { return dmg_attack3; }
            set { dmg_attack3 = value; }
        }

        public string Attack_Spe
        {
            get { return attack_spe; }
            set { attack_spe = value; }
        }

        public int Dmg_Attack_Spe
        {
            get { return dmg_attack_spe; }
            set { dmg_attack_spe = value; }
        }

        public int Xp
        {
            get { return xp; }
            set { xp = value; }
        }

        public int Use_nb_baseAtk
        {
            get { return use_nb_base_atk; }
            set { use_nb_base_atk = value; }
        }

        public int Use_nb_Atk
        {
            get { return use_nb_atk; }
            set { use_nb_atk = value; }
        }

        public int Use_nb_Atk2
        {
            get { return use_nb_atk2; }
            set { use_nb_atk2 = value; }
        }

        public int Use_nb_Atk_Spe
        {
            get { return use_nb_atk_spe; }
            set { use_nb_atk_spe = value; }
        }

        public int Max_nb_base_Atk
        {
            get { return max_nb_base_atk; }
            set { max_nb_base_atk = value; }
        }

        public int Max_nb_Atk1
        {
            get { return max_nb_atk; }
            set { max_nb_atk = value; }
        }

        public int Max_nb_Atk2
        {
            get { return max_nb_atk2; }
            set { max_nb_atk2 = value; }
        }

        public int Max_nb_Atk_Spe
        {
            get { return max_nb_atk_spe; }
            set { max_nb_atk_spe = value; }
        }

        public bool canEvolve
        {
            get { return CanEvolve; }
            set { CanEvolve = value; }
        }

        public void PrintStats(string type)
        {
            if (type == "Player")
            {
                int y;
                (_, y) = Console.GetCursorPosition();
                //print player stats
                Console.SetCursorPosition(10, y);
                Console.WriteLine("┌────────────────────────────┐");
                Console.SetCursorPosition(10, y+1);
                Console.Write("│" + name);
                //Get the number of spaces to print the border correctly
                CheckSpaceNeed(name);
                Console.SetCursorPosition(10, y+2);
                Console.Write("│Lv: " + level);
                CheckSpaceNeed("Lv: " + level);
                //Print life into a bar of 20
                Console.SetCursorPosition(10, y+3);
                //print life into a bar background
                Console.Write("    ");
                for (int i = 0; i < 25; i++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("█");
                }
                Console.ResetColor();
                Console.WriteLine("│");
                Console.ResetColor();
                Console.SetCursorPosition(10, y+3);
                Console.Write("│HP: ");
                if (health > maxHp / 4 && health <= maxHp / 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (health <= maxHp / 4)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                for (int i = 0; i < Math.Floor((double)(health * 25 / maxHp)) - 1; i++)
                {
                    if (health > maxHp / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (health < maxHp / 2 && health > maxHp / 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (health < maxHp / 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    Console.Write("█");
                }
                Console.ResetColor();
                Console.SetCursorPosition(10, y+4);
                Console.Write("│" + health + "/" + maxHp);
                CheckSpaceNeed(health + "/" + maxHp);
                Console.SetCursorPosition(10, y+5);
                Console.WriteLine("└────────────────────────────┘");
            }
            else if (type == "Enemy")
            {
                //write all the enemy stats in the top right corner
                Console.SetCursorPosition(150, 2);
                //print enemy stats
                Console.WriteLine("┌────────────────────────────┐");
                Console.SetCursorPosition(150, 3);
                Console.Write("│" + name);
                CheckSpaceNeed(name);
                Console.SetCursorPosition(150, 4);
                Console.Write("│Lv: " + level);
                CheckSpaceNeed("Lv: " + level);
                //Print life into a bar of 20
                Console.SetCursorPosition(150, 5);
                Console.Write("    ");
                for (int i = 0; i < 25; i++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("█");
                }
                Console.ResetColor();
                Console.WriteLine("│");
                Console.ResetColor();
                Console.SetCursorPosition(150, 5);
                Console.Write("│HP: ");
                if (health > maxHp / 4 && health <= maxHp / 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (health <= maxHp / 4)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                for (int i = 0; i < Math.Floor((double)(health * 25 / maxHp)) - 1; i++)
                {

                    Console.Write("█");
                }
                Console.ResetColor();
                Console.SetCursorPosition(150, 6);
                Console.Write("│" + health + "/" + maxHp);
                CheckSpaceNeed(health + "/" + maxHp);
                Console.SetCursorPosition(150, 7);
                Console.WriteLine("└────────────────────────────┘");
            }

        }

        //method to check the number of spaces needed to print the border correctly
        public static void CheckSpaceNeed(string name)
        {
            int spaceNeed = 28 - name.Length;
            for (int i = 0; i < spaceNeed; i++)
            {
                Console.Write(" ");
            }
            Console.Write("│");
        }

    }
}