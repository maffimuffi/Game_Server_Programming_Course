using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2
{
        public interface IPlayer
    {
        int Score { get; set; }
    }

    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public Guid Id { get; set; }
        public int Level { get; set; }
    }

    public static class playerItems
    {

        public static Item GetHighestValueItem(this Player player)
        {
            return player.Items.OrderByDescending(x => x.Level).First();
        }

    }

    public class Game<T> where T : IPlayer
    {

    private List<T> _players;

    public Game(List<T> players) => _players = players;

    public T[] GetTop10Players() => _players.OrderByDescending(x => x.Score).Take(10).ToArray();
    }

    public class PlayerForAnotherGame : IPlayer
    {
        public int Score{get; set;}
    }

    public class guider : Player
    {
        public Item[] GetItems (Player player)
        {
            var items = new Item[player.Items.Count];
            for(int i = 0; i<items.Length;i++)
            {
                items[i] = player.Items[i];

            }
            return items;
        }

        public Item[] GetItemsWithLinq (Player player)
        {
            return player.Items.ToArray();
        }

        public static void ProcessEachItem(Player player, Action<Item> process)
        {
            player.Items.ForEach(item => process(item));
        }

        public static void PrintItem(Item item)
        {
            Console.WriteLine("Item ID: " + item.Id + " || Item level: " + item.Level);
        }

        public void guidfunction()
        {
            
                
            Console.WriteLine("MAIN MENU: 1(Duplicates) or 2(Highest lvl item) or 3(Get Items array) or 4(First item) or 5(Delegate) or 6(Lambda) or 7(TOP10)");

            string value = Console.ReadLine();
            var rand = new Random();
                
            int x = 0;
            string[] lista;
            lista = new string[1000001];
            Player[] players = new Player[1000000];
            List<Player> world = new List<Player>();

            while(x < 1000000)
            {

                players[x] = new Player();
                players[x].Id = Guid.NewGuid();
                lista[x] = players[x].Id.ToString();
                players[x].Items = new List<Item>();
                players[x].Score = rand.Next(1000000);
                world.Add(players[x]);

                x++;
            }
            
            var firstPlayer = players[0];
            for(int i = 0; i < 10; i++)
            {
                var item = new Item();
                item.Id = Guid.NewGuid();
                item.Level = rand.Next(100);
                firstPlayer.Items.Add(item);
            }

            if(value == "1")
            {
                if(lista.Length != lista.Distinct().Count())
                {
                    Console.WriteLine("Duplicate found!");
                    
                }
                else
                {
                    Console.WriteLine("No duplicates found!");
                }
            }

            if(value == "2")
            {

                Console.WriteLine("Item with the highest level: {0}", firstPlayer.GetHighestValueItem().Level);
            }

            if(value == "3")
            {

                var tulos = GetItems(firstPlayer);
                var tulos2 = GetItemsWithLinq(firstPlayer);

                Console.WriteLine("Do you want to print items? 1(yes) tai 2(no): ");
                string vastaus = Console.ReadLine();
                int c = 0;

                if(vastaus == "1")
                {
                    foreach (var a in tulos)
                    {
                        c++;

                        Console.WriteLine("Item number(no linq) "+ c + " = " + a.Level);
                    }
                    Console.WriteLine("");
                    c = 0;
                    foreach ( var b in tulos2)
                    {
                        c++;
                        Console.WriteLine("Item number(linq) " + c + ": Level = " + b.Level);
                    } 
                    c = 0;
                }
                else 
                {
                    Console.WriteLine("No prints....");
                }
            }

            if(value == "4")
            {

                int values = 0;

                while(values == 0)
                {

                    try
                    {
                        Console.WriteLine("First item: {0}", FirstItem(firstPlayer));
                    }
                    catch(System.NullReferenceException)
                    {
                        Console.WriteLine("Player has no items, he's completely useless now!!!!");
                    }

                    try
                    {
                        Console.WriteLine("First item with linq: {0}", FirstItemWithLinq(firstPlayer));
                    }
                    catch(System.NullReferenceException)
                    {
                        Console.WriteLine("Player has no items, he's completely useless now!!!!");
                    }
                    
                    values++;

                }

                string FirstItemWithLinq(Player player)
                {
                    var satan = player.Items.First().Id.ToString();
                        
                    return satan;
                }

                string FirstItem(Player player)
                {
                    return player.Items[0].Id.ToString();
                }
            }

            if(value == "5")
            {
                
                ProcessEachItem(firstPlayer, PrintItem);

            }

            if(value == "6")
            {
                ProcessEachItem(firstPlayer, item => Console.WriteLine("Item ID: " + item.Id + " || Item level: " + item.Level));
            }

            if(value == "7")
            {
                var Game = new Game<Player>(world);
                Console.WriteLine("Game: " + string.Join(",", Game.GetTop10Players().Select(y => y.Score)));

                var anotherGame = new Game<PlayerForAnotherGame>(new PlayerForAnotherGame[10].Select(y => {
                    y = new PlayerForAnotherGame(); 
                    y.Score = rand.Next(1000000);
                    return y;
                }).ToList());
                Console.WriteLine("Another game: [{0}]", string.Join(",", anotherGame.GetTop10Players().Select(y => y.Score)));
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {

            while(true)
            {
                guider createGuides = new guider();
                createGuides.guidfunction();
                //Console.WriteLine("valmis");
                
                Console.WriteLine("Do you want to exit? 1(Yes) tai 2(No):");
                string kysymys = Console.ReadLine();

                if(kysymys == "1")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                } 
                else 
                {
                    continue;
                }
            }
        }
    }
}