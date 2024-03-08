using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {

        // Extras
        public static Item water = new Water("Water", "Water!", 10, 5, 10);
        public static Item weirdPotion1 = new WeirdPotionHealItem("Weird Potion", "It kind of smells funny...", 10, 5, 15);
        public static Item weirdPotion2 = new WeirdPotionDamageItem("Weird Potion", "It kind of smells funny...", 10, 5, 15);

        // Potions
        public static Item healthPotion1 = new HealthPotionItem("Health Potion", "Yummy", 10, 2, 10);
        public static Item healthPotion2 = new HealthPotionItem("Health Potion", "Yummy", 10, 2, 10);
        public static Item healthPotion3 = new HealthPotionItem("Health Potion", "Yummy", 10, 2, 10);
        public static Item megaHealthPotion1 = new HealthPotionItem("Mega Health Potion", "Yummy", 10, 2, 25);
        public static Item megaHealthPotion2 = new HealthPotionItem("Mega Health Potion", "Yummy", 10, 2, 25);
        public static Item megaHealthPotion3 = new HealthPotionItem("Mega Health Potion", "Yummy", 10, 2, 25);

        public static Item manaPotion1 = new ManaPotionItem("Standard Ether Potion", "Yummy", 10, 2, 5);
        public static Item manaPotion2 = new ManaPotionItem("Standard Ether Potion", "Yummy", 10, 2, 5);
        public static Item manaPotion3 = new ManaPotionItem("Standard Ether Potion", "Yummy", 10, 2, 5);
        public static Item megaManaPotion1 = new ManaPotionItem("Mega Ether Potion", "Yummy", 25, 2, 25);
        public static Item megaManaPotion2 = new ManaPotionItem("Mega Ether Potion", "Yummy", 25, 2, 25);
        public static Item megaManaPotion3 = new ManaPotionItem("Mega Ether Potion", "Yummy", 25, 2, 25);

        //Weapons
        public static Equipment dagger = new Weapon("Dagger", "Sharp...ish", 20, 5, 0.5f, 1, 10);
        public static Equipment sword = new Weapon("Sword", "Sharp enough!", 100, 5, 0.5f, 1, 25);
        public static Equipment wand = new MagicWeapon("Wand", "It mostly works", 20, 5, 0.5f, 1, 10);
        public static Equipment staff = new MagicWeapon("Staff", "Wow! Crystal", 100, 5, 0.5f, 1, 25);

        public static Equipment godSword = new Weapon("God Sword", "Don't use unless you really need to... [Easy Mode]", 20, 5, 0.5f, 1, 100);
        public static Equipment godSword2 = new Weapon("God Sword 2", "Don't use unless you really need to...", 20, 5, 0.5f, 1, 100);

        //Armor
        public static Equipment chainmail = new Armor("Chainmail", "There's a lot of holes, but it's better than nothing", 10, 5, 0.5f, 1, 10);
        public static Equipment ironArmor = new Armor("Iron Armor", "Woo. Shiny!", 10, 5, 0.5f, 1, 20);
        public static Equipment robes = new Armor("Robes", "It's too big for you, but it works", 10, 5, 0.5f, 1, 10);
        public static Equipment fancyRobes = new Armor("Sorcerers Robes", "It's quite fancy", 10, 5, 0.5f, 1, 20);

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
