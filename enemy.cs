// class for enemy

using System;

// Enemy class

public class Enemy : Entity
{
    //constructor
    public Enemy(string name, int health, int damage, int armor, string type, int level) : base(name, health, damage, armor, type, level)
    {
    }

    // Create an enemy and return it to the player
    public static Enemy CreateEnemy()
    {
        // Create a new enemy
        Enemy enemy = new Enemy("salamèche", 100, 10, 5, "Fire" , 5);

        // Return the enemy
        return enemy;
    }
    
}