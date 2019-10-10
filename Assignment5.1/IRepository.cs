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
        Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);

        Task<Item> GetItem(Guid playerId, Guid itemId);
        Task<Item[]> GetAllItems();
        Task<Item> CreateItem(Guid playerId,NewItem item);
        Task<Item> ModifyItem(Guid id, ModifiedItem item);
        Task<Item> DeleteItem(Guid id, Item item);
        
    }
}