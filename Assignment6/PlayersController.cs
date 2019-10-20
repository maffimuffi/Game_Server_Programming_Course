using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private MongoDbRepository _IRepo;
        public PlayersController(MongoDbRepository repo)
        {
            _IRepo = repo;
        }


        [HttpGet("/api/players/all")]
        public async Task<Player[]> GetAll()
        {
            return await _IRepo.GetAllPlayers();
        }

        [HttpPost]
        [Route("/api/players/Create")]
        public async Task<Player> Create(NewPlayer newPlayer)
        {
            var player = new Player()
            {
                Id = Guid.NewGuid(),
                Name = newPlayer.Name,
                CreationTime = DateTime.UtcNow
            };
            return await _IRepo.CreatePlayer(player);
        }

        [HttpPut("/api/players/modify/{playerId}")]
        public async Task<Player> Modify(Guid playerId, Player player)
        {
            return await _IRepo.ModifyPlayer(playerId, player);
        }

        [HttpDelete("/api/players/delete/{playerId}")]
        public async Task<Player> Delete(string playerId)
        {
            Guid g = Guid.Parse(playerId);

            return await _IRepo.DeletePlayer(g);
        }    
                
        [HttpGet("/api/players/")]
        public async Task<Player[]> GetPlayersWithMoreThanScore(int minscore)
        {
            return await _IRepo.GetPlayersWithMoreThanScore(minscore);
        }

        [HttpGet("/api/players/tag/")]
        public async Task<Player[]> GetPlayersWithTag(Tag tag)
        {
            return await _IRepo.GetPlayersWithTag(tag);
        }

        [HttpGet("/api/players/getbyname/{name:maxlength(10)}")]
        public async Task<Player> GetPlayerWithName(string name)
        {
            return await _IRepo.GetPlayerWithName(name);
        }

        [HttpPut("/api/players/changeplayername/")]
        public async Task<Player> ChangePlayerName(Player player)
        {
            return await _IRepo.ChangePlayerName(player, player.Name);
        }

        [HttpGet("/api/players/GetPlayersWithItemOfType/{type}")]
        public async Task<Player[]> GetPlayersWithItems(ItemType type)
        {
            return await _IRepo.GetPlayersWithItemOfType(type);
        }

        [HttpGet("/api/players/GetPlayersWithAmountOfItems/{amount}")]
        public async Task<Player[]> GetPlayersWithItems(int amount)
        {
            return await _IRepo.GetPlayersWithAmountOfItems(amount);
        }
    }
}