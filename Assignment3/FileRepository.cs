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
        string gameDevName = "game-dev.txt";
        //StreamWriter writer = new StreamWriter("game-dev.txt",false);
        

        
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
    }
}
