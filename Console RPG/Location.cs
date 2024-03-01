using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Location
    {

        public static Location corn = new Location("Corn", "korn...wait what?...", new Battle(new List<Enemy>() { Enemy.slime }, false));
        public static Location beach = new Location("the Beach?", "You don't understand how you got here...but you have a whole adventure ahead of you!...");
        public static Location plains = new Location("the Plains", "...Well it seems you're definitely walking into some Plains...Oh! There's a town ahead, maybe you can talk to someone?...");
        public static Location greenhorneEntrance = new Location("Greenhorne Town Entrance", "It's the safest town in all of Miitopia! At least it is for now...");
        public static Location greenhorneTownSquare = new Location("Greenhorne Town Square", "What a quaint little town...Ah! You bumped into someone...Is that..." + Player.player2.name + "? It's so good to see them!...What's this? It seems like they want to join you on your journey!");
        public static Location greenhorneTown = new Location("Greenhorne Town", "You walked into the town and...it's extremely quiet...it's a bit eerie...");
       
        public static Location greenhorneInn = new Location("Greenhorne Inn", "Hmm...it seems like this is a little inn...At least you can rest now...You can probably ask what happened at the information desk");
        public static Location greenhorneInnDesk = new Location("Greenhorne Inn Information Desk", "You walk up to the desk, asking what happened to the townsfolk. The person, cowering behind the desk, says that the townspeople have been stolen by someone called: The Dark Lord...hmm...");

        public static Location greenhorneCafe = new Location("DewDrop Cafe", "You and " + Player.player2 + " spend some time together enjoying some delicious food. The food fills you with so much happiness and great vitality!");
        public static Location riverdeepCavernFish = new Location("Fishing Hole", "You and " + Player.player2 + " pick up the fishing rod and begin to fish. One of you reels up something from the water...it's...an item! Well...a sopping wet and covered in seagrass item...");
        public static Location castleKaraoke = new Location("Kristal Karaoke", "You and " + Player.player2 + " try some karaoke together. You pick a song and sing your hearts off side by side. The sound of each other's voice fills you");
        public static Location seasideBeach = new Location("Seaside Beach", "You and " + Player.player2 + " walk on the beach, occationally splashing water at one another. As you're walking, one of you trip over a bottle in the sand. Ah! a potion...I wonder what it does...");

        public static Location easinHillsBattle = new Location("Easin Hills", "A wide open field full of lush grass...and monsters apparently");
        public static Location riverdeepCavernBattle = new Location("Riverdeep Inner Lake", "Oh man, that lake is almost...eerily deep...With your proportions, it would be a death sentence to try and swim");
        public static Location castleBattle = new Location("Castle: Hallway", "AGH! It seems like the castle has been ambushed...");

        public static Location strangeGrove = new Location("Strange Grove", "The trees provide a beautiful cover over the sun, providing shade to your wary eyes. I would hope you don't have any pollen allergies...It's very pretty and you take the moment to breathe a sigh of relief");
        public static Location riverdeepCavern = new Location("Riverdeep Cavern", "Water drops onto your nose as you walk. The rocks are so reflective, you can see you and your companion standing together as if you were staring in a mirror!");
        public static Location riverdeepCavernGrotto = new Location("Riverdeep Grotto", "You and step into a surprisingly warm and lush grotto. Flowing waterfalls adorne the cave. You both find a pair of fishing rods sitting nearby.");
        public static Location castleView = new Location("Castle View", "Man, the castle is so beautiful from this view. It's almost surreal!");
        public static Location castleRoom = new Location("Castle: Main Room", "Ah! The king has something to say...It seems he has some intel on where the person creating the monsters is! Perhaps we should head out");
        public static Location castleTown = new Location("Castle Town", "The town is bussling with citizens chatting with one another. They all seem wary of the recent events happening in Greenhorne...");
        
        public static Location nightmareTower = new Location("Nightmare Tower: Ground Level", "Eek! This place is crawling with monsters...Let's be careful scaling it...", new Battle(new List<Enemy>() { Enemy.slime }, false));
        public static Location nightmareTower2 = new Location("Nightmare Tower: Level 2", "Woah, the monsters grow in power with each level! Be careful...", new Battle(new List<Enemy>() { Enemy.slime }, false));
        public static Location nightmareTower3 = new Location("Nightmare Tower: Level 3", "It's getting a bit tall...and dark...I hope you aren't afraid of heights...", new Battle(new List<Enemy>() { Enemy.slime }, false));
        public static Location nightmareTower4 = new Location("Nightmare Tower: Level 4", "It seems you're close to reaching the top! Keep going, you're almost there! I can sense the darkness...", new Battle(new List<Enemy>() { Enemy.slime }, false));
        public static Location nightmareTowerFinal = new Location("Nightmare Tower: Top Level", "It seems you're close to reaching the top! Keep going, you're almost there! I can sense the darkness...", new Battle(new List<Enemy>() { Enemy.slime }, false));

        static Location checkpoint;
        
        public string name;
        public string description;
        public Battle battle;

        public Location north, east, south, west;

        public Location(string name, string description, Battle battle = null)
        {
            this.name = name;
            this.description = description;
            this.battle = battle;
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
            if (!(battle is null))
            {
                bool wonBattle = battle.Resolve(players);
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

            if (!(north is null))
                Console.WriteLine("North: " + this.north.name);

            if (!(east is null))
                Console.WriteLine("East: " + this.east.name);

            if (!(south is null))
                Console.WriteLine("South: " + this.south.name);

            if (!(west is null))
                Console.WriteLine("West: " + this.west.name);

            Console.WriteLine("If you want to access Inventory type: Inventory");

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
    }
}
