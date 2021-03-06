namespace BookShop.Api.Models.Authors
{
    using System.ComponentModel.DataAnnotations;

    using static BookShop.Models.ModelConstants;

    public class AuthorRequestModel
    {
        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public string LastName { get; set; }
    }
}
