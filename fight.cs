// Class for fight

using System;

public class Fight {


    //method for round
    public static void Round(Entity player, Entity enemy)
    {
        //player attacks enemy
        enemy.Health -= player.Damage;
        Console.WriteLine(player.Name + " attacks " + enemy.Name + " for " + player.Damage + " damage!");
        Console.WriteLine(enemy.Name + " has " + enemy.Health + " health remaining!");

        //if enemy is dead
        if (enemy.Health <= 0)
        {
            Console.WriteLine(enemy.Name + " has died!");
            return;
        }


        //enemy attacks player
        player.Health -= enemy.Damage;
        Console.WriteLine(enemy.Name + " attacks " + player.Name + " for " + enemy.Damage + " damage!");
        Console.WriteLine(player.Name + " has " + player.Health + " health remaining!");

        //if player is dead
        if (player.Health <= 0)
        {
            Console.WriteLine(player.Name + " has died!");
            return;
        }
        
    }

    //method for fight
    public static void CheckState(Entity player, Entity enemy)
    {
        //while both players are alive
        while (player.Health > 0 && enemy.Health > 0)
        {
            //call round method
            Round(player, enemy);
        }

       
    }

    
}