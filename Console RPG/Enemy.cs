using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public static Enemy slime = new Enemy(name: "Slime", hp: 10, mana: 0, new Stats(strength: 200, defense: 1, maxhp: 10, maxmana: 0), coinsDroppedOnDefeated: 5, experiencePointsOnDefeated: 100);
        public static Enemy skeleton = new Enemy(name: "Skeleton", hp: 20, mana: 0, new Stats(strength: 4, defense: 2, maxhp: 20, maxmana: 0), coinsDroppedOnDefeated: 10, experiencePointsOnDefeated: 15);
        public static Enemy goblin = new Enemy(name: "Goblin", hp: 40, mana: 10, new Stats(strength: 6, defense: 4, maxhp: 40, maxmana: 10), coinsDroppedOnDefeated: 25, experiencePointsOnDefeated: 25);
        public static Enemy imp = new Enemy(name: "Imp", hp: 75, mana: 40, new Stats(strength: 2, defense: 15, maxhp: 75, maxmana: 40), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);
        public static Enemy ironMaiden = new Enemy(name: "Iron Maiden", hp: 75, mana: 0, new Stats(strength: 15, defense: 0, maxhp: 75, maxmana: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);

        public int coinsDroppedOnDefeated;
        public int experiencePointsOnDefeated;

        public Enemy(string name, int hp, int mana, Stats stats, int coinsDroppedOnDefeated, int experiencePointsOnDefeated) : base(name, hp, mana, stats)
        {
            this.coinsDroppedOnDefeated = coinsDroppedOnDefeated;
            this.experiencePointsOnDefeated = experiencePointsOnDefeated;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(0, targets.Count)];
        }
        public override void Attack(Entity target, Entity user)
        {
            if (target.currentHP > 0)
            {
                int totalDamage = (this.stats.strength - target.stats.defense);
                target.currentHP -= totalDamage;
                Console.WriteLine(this.name + " attacked " + target.name + " for " + totalDamage + "points of damage!");
                Console.WriteLine(" ");
            }
            else
            {
                int totalDamage = (this.stats.strength - target.stats.defense);
                target.currentHP -= totalDamage;
                Console.WriteLine(this.name + " attacked " + target.name + " for " + totalDamage + "points of damage!");
                Console.WriteLine(" ");
            }
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target, null);
        }
    }
}
