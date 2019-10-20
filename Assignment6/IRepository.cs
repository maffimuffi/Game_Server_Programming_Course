using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Assignment3
{
    public interface IRepository
    {
        Task<Player> GetPlayer(Guid id);
        Task<Player[]> GetAllPlayers();
        Task<Player> CreatePlayer(Player player);
        Task<Player> ModifyPlayer(Guid id, Player player);
        Task<Player> DeletePlayer(Guid id);

        Task<Item> CreateItem(Guid playerId, NewItem item);
        Task<Item> GetItem(Guid playerId, Guid itemId);
        Task<Item[]> GetAllItems(Guid id);
        Task<Item> ModifyItem(Guid id, Guid itemId, Item modItem);
        Task<Item[]> DeleteItem(Guid id, Guid itemId);



        
    }
}