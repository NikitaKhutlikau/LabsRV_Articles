namespace LabsRV_Articles.Models.DTO
{
    public class AuthorResponseDto
    {
        public int id { get; set; }
        public string login { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        // Теперь этот список обязателен – он содержит идентификаторы статей автора
        public List<int> ArticleIds { get; set; }
    }
}
