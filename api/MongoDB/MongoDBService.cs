using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using api.Model;

namespace api.MongoDB
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Photo> _photoCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _photoCollection = database.GetCollection<Photo>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Photo>> GetAsync() => await _photoCollection.Find(_ => true).ToListAsync();

        public async Task<Photo> GetAsync(string id) => await _photoCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Photo photo) => await _photoCollection.InsertOneAsync(photo);
        public async Task UpdateAsync(string id, Photo photo) => await _photoCollection.ReplaceOneAsync(p => p.Id == id, photo);
        public async Task DeleteAsync(string id) => await _photoCollection.DeleteOneAsync(p => p.Id == id);
    }
}
