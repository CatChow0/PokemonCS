using System;
using static System.Net.Mime.MediaTypeNames;

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
    protected string attack_spe;
    protected int dmg_attack_spe;
    protected int xp;

    //constructor
    public Entity(string name, int health, int armor, string type, int level, int catchRate, bool isCatchable, int maxHp, string attack, int dmg_attack, string attack_spe, int dmg_attack_spe, int xp)
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
        this.attack_spe = attack_spe;
        this.dmg_attack_spe = dmg_attack_spe;
        this.xp = xp;
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

    public int dmg_Attack
    {
        get { return dmg_attack; }
        set { dmg_attack = value; }
    }

    public string Attack_Spe
    {
        get { return attack_spe; }
        set { attack_spe = value; }
    }

    public int dmg_Attack_Spe
    {
        get { return dmg_attack_spe; }
        set { dmg_attack_spe = value; }
    }
    
    public int Xp
    {
        get { return xp; }
        set { xp = value; }
    }

    public void PrintStats(string type)
    {
        if(type == "Player")
        {
            //print player stats
            Console.SetCursorPosition(10, 30);
            Console.WriteLine("┌────────────────────────────┐");
            Console.SetCursorPosition(10, 31);
            Console.Write("│" + name);
            //Get the number of spaces to print the border correctly
            CheckSpaceNeed(name);
            Console.SetCursorPosition(10, 32);
            Console.Write("│Lv: " + level);
            CheckSpaceNeed("Lv: " + level);
            //Print life into a bar of 20
            Console.SetCursorPosition(10, 33);
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
            Console.SetCursorPosition(10, 33);
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
                if ( health > maxHp / 2)
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
            Console.SetCursorPosition(10, 34);
            Console.Write("│" + health + "/" + maxHp);
            CheckSpaceNeed(health + "/" + maxHp);
            Console.SetCursorPosition(10, 35);
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

    //method to draw a sprite
    public void DrawSprite(string sprite)
    {
        //draw the sprite
        Console.SetCursorPosition(10, 10);
        Console.WriteLine(sprite);
    }

    //method to check the number of spaces needed to print the border correctly
    public void CheckSpaceNeed(string name)
    {
        int spaceNeed = 28 - name.Length;
        for (int i = 0; i < spaceNeed; i++)
        {
            Console.Write(" ");
        }
        Console.Write("│");
    }

}