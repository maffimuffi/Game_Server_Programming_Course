using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Assignment3
{
    public class FileRepository : IRepository
    {
        public Player playerList;
        
        

        //string gameDevName = Startup.dev().ToString();
        //StreamWriter writer = new StreamWriter("game-dev.txt",false);
        
        string gameDevName = "game-dev.txt";

        
        public int Score { get; set; }
        

        public async Task<Player> Create(Player player)
        {
                    File.AppendAllText(gameDevName, JsonConvert.SerializeObject(player) +"\n");

                    return player;
        }

        public async Task<Player> Delete(Guid id)
        {
            string[] pena = File.ReadAllLines(gameDevName);
            Player[] players = new Player[pena.Length];
            Player[] finalPlayers = new Player[pena.Length - 1];
            
            int count = 0;
            Player playersingle;
            foreach(var a in pena)
            {
                playersingle = JsonConvert.DeserializeObject<Player>(pena[count]);
                players[count] = playersingle;
                count++;
            }
            count = 0;
            var result = new Player();

            for (int i = 0; i < players.Length; i++)
            {
                Player c = players[i];
                if (c.Id == id)
                {
                   // players.Remove(c.Id);
                    continue;
                }
                else {
                    finalPlayers[count] = c;
                }
            count++;
            }
            
            File.Delete(gameDevName);
           foreach(var i in finalPlayers)
           {
                File.AppendAllText(gameDevName , JsonConvert.SerializeObject(i) + "\n");
           }


            return result;
        }

        public async Task<Player> Get(Guid id)
        {
           string[] pena = File.ReadAllLines(gameDevName);
           Player[] players = new Player[pena.Length];
           int count = 0;
           Player playersingle;
            foreach(var a in pena)
            {
                playersingle = JsonConvert.DeserializeObject<Player>(pena[count]);
                players[count] = playersingle;
                count++;
            }
            count = 0;
            
                        var result = new Player();
            foreach (var c in players)
            {
                if (c.Id == id)
                {
                    result = c;
                    break;
                }
            }
            return result;
        }

        public async Task<Player[]> GetAll()
        {
            
            List<Player> pellaaja = new List<Player>();
            string[] pena = File.ReadAllLines(gameDevName);
            Player[] players = new Player[pena.Length];
            int count = 0;
            Player playersingle;
            foreach(var a in pena)
            {
                playersingle = JsonConvert.DeserializeObject<Player>(pena[count]);
                players[count] = playersingle;
                
                count++;
            }
            count = 0;  
            foreach (var c in players)
            {
                pellaaja.Add(c);
            }
            return pellaaja.ToArray();
        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            
            string[] pena = File.ReadAllLines(gameDevName);
            Player[] players = new Player[pena.Length];
            int count = 0;
            Player playersingle;
            foreach(var a in pena)
            {
                playersingle = JsonConvert.DeserializeObject<Player>(pena[count]);
                players[count] = playersingle;
                count++;
            }
            count = 0;
            var result = new Player();

            foreach (var c in players)
            {
                if (c.Id == id)
                {
                    c.Score = player.Score;
                    result = c;
                    pena[count] = JsonConvert.SerializeObject(result);
                    File.WriteAllLines(gameDevName,pena);
                    break;
                }
            count++;
            }



            return result;
        }



        public Item itemList;
        //string gameDevName = "game-dev.txt";
        //StreamWriter writer = new StreamWriter("game-dev.txt",false);
        
        //public int Score { get; set; }


/* 
        public async Task<Item> CreateItem(Guid id,Item item)
        {
                    File.AppendAllText(gameDevName, JsonConvert.SerializeObject(item) +"\n");
                    

                    return item;
        }
*/

public async Task<Item> CreateItem(Guid id, NewItem item)
        {
            Player p = await Get(id);

            Item newItem = new Item()
            {
                Id = Guid.NewGuid(),
            };
            
            return await Task.FromResult<Item>(newItem);
        }
        public async Task<Item> DeleteItem(Guid id, Item item)
        {
            string[] pena = File.ReadAllLines(gameDevName);
            Item[] tavarat = new Item[pena.Length];
            Item[] finalItems = new Item[pena.Length - 1];
            
            int count = 0;
            Item Itemsingle;
            foreach(var a in pena)
            {
                Itemsingle = JsonConvert.DeserializeObject<Item>(pena[count]);
                tavarat[count] = Itemsingle;
                count++;
            }
            count = 0;
            var result = new Item();

            for (int i = 0; i < tavarat.Length; i++)
            {
                Item c = tavarat[i];
                if (c.Id == id)
                {
                   // players.Remove(c.Id);
                    continue;
                }
                else {
                    finalItems[count] = c;
                }
            count++;
            }
            
            File.Delete(gameDevName);
           foreach(var i in finalItems)
           {
                File.AppendAllText(gameDevName , JsonConvert.SerializeObject(i) + "\n");
           }


            return result;
        }

        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
           string[] pena = File.ReadAllLines(gameDevName);
           Item[] tavarat = new Item[pena.Length];
           int count = 0;
           Item itemsingle;
            foreach(var a in pena)
            {
                itemsingle = JsonConvert.DeserializeObject<Item>(pena[count]);
                tavarat[count] = itemsingle;
                count++;
            }
            count = 0;
            
                        var result = new Item();
            foreach (var c in tavarat)
            {
                if (c.Id == itemId)
                {
                    result = c;
                    break;
                }
            }
            return result;
        }

        public async Task<Item[]> GetAllItems()
        {
            
            List<Item> items = new List<Item>();
            string[] pena = File.ReadAllLines(gameDevName);
            Item[] tavarat = new Item[pena.Length];
            int count = 0;
            Item itemsingle;
            foreach(var a in pena)
            {
                itemsingle = JsonConvert.DeserializeObject<Item>(pena[count]);
                tavarat[count] = itemsingle;
                
                count++;
            }
            count = 0;  
            foreach (var c in tavarat)
            {
                items.Add(c);
            }
            return items.ToArray();
        }

        public async Task<Item> ModifyItem(Guid id, ModifiedItem item)
        {
            
            string[] pena = File.ReadAllLines(gameDevName);
            Item[] tavarat = new Item[pena.Length];
            int count = 0;
            Item itemsingle;
            foreach(var a in pena)
            {
                itemsingle = JsonConvert.DeserializeObject<Item>(pena[count]);
                tavarat[count] = itemsingle;
                count++;
            }
            count = 0;
            var result = new Item();

            foreach (var c in tavarat)
            {
                if (c.Id == id)
                {
                    c.Level = item.Level;
                    result = c;
                    pena[count] = JsonConvert.SerializeObject(result);
                    File.WriteAllLines(gameDevName,pena);
                    break;
                }
            count++;
            }



            return result;
        }



    }





}
