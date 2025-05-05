using LabsRV_Discussion.Models.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace LabsRV_Discussion.Repositories
{

    public class MongoCommentRepository
    {
        private readonly IMongoCollection<Comment> _comments;

        public MongoCommentRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDb:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDb:DatabaseName"]);
            _comments = database.GetCollection<Comment>(configuration["MongoDb:CommentCollectionName"]);
        }

        public async Task<Comment> GetByIdAsync(string id)
        {
            var filter = Builders<Comment>.Filter.Eq(c => c.id, new ObjectId(id));
            return await _comments.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _comments.Find(_ => true).ToListAsync();
        }

        public async Task<Comment> AddAsync(Comment comment)
        {
            await _comments.InsertOneAsync(comment);
            return comment;
        }

        public async Task<Comment> UpdateAsync(string id, Comment comment)
        {
            var filter = Builders<Comment>.Filter.Eq(c => c.id, new ObjectId(id));
            var update = Builders<Comment>.Update
                .Set(c => c.Content, comment.Content);

            return await _comments.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Comment>
            {
                ReturnDocument = ReturnDocument.After
            });
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<Comment>.Filter.Eq(c => c.id, new ObjectId(id));
            var result = await _comments.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }
    }
}
