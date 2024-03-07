using System;
using System.Collections.Generic;
using System.Threading;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please name YOUR MII!");
            string name1 = Console.ReadLine();
            Player.player1.name = name1;
            Thread.Sleep(1000);
            Console.WriteLine(" ");

            Console.WriteLine("Please name YOUR COMPANION'S MII!");
            string name2 = Console.ReadLine();
            Player.player2.name = name2;
            Thread.Sleep(1000);
            Console.WriteLine(" ");

            Console.WriteLine("...");
            Thread.Sleep(1000);
            Console.WriteLine(" ");
            Console.WriteLine("...");
            Thread.Sleep(1000);
            Console.WriteLine(" ");
            Console.WriteLine("...");
            Thread.Sleep(1000);
            Console.WriteLine(" ");
            Console.WriteLine("Ah...Is that...a beach?...");
            Thread.Sleep(2000);
            Console.WriteLine(" ");

            Location.beach.SetNearbyLocations(east: Location.greenhorneInnShop);
            Location.plains.SetNearbyLocations(south: Location.greenhorneEntrance);
            Location.greenhorneEntrance.SetNearbyLocations(east: Location.greenhorneTown);
            Location.greenhorneTown.SetNearbyLocations(north: Location.greenhorneInn, south: Location.greenhorneCafe, west: Location.easinHillsBattle);
            Location.greenhorneInn.SetNearbyLocations(north: Location.greenhorneInnDesk);
            Location.easinHillsBattle.SetNearbyLocations(north: Location.strangeGrove, south: Location.riverdeepCavern, west: Location.seasideBeach);
            Location.riverdeepCavern.SetNearbyLocations(south: Location.riverdeepCavernBattle);
            Location.riverdeepCavernBattle.SetNearbyLocations(east: Location.riverdeepCavernGrotto, south: Location.castleView);
            Location.riverdeepCavernGrotto.SetNearbyLocations(north: Location.riverdeepCavernFish, west: Location.riverdeepCavernWater);
            Location.castleView.SetNearbyLocations(west: Location.castleBattle);
            Location.castleBattle.SetNearbyLocations(south: Location.castleRoom);   
            Location.castleRoom.SetNearbyLocations(west: Location.castleTown);
            Location.castleTown.SetNearbyLocations(north: Location.castleTavern, west: Location.aridFrontierbattle, south: Location.castleTownMarket);
            Location.castleTavern.SetNearbyLocations(north: Location.castleKaraoke);
            Location.aridFrontierbattle.SetNearbyLocations(west: Location.nightmareTowerEntrance);
            Location.nightmareTowerEntrance.SetNearbyLocations(south: Location.nightmareTower);
            Location.nightmareTower.SetNearbyLocations(west: Location.nightmareTower2);
            Location.nightmareTower2.SetNearbyLocations(south: Location.nightmareTower3);
            Location.nightmareTower3.SetNearbyLocations(east: Location.nightmareTower4);
            Location.nightmareTower4.SetNearbyLocations(north: Location.nightmareTowerFinal);


            Location.easinHillsBattle.Resolve(new List<Player>() {Player.player1, Player.player2});

        }
    }
}
