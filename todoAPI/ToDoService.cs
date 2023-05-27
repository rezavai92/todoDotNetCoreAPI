using Microsoft.Extensions.Options;
using MongoDB.Driver;
using todoAPI.models;

namespace todoAPI
{
    public class ToDoService
    {
        private readonly IMongoCollection<ToDoItem> _toDoCollection;    
        public ToDoService(IOptions<ToDoDatabaseSettings> toDoDatabaseSettings)
        {
            var mongoClient = new MongoClient(toDoDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(toDoDatabaseSettings.Value.DatabaseName);

            _toDoCollection = mongoDatabase.GetCollection<ToDoItem>(toDoDatabaseSettings.Value.ToDosCollectionName);



        }

        public async Task<List<ToDoItem>> GetToDoItemsAsync()
        {
            return await _toDoCollection.Find(_ => true).ToListAsync();
        }
        
        public async Task<ToDoItem?> GetToDoItemByIdAsync(string id)
        {
            return await _toDoCollection.Find(todo=>todo.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateToDoAsync(ToDoItem todo)
        {
             await _toDoCollection.InsertOneAsync(todo);
        }

        public async Task UpdateToDoItem(string id, ToDoItem UpdatedToDoItem)
        {
             await _toDoCollection.ReplaceOneAsync(x => x.Id == id, UpdatedToDoItem);
        }

        public async Task RemoveToDoItem(string id)
        {
            await _toDoCollection.DeleteOneAsync(todo => todo.Id == id);
        }
 
    }
}
