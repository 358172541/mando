using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Mando.App.Store
{
    public class AuthorManager : DomainService
    {
        private readonly IRepository<Author, Guid> _authorRepository;

        public AuthorManager(IRepository<Author, Guid> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> CreateAsync(string name, DateTime birthday, string biography)
        {
            if (await _authorRepository.AnyAsync(x => x.Name == name))
            {
                throw new AuthorNameDulplicatedException(name);
            }
            return new Author(GuidGenerator.Create(), name, birthday, biography);
        }

        public async Task ChangeNameAsync(Author author, string newName)
        {
            if (await _authorRepository.AnyAsync(x => x.Name == newName))
            {
                throw new AuthorNameDulplicatedException(newName);
            }
            author.ChangeName(newName);
        }
    }
}
