using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Mando.App.Store
{
    public class BookManager : DomainService
    {
        private readonly IRepository<Book, Guid> _bookRepository;

        public BookManager(IRepository<Book, Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> CreateAsync(Guid authorId, string name, BookType type, DateTime publishDate, float price)
        {
            if (await _bookRepository.AnyAsync(x => x.Name == name))
            {
                throw new BookNameDulplicatedException(name);
            }
            return new Book(GuidGenerator.Create(), authorId, name, type, publishDate, price);
        }

        public async Task ChangeNameAsync(Book book, string newName)
        {
            if (await _bookRepository.AnyAsync(x => x.Name == newName))
            {
                throw new BookNameDulplicatedException(newName);
            }
            book.ChangeName(newName);
        }
    }
}
