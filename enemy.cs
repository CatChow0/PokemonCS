// class for enemy

using System;

// Enemy class

protected class Enemy : Entity
{
    //constructor
    public Enemy(string name, int health, int damage, int armor, string type) : base(name, health, damage, armor, type)
    {
    }

    // Create an enemy and return it to the player
    public static Enemy CreateEnemy()
    {
        // Create a new enemy
        Enemy enemy = new Enemy("salamèche", 100, 10, 5, "Fire");

        // Return the enemy
        return enemy;
    }
    
}