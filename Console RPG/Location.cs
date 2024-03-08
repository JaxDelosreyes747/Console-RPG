using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Location
    {

        //story
        public static Location corn = new Location("Corn", "korn...wait what?...", new Battle(new List<Enemy>() { Enemy.imp }, false));
        public static Location beach = new Location("the Beach?", "You don't understand how you got here...but you have a whole adventure ahead of you!...");
        public static Location plains = new Location("the Plains", "...Well it seems you're definitely walking into some Plains...Oh! There's a town ahead, maybe you can talk to someone?...");
        public static Location greenhorneEntrance = new Location("Greenhorne Town Entrance", "It's the safest town in all of Miitopia! At least it is for now...");
        public static Location greenhorneTownSquare = new Location("Greenhorne Town Square", "What a quaint little town...Ah! You bumped into someone...Is that..." + Player.player2.name + "? It's so good to see them!...What's this? It seems like they want to join you on your journey!");
        public static Location greenhorneTown = new Location("Greenhorne Town", "You walked into the town and...it's extremely quiet...it's a bit eerie...");
        public static Location strangeGrove = new Location("Strange Grove", "The trees provide a beautiful cover over the sun, providing shade to your wary eyes. I would hope you don't have any pollen allergies...It's very pretty and you take the moment to breathe a sigh of relief");
        public static Location riverdeepCavern = new Location("Riverdeep Cavern", "Water drops onto your nose as you walk. The rocks are so reflective, you can see you and your companion standing together as if you were staring in a mirror!");
        public static Location riverdeepCavernGrotto = new Location("Riverdeep Grotto", "You and step into a surprisingly warm and lush grotto. Flowing waterfalls adorne the cave. You both find a pair of fishing rods sitting nearby.");
        public static Location castleView = new Location("Castle View", "Man, the castle is so beautiful from this view. It's almost surreal!");
        public static Location castleRoom = new Location("Castle: Main Room", "Ah! The king has something to say...It seems he has some intel on where the person creating the monsters is! Perhaps we should head out");
        public static Location castleTown = new Location("Castle Town", "The town is bussling with citizens chatting with one another. They all seem wary of the recent events happening in Greenhorne...");

        //shops
        public static Location greenhorneInnShop = new Location("Greenhorne Inn Shop", "A cute little shop...the owner keeps saying 'bee bop bee bo'...", new Shop("Ybot", "Greenhorne Inn Shop", new List<Item>() { Item.healthPotion1, Item.manaPotion1, Item.dagger, Item.wand, Item.chainmail, Item.robes }, "Uhhh...I can't think right now what to say to you"));
        public static Location castleTownMarket = new Location("Castle Town Market", "A cute little shop...the owner keeps saying 'bee bop bee bo'...", new Shop("Mongus", "Castle Town Market", new List<Item>() { Item.megaHealthPotion1, Item.megaManaPotion1, Item.sword, Item.staff, Item.ironArmor, Item.fancyRobes}, "Impasta"));

        //inns
        public static Location greenhorneInn = new Location("Greenhorne Inn", "Hmm...it seems like this is a little inn...At least you can rest now...You can probably ask what happened at the information desk");
        public static Location greenhorneInnDesk = new Location("Greenhorne Inn Information Desk", "You walk up to the desk, asking what happened to the townsfolk. The person, cowering behind the desk, says that the townspeople have been stolen by someone called: The Dark Lord...hmm...");
        public static Location castleTavern = new Location("Castle Tavern", "A loud and energetic tavern. Citizens come up occationally to sing karaoke to the other patrons, filling the air with a light melody");

        //events
        public static Location greenhorneCafe = new Location("DewDrop Cafe", "A quaint little cafe...", new Event("Cafe"));
        public static Location riverdeepCavernFish = new Location("Fishing Hole", "A fishing hole...", new Event("Fishing"));
        public static Location riverdeepCavernWater = new Location("Watering Hole", "A watering hole....", new Event("Water"));
        public static Location castleKaraoke = new Location("Kristal Karaoke", "A cute little Karoke place...", new Event("Karaoke"));
        public static Location seasideBeach = new Location("Seaside Beach", "A warm and beautifully sandy beach...", new Event("Beach"));

        //battles
        public static Location easinHillsBattle = new Location("Easin Hills", "A wide open field full of lush grass...and monsters apparently", new Battle(new List<Enemy>() { Enemy.slime, Enemy.slime2, Enemy.slime3}, true));
        public static Location riverdeepCavernBattle = new Location("Riverdeep Inner Lake", "Oh man, that lake is almost...eerily deep...With your proportions, it would be a death sentence to try and swim", new Battle(new List<Enemy>() {Enemy.slime4, Enemy.goblin, Enemy.goblin2 }, true));
        public static Location castleBattle = new Location("Castle: Hallway", "AGH! It seems like the castle has been ambushed...", new Battle(new List<Enemy>() { Enemy.goblin3, Enemy.imp2, Enemy.imp3 }, true));
        public static Location aridFrontierbattle = new Location("Arid Frontier", "The wind is howling right next to your ears. Looking down, it's a long way to the bottom of the cliff...", new Battle(new List<Enemy>() {Enemy.ironMaiden, Enemy.ironMaiden2, Enemy.weepingWillow}, true));

        //final level
        public static Location nightmareTowerEntrance = new Location("Nightmare Tower: Entrance", "So this is where the dark lord lives...");
        public static Location nightmareTower = new Location("Nightmare Tower: Ground Level", "Eek! This place is crawling with monsters...Let's be careful scaling it...", new Battle(new List<Enemy>() { Enemy.slime5, Enemy.goblin4, Enemy.imp4 }, false));
        public static Location nightmareTower2 = new Location("Nightmare Tower: Level 2", "Woah, the monsters grow in power with each level! Be careful...", new Battle(new List<Enemy>() { Enemy.imp5, Enemy.ironMaiden3, Enemy.weepingWillow2 }, false));
        public static Location nightmareTower3 = new Location("Nightmare Tower: Level 3", "It seems you're close to reaching the top! Keep going, you're almost there! I can sense the darkness...The final battle...", new Battle(new List<Enemy>() { Enemy.ironMaiden5, Enemy.weepingWillow3, Enemy.weepingWillow4}, false));
        public static Location nightmareTowerFinal = new Location("Nightmare Tower: Top Level", "You stand at the top...it's a long way down. You've finally won...", new Battle(new List<Enemy>() {Enemy.ironMaiden5, Enemy.weepingWillow5, Enemy.darkLord}, false));

        static Location checkpoint;
        
        public string name;
        public string description;
        public LocationFeature interaction;

        public Location north, east, south, west;

        public Location(string name, string description, LocationFeature interaction = null)
        {
            this.name = name;
            this.description = description;
            this.interaction = interaction;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {

            if (!(north is null))
            {
                this.north = north;
                north.south = this;
            }

            if (!(east is null))
            {
                this.east = east;
                east.west = this;
            }

            if (!(south is null))
            {
                this.south = south;
                south.north = this;
            }

            if (!(west is null))
            {
                this.west = west;
                west.east = this;
            }
        }

        public void Resolve(List<Player> players)
        {
            // Only resolve a battle if there is a battle to resolve | null checking
            if (!(interaction is null))
            {
                bool wonBattle = interaction.Resolve(players);
                if (wonBattle)
                {

                }
                else
                {
                    checkpoint.Resolve(players);
                    return;
                }
            }
            
            Console.WriteLine("You find yourself in " + this.name + ".");
            Thread.Sleep(1000);
            Console.WriteLine(this.description);
            Thread.Sleep(1000);
            Console.WriteLine(" ");

            if (!(north is null))
                Console.WriteLine("North: " + this.north.name);

            if (!(east is null))
                Console.WriteLine("East: " + this.east.name);

            if (!(south is null))
                Console.WriteLine("South: " + this.south.name);

            if (!(west is null))
                Console.WriteLine("West: " + this.west.name);

            Console.WriteLine(" ");
            Console.WriteLine("Type [Inventory] to access Inventory!");
            Console.WriteLine(" ");

            string choice = Console.ReadLine();
            Console.WriteLine(" ");
            Location nextLocation = null;

            // What happens if the user doesn't give a proper input

            if (choice == "North")
                nextLocation = this.north;
            else if (choice == "East")
                nextLocation = this.east;
            else if (choice == "South")
                nextLocation = this.south;
            else if (choice == "West")
                nextLocation = this.west;
            else if (choice == "Inventory")
            {
                CheckInventory(Player.player1);
                this.Resolve(players);
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Oops! Try writing the direction again!");
                Console.WriteLine(" ");
                Thread.Sleep(1000);
                this.Resolve(players);
            }

            checkpoint = this;
            Thread.Sleep(1000);
            nextLocation.Resolve(players);
        }

        public static void CheckInventory(Player player)
        {
            List<Player> playerChoice = new List<Player>() {Player.player1, Player.player2};
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Use Item [Item] | Equip Equipment [Equip] | Check Stats [Stats] | Check Wallet [Wallet] | Leave");
                string choice = Console.ReadLine();
                Console.WriteLine(" ");

                if (choice == "Item")
                {
                    if (Player.Inventory.Count == 0)
                    {
                        Console.WriteLine("You have nothing in your inventory");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Item item = Player.player1.ChooseItem(Player.Inventory);
                        Entity target = Player.player1.ChooseTarget(playerChoice.Cast<Entity>().ToList());
                        item.Use(player, target);
                        Player.Inventory.Remove(item);
                    }
                }
                else if (choice == "Equip")
                {
                    if (Player.EquipmentInventory.Count == 0)
                    {
                        Console.WriteLine("You have nothing in your weapon inventory");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Equipment equipment = Player.ChooseEquipment(Player.EquipmentInventory);
                        Entity target = Player.player1.ChooseTarget(playerChoice.Cast<Entity>().ToList());
                        if (equipment.isEquipped == false)
                        {
                            equipment.Equip(player);
                        }
                        else if (equipment.isEquipped == true)
                        {
                            equipment.UnEquip(player);
                        }
                        
                    }
                }
                else if (choice == "Stats")
                {
                    Console.WriteLine("Whos stats do you want to check?");
                    Console.WriteLine($"{Player.player1.name}'s Stats | {Player.player2.name}'s Stats");
                    string statsChoice = Console.ReadLine();
                    Console.WriteLine(" ");

                    if (statsChoice == Player.player1.name)
                    {
                        Console.WriteLine($"Here is {Player.player1.name}'s stats ");
                        Console.WriteLine(" ");
                        Console.WriteLine($"Level: {Player.player1.level}");
                        Console.WriteLine("Current EXP: " + Player.player1.currentExp + "/" + Player.player1.level * 100);
                        Console.WriteLine($"Current HP: {Player.player1.currentHP} / {Player.player1.stats.maxHP}");
                        Console.WriteLine($"Current Mana: {Player.player1.currentMana} / {Player.player1.stats.maxMana}");
                        Console.WriteLine($"Strength: {Player.player1.stats.strength}");
                        Console.WriteLine($"Defense: {Player.player1.stats.defense}");
                        Console.WriteLine(" ");
                    }
                    else if (statsChoice == Player.player2.name)
                    {
                        Console.WriteLine($"Here is {Player.player2.name}'s stats ");
                        Console.WriteLine(" ");
                        Console.WriteLine($"Level: {Player.player2.level}");
                        Console.WriteLine("Current EXP: " + Player.player2.currentExp + "/" + Player.player2.level * 100);
                        Console.WriteLine($"Current HP: {Player.player2.currentHP} / {Player.player2.stats.maxHP}");
                        Console.WriteLine($"Current Mana: {Player.player2.currentMana} / {Player.player2.stats.maxMana}");
                        Console.WriteLine($"Strength: {Player.player2.stats.strength}");
                        Console.WriteLine($"Defense: {Player.player2.stats.defense}");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.WriteLine("I don't think this person exists (in this world at least)...please try again!");
                        Console.WriteLine(" ");
                    }
                }
                else if (choice == "Wallet")
                {
                    Console.WriteLine($"You have {Player.CoinCount} Derek Dollars in your wallet!");
                    Console.WriteLine(" ");
                }
                else if (choice == "Leave")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Whoops! Try typing the command again!");
                    CheckInventory(player);
                }
            }
        }
    }
}
