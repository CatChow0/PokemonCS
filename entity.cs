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

}