using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Shop : LocationFeature
    {
        public string ownerName;
        public string shopName;
        public List<Item> items;
        public string dialogue;

        public Shop(string ownerName, string shopName, List<Item> items, string dialogue) : base(false)
        {
            this.ownerName = ownerName;
            this.shopName = shopName;
            this.items = items;
            this.dialogue = dialogue;   
        }

        public override bool Resolve(List<Player> players)
        {
            Console.WriteLine($"Welcome to {ownerName}'s shop, {shopName}!");
            Console.WriteLine(" ");

        
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Buy | Sell | Check Wallet (Wallet) | Leave");
                string userInput = Console.ReadLine();

                if (userInput == "Buy")
                {
                    Item item = ChooseItem(this.items);
                    Player.CoinCount -= item.shopPrice;
                    Player.Inventory.Add(item);

                    Console.WriteLine($"You bought a {item.name}!");
                    Console.WriteLine(" ");
                }
                else if (userInput == "Sell")
                {
                    Item item = ChooseItem(Player.Inventory);
                    Player.CoinCount += item.shopPrice;
                    Player.Inventory.Remove(item);

                    Console.WriteLine($"You sold a {item.name}!");
                    Console.WriteLine(" ");
                }
                else if (userInput == "Wallet")
                {
                    Console.WriteLine($"You have {Player.CoinCount} in your wallet!");
                    Console.WriteLine(" ");
                }
                else if (userInput == "Leave")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You stand there staring. The shopkeeper is a little freaked out. Try something else!");
                    Console.WriteLine(" ");
                }
            }

            Console.WriteLine("See ya later");

            return true;
        }

        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Type in the number of the item you want to buy!");
            // Iterate through each of the choices
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name} (${choices[i].shopPrice} coins)");
            }

            // Let user pick a choice
            int index = Convert.ToInt32(Console.ReadLine());
            if (index > choices.Count || index < 0)
            {
                Console.WriteLine("You look around and say something that the owner doesn't understand. You should probably pick something that they have!");
                return ChooseItem(choices);
            }

            return choices[index - 1];
        }
    }
}
