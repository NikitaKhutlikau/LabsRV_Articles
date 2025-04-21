namespace LabsRV_Articles.Models.Domain
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }  // Внешний ключ для Article
        public string Content { get; set; }

        // Навигационное свойство – статья, к которой привязан комментарий.
        public Article Article { get; set; }
    }
}
