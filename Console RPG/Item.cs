using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {

        public static Item water = new Water("Water", "Water!", 10, 5, 10);

        public static Item weirdPotion1 = new WeirdPotionHealItem("Weird Potion", "It kind of smells funny...", 10, 5, 10);
        public static Item weirdPotion2 = new WeirdPotionDamageItem("Weird Potion", "It kind of smells funny...", 10, 5, 10);

        public static Item healthPotion1 = new HealthPotionItem("Health Potion", "Yummy", 10, 2, 10);
        public static Item megaHealthPotion1 = new HealthPotionItem("Mega Health Potion", "Yummy", 10, 2, 25);
        public static Item ultraHealthPotion1 = new HealthPotionItem("Ultra Health Potion", "Yummy", 10, 2, 50);
        public static Item manaPotion1 = new ManaPotionItem("Standard Ether Potion", "Yummy", 10, 2, 5);
        

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

    class Water : Item
    {
        public int happiness;
        public Water(string name, string description, int shopPrice, int maxAmount, int happiness) : base(name, description, shopPrice, maxAmount)
        {
            this.happiness = happiness;
        }

        public override void Use(Entity user, Entity target)
        {
            Console.WriteLine(target.name + " got water. They gained " + this.happiness + " amount of happiness!");
            Console.WriteLine(" ");
        }
    }

    class WeirdPotionHealItem : Item
    {
        public int healAmount;

        public WeirdPotionHealItem(string name, string description, int shopPrice, int maxAmount, int healAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.healAmount;
            Console.WriteLine(target.name + " used a Weird Potion and felt great! They healed for " + this.healAmount + "!");
            Console.WriteLine(" ");
        }
    }

    class WeirdPotionDamageItem : Item
    {
        public int damageAmount;

        public WeirdPotionDamageItem(string name, string description, int shopPrice, int maxAmount, int damageAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.damageAmount = damageAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.damageAmount;
            Console.WriteLine(target.name + " used a Weird Potion and...bleugh! Is that poison?! They were damaged for " + this.damageAmount + "!");
            Console.WriteLine(" ");
        }
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
}
