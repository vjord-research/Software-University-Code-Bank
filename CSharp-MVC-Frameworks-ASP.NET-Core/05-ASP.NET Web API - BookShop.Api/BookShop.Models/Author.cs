namespace BookShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants;

    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
