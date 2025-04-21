namespace LabsRV_Articles.Models.Domain
{
    public class Sticker : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Для связи many-to-many: один стикер может быть связан с несколькими статьями.
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
