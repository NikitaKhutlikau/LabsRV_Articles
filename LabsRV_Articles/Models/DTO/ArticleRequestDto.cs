namespace LabsRV_Articles.Models.DTO
{
    public class ArticleRequestDto
    {
        public int authorId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        // В запросе не передаются даты и комментарии; они задаются в бизнес‑логике
    }
}
