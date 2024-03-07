using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{

    // Classes are useful for storing complex objects.
    abstract class Entity
    {
        public string name;

        public int currentHP;
        public int currentMana;

        // This is called composition. Composition is awesome!
        public Stats stats;
        public Weapon heldWeapon;
        public Armor armor;

        public Entity(string name, int hp, int mana, Stats stats)
        {
            this.name = name;
            this.currentHP = hp;
            this.currentMana = mana;
            this.stats = stats;
        }

        public abstract void DoTurn(List<Player> players, List<Enemy> enemies);
        public abstract Entity ChooseTarget(List<Entity> targets);
        public abstract void Attack(Entity target, Entity user);

        public abstract void Spell(Entity target, Entity user);

        public void UseItem(Item item, Entity target)
        {
            
        }
    }
}
