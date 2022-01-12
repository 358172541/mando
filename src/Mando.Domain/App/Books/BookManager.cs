using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Mando.App.Books
{
    public class BookManager : DomainService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> CreateAsync(Guid authorId, [NotNull] string name, BookType type, DateTime publishDate, float price)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            // check authorId

            await CheckBookExistsByName(name);

            // check type

            return new Book(GuidGenerator.Create(), authorId, name, type, publishDate, price);
        }

        public async Task ChangeNameAsync([NotNull] Book book, [NotNull] string newName)
        {
            Check.NotNull(book, nameof(book));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            await CheckBookExistsByName(newName);

            book.ChangeName(newName);
        }

        private async Task CheckBookExistsByName(string name)
        {
            var author = await _bookRepository.FindByNameAsync(name);
            if (author != null)
                throw new BookExistsException(name);
        }
    }
}
