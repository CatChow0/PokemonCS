// Main function for the program

using System;

class Program
{
    static void Main()
    {
        // Create a new player
        Pokemon player = Pokemon.CreatePokemon();

        // Create a new enemy
        Enemy enemy = Enemy.CreateEnemy();

        // Fight the enemy
        Fight.CheckState(player, enemy);
    }
}