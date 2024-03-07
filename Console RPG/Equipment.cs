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

        public abstract void Equip(Entity user);

        public abstract void UnEquip(Entity user);
    }

    class Armor : Equipment
    {
        public int defense;

        public Armor(string name, string description, int shopPrice, int sellPrice, float durability, float rarity, int defense) : base(name, description, shopPrice, sellPrice, durability, rarity)
        {
            this.defense = defense;
        }

        public override void Equip(Entity user)
        {
            user.armor = this;
            this.isEquipped = true;
            int modifier = user.stats.defense += this.defense;
            Console.WriteLine($"{user.name} equipped {this.name} and your defense is at {modifier}!");
        }

        public override void UnEquip(Entity user)
        {
            this.isEquipped = false;
            int modifier = user.stats.defense -= this.defense;
            Console.WriteLine($"{user.name} unequipped {this.name} and your defense is back down to {modifier}!");
        }
        public override void Use(Entity user, Entity target)
        {

        }
    }

    class Weapon : Equipment
    {
        public int damage;

        public Weapon(string name, string description, int shopPrice, int sellPrice, float durability, float rarity, int damage) : base(name, description, shopPrice, sellPrice, durability, rarity)
        {
            this.damage = damage;
        }

        public override void Equip(Entity user)
        {

            this.isEquipped = true;
            //increase the targets defense if they equip the item
            int modifier = user.stats.strength += this.damage;
            Console.WriteLine($"{user.name} equipped {this.name} and can now attack at {modifier} points of damage!");
            Console.WriteLine(" ");
        }

        public override void UnEquip(Entity user)
        {
            this.isEquipped = false;
            //increase the targets defense if they deequip the item
            int modifier = user.stats.strength -= this.damage;
            Console.WriteLine($"{user.name} unequipped {this.name} and your attack is back down to {modifier}!");
            Console.WriteLine(" ");
        }


        public override void Use(Entity user, Entity target)
        {
            this.durability = this.durability -= 0.5f;

            if (this.durability < 0 )
            {
                Console.WriteLine($"{this.name} has broken!");
                Player.Inventory.Remove(this);
            }
        }
    }
}
