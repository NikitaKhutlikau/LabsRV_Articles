using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

public class Comment
{
    [BsonId]
    public ObjectId id { get; set; }  // MongoDB использует ObjectId

    [BsonElement("articleId")]
    public int ArticleId { get; set; }

    [BsonElement("content")]
    [Required]
    [StringLength(2048, MinimumLength = 2)]
    public string Content { get; set; } = string.Empty;
}



