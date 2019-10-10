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
using System.Net;
using static Assignment3.ErrorHandlingMiddleware;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Assignment3 
{

    [Route("api/players/{playerId}/items")]
    [ApiController]

    public class ItemsController : ControllerBase
    {

    List<Item> items = new List<Item>();

    private readonly IRepository _repository;

    private readonly ErrorHandlingMiddleware errorHandling;

    private readonly CustomExceptionFilterAttribute customExceptionFilterAttribute;

    private readonly MyNotFoundException myNotFoundException;
    

    public ItemsController(IRepository repository)
    {
        _repository = repository;
    }

    

            [HttpGet]
            [Route("{id}")]
            public async Task<Item> GetItem(Guid playerId, Guid itemId)
            {
                return await _repository.GetItem(playerId, itemId);
            }

            [HttpGet]
            [Route("")]
            public async Task<Item[]> GetAllItems(Guid playerId)
            {
                
                return await _repository.GetAllItems();
            }
            
            [HttpPost]
            [Route("{id}")]
            public async Task<Item> CreateItem(Guid id, NewItem item)
            {
                Player pelaaja = await _repository.Get(id);
                try
                {

                var rand = new Random();
                Item tavara = new Item();
                
                tavara.Id = Guid.NewGuid();
                
                tavara.Level = rand.Next(99+1);

                int arpa = rand.Next(3);

                if(arpa == 0)
                {
                    tavara.Itemtype = ItemType.POTION;

                }

                if(arpa == 1)
                {
                    tavara.Itemtype = ItemType.SHIELD;

                }

                if(arpa == 2)
                {

                    if(pelaaja.Level >= 3)
                    {
                        tavara.Itemtype = ItemType.SWORD;

                    }

                    else
                    {
                        //Console.WriteLine(errorHandling.errorString());
                        
                        
                        customExceptionFilterAttribute.OnException(InvalidLevelException(pelaaja.Level));
                        
                        
                    }
                    

                }
                
                
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                
                DateTime now = DateTime.Now.AddDays(rand.Next(range));
                tavara.CreationDate = now;
                items.Add(tavara);
                pelaaja.Items.Add(tavara);
                
                await _repository.CreateItem(id,item);      //sano sit ku oot valmis testaamaan
                
                return tavara;

                }

                catch(HttpStatusCodeException ex)
                {
                    
                    throw ex;
                }
                
            }
            

        private ExceptionContext InvalidLevelException(int level)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
            [Route("{id}")]
            public async Task<Item> ModifyItem(Guid playerId, ModifiedItem item)
            {
                return await _repository.ModifyItem(playerId,item);
            }

            [HttpDelete]
            [Route("{id}")]
            public async Task<Item> DeleteItem(Guid playerId, Item item)
            {
               return await _repository.DeleteItem(item.Id,item);
            }

    }



}