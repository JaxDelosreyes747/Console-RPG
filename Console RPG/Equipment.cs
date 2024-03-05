using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public float durability;
        public float rarity;
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice, int sellPrice, float durability, float rarity) : base(name, description, shopPrice, sellPrice)
        {
            this.durability = durability;
            this.rarity = rarity;
            this.isEquipped = false;
        }
    }

    class Armor : Equipment
    {
        public int defense;

        public Armor(string name, string description, int shopPrice, int sellPrice, float durability, float rarity, int defense) : base(name, description, shopPrice, sellPrice, durability, rarity)
        {
            this.defense = defense;
        }

        public override void Use(Entity user, Entity target)
        {
            // Flip the value of whether or not it's equipped
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                //increase the targets defense if they equip the item
                target.stats.defense += this.defense;
            }
            else
            {
                //increase the targets defense if they deequip the item
                target.stats.defense -= this.defense;
            }
        }
    }

    class Weapon : Equipment
    {
        public int damage;

        public Weapon(string name, string description, int shopPrice, int sellPrice, float durability, float rarity, int damage) : base(name, description, shopPrice, sellPrice, durability, rarity)
        {
            this.damage = damage;
        }

        public override void Use(Entity user, Entity target)
        {
            // Flip the value of whether or not it's equipped
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                //increase the targets defense if they equip the item
                target.stats.strength += this.damage;
            }
            else
            {
                //increase the targets defense if they deequip the item
                target.stats.strength -= this.damage;
            }
        }
    }
}
