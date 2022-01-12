using System;
using Volo.Abp.Application.Dtos;

namespace Mando.App.Books
{
    public class BookDto : EntityDto<Guid>
    {
        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}
