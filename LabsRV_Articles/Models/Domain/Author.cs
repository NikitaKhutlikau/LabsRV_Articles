using System.Collections.Generic;

namespace LabsRV_Articles.Models.Domain
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Связь «Author – Article»: один автор может иметь множество статей.
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
