using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace Console_RPG
{
    class Player : Entity
    {

        public static List<Item> Inventory = new List<Item>() {};
        public static List<Equipment> EquipmentInventory = new List<Equipment>() {};
        public static int CoinCount = 0;

        public static Player player1 = new Player(name: "", hp: 20, mana: 30, new Stats(strength: 5, defense: 2, maxhp: 20, maxmana: 30, spellstrength: 20), level: 1, currentexp: 0);
        public static Player player2 = new Player(name: "", hp: 20, mana: 30, new Stats(strength: 5, defense: 2, maxhp: 20, maxmana: 30, spellstrength: 20), level: 1, currentexp: 0);
        
        public int level;
        public int currentExp;

        public Stats levelUpIncrease = new Stats(3, 2, 10, 5, 5);

        public Player(string name, int hp, int mana, Stats stats, int level, int currentexp) : base(name, hp, mana, stats)
        {
            this.level = level;
            this.currentExp = currentexp;
        }

        public void LevelUp()
        {
            int levelUpCeiling = 100 * level;
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
                Console.WriteLine($"{i + 1}: {targets[i].name} [Health: {targets[i].currentHP}]");
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
                Console.WriteLine(" ");
                return ChooseItem(choices);
            }

            return choices[index - 1];
        }

        public static Equipment ChooseEquipment(List<Equipment> choices)
        {
            Console.WriteLine("Type in the number of the equipment you want to equip!");
            // Iterate through each of the choices
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name} (Is the item equipped: {choices[i].isEquipped})");
                Console.WriteLine(" ");
            }

            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
           
            catch (Exception ex)
            {
                Console.WriteLine("You rummage through your bag and somehow miss every piece of equipment! Please choose a valid choice!");
                Console.WriteLine(" ");
                return ChooseEquipment(choices);
            }
        }

        public override void Attack(Entity target, Entity user)
        {
            int strengthTotalDamage = (this.stats.strength - target.stats.defense);

            if (strengthTotalDamage > 0)
            {
                target.currentHP -= strengthTotalDamage;
                Console.WriteLine(" ");
                Console.WriteLine(this.name + " attacked " + target.name + " for " + strengthTotalDamage + "points of damage!");
                Console.WriteLine(" ");
            }
            else
            {
                target.currentHP -= 0;
                Console.WriteLine(" ");
                Console.WriteLine("You did not do any damage!");
                Console.WriteLine(" ");
            }
        }

        public override void Spell(Entity target, Entity user)
        {
            int strengthTotalDamage = (this.stats.strength - target.stats.defense);
            int spellTotalDamage = (this.stats.spellStrength / 2);
            int mana = this.stats.maxMana - 30;
            this.currentMana = mana;

            if (mana > 0)
            {
                if (spellTotalDamage > 0)
                {
                    target.currentHP -= spellTotalDamage;
                    Console.WriteLine(" ");
                    Console.WriteLine(this.name + " attacked " + target.name + " for " + spellTotalDamage + "points of spell damage!");
                    Console.WriteLine(" ");
                    Console.WriteLine($"{this.name}'s mana is at {this.currentMana}");
                }
                else
                {
                    target.currentHP -= 0;
                    Console.WriteLine(" ");
                    Console.WriteLine("You did not do any damage!");
                    Console.WriteLine(" ");
                }
               
            }
            else
            {
                if (strengthTotalDamage > 0)
                {
                    target.currentHP -= strengthTotalDamage;
                    Console.WriteLine("Oops! You've run out of mana!");
                    Console.WriteLine("You attack normally!");
                    Console.WriteLine(" ");
                    Console.WriteLine(this.name + " attacked " + target.name + " for " + strengthTotalDamage + "points of damage!");
                    Console.WriteLine(" ");
                }
                else
                {
                    target.currentHP -= 0;
                    Console.WriteLine(" ");
                    Console.WriteLine("You did not do any damage!");
                    Console.WriteLine(" ");
                }
            }
        }
        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Attack | Item");
            string choice = Console.ReadLine();
            Console.WriteLine(" ");

            if (choice == "Attack")
            {
                Console.WriteLine("What would you like to use?");
                Console.WriteLine("Strength | Spell");
                string attackChoice = Console.ReadLine();
                Console.WriteLine(" ");

                if (attackChoice == "Strength")
                {
                    Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                    Attack(target, null);
                }
                else if (attackChoice == "Spell")
                {
                    Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                    Spell(target, null);
                }
                else
                {
                    Console.WriteLine("That can't be used to defeat the enemy...Try again!");
                    Console.WriteLine(" ");
                    DoTurn(players, enemies);
                }

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
                Console.WriteLine(" ");
                DoTurn(players, enemies);
                
            }

            
        }
    }
}
