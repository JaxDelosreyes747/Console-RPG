using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Console_RPG
{
    class Enemy : Entity

    {
        public static Enemy slime = new Enemy(name: "Slime", hp: 10, mana: 0, new Stats(strength: 6, defense: 1, maxhp: 10, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 5, experiencePointsOnDefeated: 10);
        public static Enemy slime2 = new Enemy(name: "Slime", hp: 10, mana: 0, new Stats(strength: 6, defense: 1, maxhp: 10, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 5, experiencePointsOnDefeated: 10);
        public static Enemy slime3 = new Enemy(name: "Slime", hp: 10, mana: 0, new Stats(strength: 6, defense: 1, maxhp: 10, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 5, experiencePointsOnDefeated: 10);
        public static Enemy slime4 = new Enemy(name: "Slime", hp: 10, mana: 0, new Stats(strength: 6, defense: 1, maxhp: 10, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 5, experiencePointsOnDefeated: 10);
        public static Enemy slime5 = new Enemy(name: "Slime", hp: 10, mana: 0, new Stats(strength: 6, defense: 1, maxhp: 10, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 5, experiencePointsOnDefeated: 10);

        public static Enemy goblin = new Enemy(name: "Goblin", hp: 40, mana: 0, new Stats(strength: 10, defense: 4, maxhp: 40, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 25, experiencePointsOnDefeated: 25);
        public static Enemy goblin2 = new Enemy(name: "Goblin", hp: 40, mana: 0, new Stats(strength: 10, defense: 4, maxhp: 40, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 25, experiencePointsOnDefeated: 25);
        public static Enemy goblin3 = new Enemy(name: "Goblin", hp: 40, mana: 0, new Stats(strength: 10, defense: 4, maxhp: 40, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 25, experiencePointsOnDefeated: 25);
        public static Enemy goblin4 = new Enemy(name: "Goblin", hp: 40, mana: 0, new Stats(strength: 10, defense: 4, maxhp: 40, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 25, experiencePointsOnDefeated: 25);
        public static Enemy goblin5 = new Enemy(name: "Goblin", hp: 40, mana: 0, new Stats(strength: 10, defense: 4, maxhp: 40, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 25, experiencePointsOnDefeated: 25);

        public static Enemy imp = new Enemy(name: "Imp", hp: 75, mana: 0, new Stats(strength: 15, defense: 6, maxhp: 75, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);
        public static Enemy imp2 = new Enemy(name: "Imp", hp: 75, mana: 0, new Stats(strength: 15, defense: 6, maxhp: 75, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);
        public static Enemy imp3 = new Enemy(name: "Imp", hp: 75, mana: 0, new Stats(strength: 15, defense: 6, maxhp: 75, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);
        public static Enemy imp4 = new Enemy(name: "Imp", hp: 75, mana: 0, new Stats(strength: 15, defense: 6, maxhp: 75, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);
        public static Enemy imp5 = new Enemy(name: "Imp", hp: 75, mana: 0, new Stats(strength: 15, defense: 6, maxhp: 75, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);

        public static Enemy ironMaiden = new Enemy(name: "Iron Maiden", hp: 75, mana: 0, new Stats(strength: 30, defense: 10, maxhp: 75, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);
        public static Enemy ironMaiden2 = new Enemy(name: "Iron Maiden", hp: 75, mana: 0, new Stats(strength: 30, defense: 10, maxhp: 75, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);
        public static Enemy ironMaiden3 = new Enemy(name: "Iron Maiden", hp: 75, mana: 0, new Stats(strength: 30, defense: 10, maxhp: 75, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);
        public static Enemy ironMaiden4 = new Enemy(name: "Iron Maiden", hp: 75, mana: 0, new Stats(strength: 30, defense: 10, maxhp: 75, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);
        public static Enemy ironMaiden5 = new Enemy(name: "Iron Maiden", hp: 75, mana: 0, new Stats(strength: 30, defense: 10, maxhp: 75, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 50, experiencePointsOnDefeated: 50);

        public static Enemy weepingWillow = new Enemy(name: "Weeping Willow", hp: 150, mana: 0, new Stats(strength: 45, defense: 15, maxhp: 150, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 75, experiencePointsOnDefeated: 75);
        public static Enemy weepingWillow2 = new Enemy(name: "Weeping Willow", hp: 150, mana: 0, new Stats(strength: 45, defense: 15, maxhp: 150, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 75, experiencePointsOnDefeated: 75);
        public static Enemy weepingWillow3 = new Enemy(name: "Weeping Willow", hp: 150, mana: 0, new Stats(strength: 45, defense: 15, maxhp: 150, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 75, experiencePointsOnDefeated: 75);
        public static Enemy weepingWillow4 = new Enemy(name: "Weeping Willow", hp: 150, mana: 0, new Stats(strength: 45, defense: 15, maxhp: 150, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 75, experiencePointsOnDefeated: 75);
        public static Enemy weepingWillow5 = new Enemy(name: "Weeping Willow", hp: 150, mana: 0, new Stats(strength: 45, defense: 15, maxhp: 150, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 75, experiencePointsOnDefeated: 75);

        public static Enemy darkLord = new Enemy(name: "Dark Lord", hp: 500, mana: 0, new Stats(strength: 60, defense: 40, maxhp: 500, maxmana: 0, spellstrength: 0), coinsDroppedOnDefeated: 1000, experiencePointsOnDefeated: 1000);



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
                Console.WriteLine(" ");
                Console.WriteLine(this.name + " attacked " + target.name + " for " + totalDamage + " points of damage!");
                Console.WriteLine(" ");
            }
            else
            {
                int totalDamage = (this.stats.strength - target.stats.defense);
                target.currentHP -= totalDamage;
                Console.WriteLine(" ");
                Console.WriteLine(this.name + " attacked " + target.name + " for " + totalDamage + " points of damage!");
                Console.WriteLine(" ");
            }
        }

        public override void Spell(Entity target, Entity user)
        {

        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target, null);
        }
    }
}
