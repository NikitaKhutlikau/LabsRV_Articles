using LabsRV_Articles.Models.Domain;
using System.Collections.Generic;

namespace LabsRV_Articles.Models.Domain
{
    public class Article : IEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }  // Внешний ключ для Author
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        // Навигационное свойство – автор статьи (необязательно для in‑memory, но отражает связь)
        public Author Author { get; set; }

        // Связь «Article – Comment»: статья может иметь множество комментариев.
        public List<Comment> Comments { get; set; } = new List<Comment>();

        // Связь «Article – Sticker (many-to-many)».
        // Для упрощения здесь просто список навигационных свойств.
        public List<Sticker> Stickers { get; set; } = new List<Sticker>();
    }
}
