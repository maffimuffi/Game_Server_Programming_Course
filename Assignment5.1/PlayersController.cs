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
            return await _IRepo.UpdatePlayer(playerId, player);
        }

        [HttpDelete("/api/players/delete/{playerId}")]
        public async Task<Player> Delete(string playerId)
        {
            Guid g = Guid.Parse(playerId);

            return await _IRepo.DeletePlayer(g);
        }

      
    }
}