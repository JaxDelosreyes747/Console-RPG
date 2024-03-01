using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public static Item potion1 = new HealthPotionItem("Health Potion", "Yummy", 10, 1, 10);

        public string name;
        public string description;
        public int shopPrice;
        public int maxAmount;

        public Item(string name, string description, int shopPrice, int maxAmount)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.maxAmount = maxAmount;
        }

        public abstract void Use(Entity user, Entity target);
    }

    class HealthPotionItem : Item
    {
        public int healAmount;

        public HealthPotionItem(string name, string description, int shopPrice, int maxAmount, int healAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.healAmount;
            Console.WriteLine(target.name + " used a Health Potion and healed for " + this.healAmount + "!");
            Console.WriteLine(" ");
        }
    }
    class ManaPotionItem : Item
    {
        public int manaAmount;

        public ManaPotionItem(string name, string description, int shopPrice, int maxAmount, int manaAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.manaAmount = manaAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            user.currentMana += this.manaAmount;
        }
    }

    class Firework : Item
    {
        public int damage;

        public Firework(string name, string description, int shopPrice, int maxAmount, int damage) : base(name, description, shopPrice, maxAmount)
        {
            this.damage = damage;
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHP -= this.damage;
        }
    }

    class Weapon : Item
    {
        public int damage;

        public Weapon(string name, string description, int shopPrice, int maxAmount, int damage) : base(name, description, shopPrice, maxAmount)
        {
            this.damage = damage;
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHP -= this.damage;
        }
    }
    class Sword : Weapon
    {
        public Sword(string name, string description, int shopPrice, int maxAmount, int damage) : base(name, description, shopPrice, maxAmount, damage)
        {
   
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHP -= (this.damage + user.stats.strength) - target.stats.defense;
        }
    }

    class Wand : Weapon
    {
        public int manaUsed;

        public Wand(string name, string description, int shopPrice, int maxAmount, int damage, int manaUsed) : base(name, description, shopPrice, maxAmount, damage)
        {
            this.manaUsed = manaUsed;
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHP -= this.damage;

            if (user.currentMana == 0)
                return;

            user.currentMana -= this.manaUsed;

        }
    }


}
