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

    //constructor
    public Entity(string name, int health, int damage, int armor, string type, int level)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
        this.armor = armor;
        this.type = type;
        this.level = level;
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

    public void PrintStats(string type)
    {
        if(type == "Player")
        {
            //print player stats
            Console.SetCursorPosition(10, 50);
            Console.WriteLine("==============================");
            Console.SetCursorPosition(10, 51);
            Console.WriteLine(" Name: " + name + " ");
            //Print life into a bar of 20
            Console.SetCursorPosition(10, 52);
            Console.Write(" Health: ");
            for (int i = 0; i < health / 5; i++)
            {
                Console.Write("█");
            }
            Console.SetCursorPosition(10, 53);
            Console.WriteLine("==============================");
        }
        else if (type == "Enemy")
        {
            //write all the enemy stats in the top right corner
            Console.SetCursorPosition(150, 2);
            //print enemy stats
            Console.WriteLine("==============================");
            Console.SetCursorPosition(150, 3);
            Console.WriteLine(" Name: " + name + " ");
            //Print life into a bar of 20
            Console.SetCursorPosition(150, 4);
            Console.Write(" Health: ");
            for (int i = 0; i < health / 5; i++)
            {
                Console.Write("█");
            }
            Console.SetCursorPosition(150, 5);
            Console.WriteLine("==============================");
        }

    }

}