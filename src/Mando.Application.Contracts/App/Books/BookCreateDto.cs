using System;
using System.ComponentModel.DataAnnotations;

namespace Mando.App.Books
{
    public class BookCreateDto
    {
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(BookConsts.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public BookType Type { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public float Price { get; set; }
    }
}
