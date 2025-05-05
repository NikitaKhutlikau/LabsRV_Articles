using System.Text.Json.Serialization;

namespace LabsRV_Articles.Models.DTO
{
    public class CommentResponseDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("articleId")]
        public int ArticleId { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }
}
