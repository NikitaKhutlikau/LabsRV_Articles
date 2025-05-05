using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LabsRV_Articles.Models.Domain
{
    [Index(nameof(id), IsUnique = true)]
    public class Comment : IEntity
    {
        public int id { get; set; }

        [Required]
        public int articleId { get; set; }
        public Article article { get; set; }

        [Required]
        [StringLength(2048, MinimumLength = 2)]
        public string content { get; set; }
    }
}
