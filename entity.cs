using System;

// Entity class
public class Entity
{
    //set variables for entity
    protected string name;
    protected int health;
    protected int damage;
    protected int armor;
    protected string type;
    protected int level;
    protected int catchRate;
    protected bool isCatchable;
    protected int maxHp;

    //constructor
    public Entity(string name, int health, int damage, int armor, string type, int level, int catchRate, bool isCatchable, int maxHp)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
        this.armor = armor;
        this.type = type;
        this.level = level;
        this.catchRate = catchRate;
        this.isCatchable = isCatchable;
        this.maxHp = maxHp;
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

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
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

    public void PrintStats(string type)
    {
        if(type == "Player")
        {
            //print player stats
            Console.SetCursorPosition(10, 30);
            Console.WriteLine("==============================");
            Console.SetCursorPosition(10, 31);
            Console.WriteLine(" " + name + " ");
            Console.SetCursorPosition(10, 32);
            Console.Write(" Lv: " + level);
            //Print life into a bar of 20
            Console.SetCursorPosition(10, 33);
            Console.Write(" HP: ");
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
            for (int i = 0; i < health / 5; i++)
            {
                Console.Write("█");
            }
            Console.ResetColor();
            Console.SetCursorPosition(10, 34);
            Console.WriteLine(" " + health + "/" + maxHp);
            Console.SetCursorPosition(10, 35);
            Console.WriteLine("==============================");
        }
        else if (type == "Enemy")
        {
            //write all the enemy stats in the top right corner
            Console.SetCursorPosition(150, 2);
            //print enemy stats
            Console.WriteLine("==============================");
            Console.SetCursorPosition(150, 3);
            Console.WriteLine(" " + name + " ");
            Console.SetCursorPosition(150, 4);
            Console.Write(" Lv: " + level);
            //Print life into a bar of 20
            Console.SetCursorPosition(150, 5);
            Console.Write(" HP: ");
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
            for (int i = 0; i < health / 5; i++)
            {
                
                Console.Write("█");
            }
            Console.ResetColor();
            Console.SetCursorPosition(150, 6);
            Console.WriteLine(" " + health + "/" + maxHp);
            Console.SetCursorPosition(150, 7);
            Console.WriteLine("==============================");
        }

    }

    //method to draw a sprite
    public void DrawSprite(string sprite)
    {
        //draw the sprite
        Console.SetCursorPosition(10, 10);
        Console.WriteLine(sprite);
    }

}