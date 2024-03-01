using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace Console_RPG
{
    class Battle
    {
        public bool battleAgain;
        public bool isResolved;
        public List<Enemy> enemies;


        public Battle(List<Enemy> enemies, bool battleAgain = false)
        {
            this.battleAgain = battleAgain;
            this.isResolved = false;
            this.enemies = enemies;
        }

        public bool Resolve(List<Player> players)
        {
            if (isResolved == true)
            {
                return true;
            }

            while (true)
            {
                // Run this code on each of the players
                foreach (var player in players)
                {

                    if (player.currentHP > 0)
                    {
                        Console.WriteLine("It's " + player.name + "'s turn!");
                        player.DoTurn(players, enemies);
                    }
                    else
                    {
                        Console.WriteLine(player.name + " is dead :(");
                    }

                    Thread.Sleep(1000);
                }

                // Run this code on each of the enemies
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                        Console.WriteLine("It's " + enemy.name + "'s turn!");
                        enemy.DoTurn(players, enemies);
                    }

                    Thread.Sleep(1000);
                }

                //If all the players die...
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("Oh no! Retreat!...");
                    Console.WriteLine(" ");
                    Thread.Sleep(1000);

                    isResolved = false;

                    return false;
                }

                //If all the enemies die...
                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.WriteLine($"Whoo! You survived");
                    Console.WriteLine($"You won [] coins!");
                    Console.WriteLine($"You won [] of experience points!");
                    Console.WriteLine(" ");

                    foreach (var enemy in enemies)
                    {
                        Player.player1.currentExp += enemy.experiencePointsOnDefeated;
                        Player.player1.LevelUp();
                        Console.WriteLine(" ");
                        Thread.Sleep(1000);
                        Player.player2.currentExp += enemy.experiencePointsOnDefeated;
                        Player.player2.LevelUp();
                        Console.WriteLine(" ");
                    }

                    Thread.Sleep(1000);

                    if (battleAgain == true) 
                    {
                        isResolved = false;
                    }
                    if (battleAgain == false)
                    {
                        isResolved = true;
                    }

                    return true;
                }

                
            }
        }
    }
}
