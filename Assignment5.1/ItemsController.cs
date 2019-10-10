using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private MongoDbRepository _IRepo;
        public ItemController(MongoDbRepository repo)
        {
            _IRepo = repo;
        }

        [HttpGet("/api/players/{playerId}/items/{itemId}")]
        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            return await _IRepo.GetItem(playerId, itemId);
        }

        [HttpGet("/api/players/{playerId}/items/all")]
        public async Task<Item[]> GetItems(string playerId)
        {
            Guid g = Guid.Parse(playerId);
            return await _IRepo.GetAllItems(g);
        }

        [HttpPost("/api/players/{playerId}/items/create")]
        public async Task<Item> CreateItem(Guid playerId, NewItem newItem)
        {
            return await _IRepo.CreateItem(playerId, newItem);
        }

        [HttpPut("/api/players/{playerId}/items/modify/{index}/")]
        public async Task<Item> ModifyItem(Guid playerId, Guid itemId, Item modItem)
        {
            return await _IRepo.ModifyItem(playerId, itemId, modItem);
        }

        [HttpDelete("/api/players/{playerId}/items/delete/")]
        public async Task<Item[]> DeleteItem(Guid playerId, Guid itemId)
        {
            return await _IRepo.DeleteItem(playerId, itemId);
        }

      

    }
}