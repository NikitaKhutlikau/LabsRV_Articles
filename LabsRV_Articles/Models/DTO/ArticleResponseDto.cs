namespace LabsRV_Articles.Models.DTO
{
    public class ArticleResponseDto
    {
        public int id { get; set; }
        public int authorId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        
        // Возвращаем комментарии как список DTO, чтобы клиент видел связанные комментарии.
        public List<CommentResponseDto> Comments { get; set; }
        
        // Для стикеров можно вернуть список идентификаторов или полные объекты.
        public List<StickerResponseDto> Stickers { get; set; }
    }
}
