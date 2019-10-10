using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3 
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        
        
        //Player[] pellaaja = {new Player(),new Player()};
        List<Player> pellaaja = new List<Player>();
        //FileRepository testiehka = new FileRepository();
        private readonly IRepository _repository;
        
        //[HttpGet]
        public PlayersController(IRepository repository)
        {
        _repository = repository;
        }
            [HttpGet]
            [Route("{id}")]
            public async Task<Player> Get(Guid id)
            {
                return await _repository.Get(id);
            }

            [HttpGet]
            [Route("")]
            public async Task<Player[]> GetAll()
            {
                return await _repository.GetAll();
            }
            
            [HttpPost]
            [Route("")]
            public async Task<Player> Create(NewPlayer player)
            {
                var rand = new Random();
                Player asd = new Player();
                asd.Name = player.Name;
                asd.Id = Guid.NewGuid();
                
                asd.Score = rand.Next(999999);
                
                asd.Level = rand.Next(99);
                asd.IsBanned = false;
                DateTime now = DateTime.Now;
                asd.CreationTime = now;
                pellaaja.Add(asd);
                
                await _repository.Create(asd);
                return asd;
            }
            [HttpPut]
            [Route("{id}")]
            public async Task<Player> Modify(Guid id, ModifiedPlayer player)
            {
                return await _repository.Modify(id,player);
            }
            
            [HttpDelete]
            [Route("{id}")]
            public async Task<Player> Delete(Guid id)
            {
               return await _repository.Delete(id);
            }
        
    }
}