﻿namespace Console_RPG
{
    // Structs are useful for storing simple plain data.
    struct Stats
    {
        public int strength;
        public int defense;
        public int maxHP;
        public int maxMana;
        public int spellStrength;

        public Stats(int strength, int defense, int maxhp, int maxmana, int spellstrength)
        {
            this.strength = strength;
            this.defense = defense;
            this.maxHP = maxhp;
            this.maxMana = maxmana;
            this.spellStrength = spellstrength;
        }
    }
}
