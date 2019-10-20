using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Assignment3
{

public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<Player> _collection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;

        public MongoDbRepository()
        {

        var database = new MongoClient("mongodb://localhost:27017").GetDatabase("Game");
            _collection = database.GetCollection<Player>("players");
            _bsonDocumentCollection = database.GetCollection<BsonDocument>("players");
            
 
        }

        
        public async Task<Player> GetPlayer(Guid id)

        {

            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);



            return await _collection.Find(filter).FirstAsync();

        }

        public async Task<Player[]> GetAllPlayers()

        {

            var players = await _collection.Find(new BsonDocument()).ToListAsync();



            return players.ToArray();

        }

        public async Task<Player> CreatePlayer(Player player)

        {

            if(player.Items == null) {

                player.Items = new List<Item>();

            }



            for(int i = 0; i < 10; i++) {

                player.Items.Add(new Item() {

                Id = Guid.NewGuid(),

                Level = 0,

                Itemtype = ItemType.SWORD,

                CreationDate = DateTime.UtcNow

                });

            }



            await _collection.InsertOneAsync(player);



            return player;

        }

        public async Task<Player> ModifyPlayer(Guid id, Player player)

        {

            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, player.Id);

            await _collection.ReplaceOneAsync(filter, player);

            return player;

        }

        public async Task<Player> DeletePlayer(Guid id)

        {

            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, id);



            return await _collection.FindOneAndDeleteAsync(filter);

        }

        public async Task<Item> CreateItem(Guid id, NewItem item)

        {

            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);



            Player pl = _collection.Find(filter).FirstAsync().Result;



            Item i = new Item()

            {

                Itemtype = item.ItemType,

                Id = Guid.NewGuid(),

                Level = item.Level

            };

            
            pl.Items.Add(i);



            var replace = Builders<Player>.Update.Set(player => player.Items, pl.Items);

            await _collection.UpdateOneAsync(filter, replace);



            return await Task.FromResult<Item>(pl.Items[pl.Items.Count - 1]);

        }


        public async Task<Item[]> DeleteItem(Guid id, Guid itemId)

        {

            var update = Builders<Player>.Update.PullFilter(p => p.Items, f => f.Id == itemId);

            await _collection.FindOneAndUpdateAsync(p => p.Id == id, update);

            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);

            var player = _collection.Find(filter).FirstAsync().Result;



            return await Task.FromResult<Item[]>(player.Items.ToArray());

        }


        public async Task<Item> GetItem(Guid playerId, Guid itemId)

        {

            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);

            Player pl = _collection.Find(filter).FirstAsync().Result;



            return await Task.FromResult<Item>(pl.Items.Find(item => item.Id == itemId));

        }

        public async Task<Item[]> GetAllItems(Guid id)

        {

            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);

            var player = _collection.Find(filter).FirstAsync().Result;



            return await Task.FromResult<Item[]>(player.Items.ToArray());

        }

        public async Task<Item> ModifyItem(Guid id, Guid itemId, Item modItem)

        {

            var filter = Builders<Player>.Filter.Where(x => x.Id == itemId && x.Items.Any(i => i.Id == itemId));

            var update = Builders<Player>.Update.Set(x => x.Items[-1], modItem);

            await _collection.UpdateOneAsync(filter, update);

            Player pl = _collection.Find(filter).FirstAsync().Result;

            return await Task.FromResult<Item>(pl.Items.Find(item => item.Id == itemId));

        }

        // Assignment 6

        public async Task<Player[]> GetTopTenPlayers()
        {
            SortDefinition<Player> sortDef =
            Builders<Player>.Sort.Descending("Level");

            var players = await _collection.Find(new BsonDocument()).ToListAsync();



            return players.ToArray();

        }

        public async Task<Player[]> GetPlayersWithMoreThanScore(int minscore)
        {

            FilterDefinition<Player> filter = Builders<Player>.Filter.Gte("Score", minscore);

            List<Player> players = await _collection.Find(filter).ToListAsync();

            return players.ToArray();
        }

        public async Task<Player[]> GetPlayersWithTag(Tag tag)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Tag, tag);

            var players = await _collection.Find(filter).ToListAsync();

            return players.ToArray();
        }

        public async Task<Player> GetPlayerWithName(string name)
        {

        var Pname = Builders<Player>.Filter.Eq(p => p.Name, "Marja");
        return await _collection.Find(Pname).FirstAsync();

        }

        public async Task<Player> ChangePlayerName(Player player, string newName)
        {
            player.Name = newName;
            var update = Builders<Player>.Update.Set(x => x.Name, newName);
            await _collection.UpdateOneAsync(y => y.Id == player.Id, update);
            return player;
        }

        public async Task<Player[]> GetPlayersWithItemOfType(ItemType type)
        {
            var filter = Builders<Player>.Filter.ElemMatch(x => x.Items, x => x.Itemtype == type);
            var players = await _collection.Find(filter).ToListAsync();
            return players.ToArray();

        }

        public async Task<Player[]> GetPlayersWithAmountOfItems(int amount)
        {
            var filter = Builders<Player>.Filter.Size(x => x.Items, amount);

            var players = await _collection.Find(filter).ToListAsync();
            return players.ToArray();

        }
    }

}