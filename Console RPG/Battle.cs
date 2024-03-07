using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Drawing;
using System.Numerics;

namespace Console_RPG
{
    class Battle : LocationFeature
    {
        public bool battleAgain;
        public List<Enemy> enemies;


        public Battle(List<Enemy> enemies, bool battleAgain = false) : base(false)
        {
            this.battleAgain = battleAgain;
            this.enemies = enemies;
        }

        public override bool Resolve(List<Player> players)
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
                        Console.WriteLine($"Your health is at {player.currentHP}!");
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

                    foreach (var enemy in enemies)
                    {
                        Player.player1.currentExp += enemy.experiencePointsOnDefeated;
                        Player.player1.LevelUp();
                        Player.player2.currentExp += enemy.experiencePointsOnDefeated;
                        Player.player2.LevelUp();
                        Player.CoinCount += enemy.coinsDroppedOnDefeated;
                    }

                    Console.WriteLine($"Whoo! You survived");
                    Console.WriteLine($"{Player.player1.name} now has {Player.player1.currentExp} experience points!");
                    Console.WriteLine($"{Player.player2.name} now has {Player.player2.currentExp} experience points!");
                    Console.WriteLine($"You now have {Player.CoinCount} Derek Dollars!");
                    Console.WriteLine(" ");

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
