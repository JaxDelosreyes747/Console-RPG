using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Console_RPG
{
    class Player : Entity
    {

        public static List<Item> Inventory = new List<Item>() { Item.healthPotion1 };
        public static int CoinCount = 0;

        public static Player player1 = new Player(name: "", hp: 20, mana: 30, new Stats(strength: 200, defense: 2, maxhp: 20, maxmana: 30), level: 1, currentexp: 0);
        public static Player player2 = new Player(name: "", hp: 20, mana: 30, new Stats(strength: 200, defense: 2, maxhp: 20, maxmana: 30), level: 1, currentexp: 0);
        
        public int level;
        public int currentExp;

        public Stats levelUpIncrease = new Stats(3, 2, 10, 5);

        public Player(string name, int hp, int mana, Stats stats, int level, int currentexp) : base(name, hp, mana, stats)
        {
            this.level = level;
            this.currentExp = currentexp;
        }

        public void LevelUp()
        {
            int levelUpCeiling = 100;
            if (this.currentExp >= levelUpCeiling)
            {
                this.level++;
                this.stats.strength += levelUpIncrease.strength;
                this.stats.defense += levelUpIncrease.defense;
                this.stats.maxHP += levelUpIncrease.maxHP;
                this.stats.maxMana += levelUpIncrease.maxMana;
                this.currentExp = levelUpCeiling - this.currentExp;
                levelUpCeiling += levelUpCeiling;
                this.currentHP = this.stats.maxHP;
                this.currentMana = this.stats.maxMana;
                Console.WriteLine($"{this.name} leveled up! Your level is now at  {this.level}!");
                Thread.Sleep(1000);
                Console.WriteLine($"{this.name} feels refreshed! Your current hp is at {this.currentHP} and your current mana is at {this.currentMana}!");
                Thread.Sleep(1000);
            }
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Console.WriteLine("Type in the number of the entity you want to target!");
            // Iterate through each of the choices
            for (int i = 0; i < targets.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {targets[i].name}");
            }

            // Let user pick a choice
            int index = Convert.ToInt32(Console.ReadLine());
            if (index > targets.Count || index < 0)
            {
                Console.WriteLine("You attacked the air! Please choose a valid target next time!");
                return ChooseTarget(targets);
            }

            return targets[index - 1];
        }

        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Type in the number of the item you want to use!");
            // Iterate through each of the choices
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }

            // Let user pick a choice
            int index = Convert.ToInt32(Console.ReadLine());
            if (index > choices.Count || index < 0)
            {
                Console.WriteLine("You rummage through your bag and somehow miss every item! Please choose a valid choice!");
                return ChooseItem(choices);
            }

            return choices[index - 1];
        }

        public override void Attack(Entity target, Entity user)
        {
            int totalDamage = (this.stats.strength - target.stats.defense);
            target.currentHP -= totalDamage;
            Console.WriteLine(this.name + " attacked " + target.name + " for " + totalDamage + "points of damage!");
            Console.WriteLine(" ");
        }
        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Attack | Item");
            string choice = Console.ReadLine();

            if (choice == "Attack")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target, null);
            }
            else if (choice == "Item")
            {
                Item item = ChooseItem(Inventory);
                Entity target = ChooseTarget(players.Cast<Entity>().ToList());

                item.Use(this, target);
                Inventory.Remove(item);
            }
            else
            {
                Console.WriteLine("Please type in a valid option next time!");
                DoTurn(players, enemies);
            }

            
        }
    }
}
