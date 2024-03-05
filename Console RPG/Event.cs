using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Console_RPG
{
    internal class Event : LocationFeature
    {
        public string eventName;
      
        public Event(string eventName) : base(false)
        {
            this.eventName = eventName;
            
        }

        public Item ChooseItem(List<Item> item)
        {
            Random random = new Random();
            return item[random.Next(0, item.Count)];
        }
        public override bool Resolve(List<Player> players)
        {
            Console.WriteLine($"Hmm...it seems you've stumbled upon an outing: {eventName}");
            Console.WriteLine(" ");

            if (eventName == "Cafe")
            {

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Eat | Leave");
                string userInput = Console.ReadLine();


                if (userInput == "Eat")
                {
                    Console.WriteLine("You and " + Player.player2 + " spend some time together enjoying some delicious food. The food fills you with so much happiness and great vitality!");

                    Player.player1.currentHP = Player.player1.stats.maxHP;
                    Player.player2.currentHP = Player.player2.stats.maxHP;

                    Console.WriteLine("You and " + Player.player2 + " healed up to your max health!");
                    Console.WriteLine(" ");
                }
                else if (userInput == "Leave")
                {
                    Location.greenhorneTown.Resolve(players);
                }
                else
                {
                    Console.WriteLine("You stand there staring at your companion...try another option!");
                    Resolve(players);
                }

            }
            if (eventName == "Fishing")
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Fish | Leave");
                string userInput = Console.ReadLine();

                if (userInput == "Fish")
                {
                    Item item = ChooseItem(new List<Item>() { Item.healthPotion1, Item.manaPotion1 });
                    Player.Inventory.Add(item);

                    Console.WriteLine("You and " + Player.player2.name + " pick up the fishing rod and begin to fish. One of you reels up something from the water...it's...an item! Well...a sopping wet and covered in seagrass item...");
                    Console.WriteLine($"You got a {item.name}!");
                    Console.WriteLine(" ");

                }
                else if (userInput == "Leave")
                {
                    Location.riverdeepCavernGrotto.Resolve(players);
                }
                else
                {
                    Console.WriteLine("You stand there staring at your companion...try another option!");
                    Resolve(players);
                }

            }
            if (eventName == "Water")
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Water | Leave");
                string userInput = Console.ReadLine();


                if (userInput == "Water")
                {
                    Console.WriteLine("You and " + Player.player2 + " pick up buckets and fetch water! You got water!");
                    Console.WriteLine(" ");
                    Console.WriteLine($"You got a {Item.water.name}!");
                    Console.WriteLine(" ");

                    Player.Inventory.Add(Item.water);
                }
                else if (userInput == "Leave")
                {
                    Location.riverdeepCavernGrotto.Resolve(players);
                }
                else
                {
                    Console.WriteLine("You stand there staring at your companion...try another option!");
                    Resolve(players);
                }
            }
            if (eventName == "Karaoke")
            {

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Sing | Leave");
                string userInput = Console.ReadLine();


                if (userInput == "Sing")
                {
                    Console.WriteLine("You and " + Player.player2.name + " try some karaoke together. You pick a song and sing your hearts off side by side. The sound of each other's voice fills you with great spirit!");
                    Console.WriteLine(" ");

                    Player.player1.currentMana = Player.player1.stats.maxMana;
                    Player.player2.currentMana = Player.player2.stats.maxMana;

                    Console.WriteLine("You and " + Player.player2.name + " healed up to your max mana!");
                    Console.WriteLine(" ");
                }
                else if (userInput == "Leave")
                {
                    Location.greenhorneTown.Resolve(players);
                }
                else
                {
                    Console.WriteLine("You stand there staring at your companion...try another option!");
                    Resolve(players);
                }
            }
            if (eventName == "Beach")
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Run around (Run) | Leave");
                string userInput = Console.ReadLine();

                if (userInput == "Run")
                {
                    Item item = ChooseItem(new List<Item>() { Item.weirdPotion1, Item.weirdPotion2 });
                    Player.Inventory.Add(item);

                    Console.WriteLine("You and " + Player.player2.name + " walk on the beach, occationally splashing water at one another. As you're walking, one of you trip over a bottle in the sand. Ah! a potion...I wonder what it does...");
                    Console.WriteLine($"You got a {item.name}!");
                    Console.WriteLine(" ");

                }
                else if (userInput == "Leave")
                {
                    Location.riverdeepCavernGrotto.Resolve(players);
                }
                else
                {
                    Console.WriteLine("You stand there staring at your companion...try another option!");
                    Resolve(players);
                }

            }

            return true;
        }

       
    }
}
