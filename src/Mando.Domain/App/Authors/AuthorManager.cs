using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Mando.App.Authors
{
    public class AuthorManager : DomainService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        
        public async Task<Author> CreateAsync([NotNull] string name, DateTime birthday, [CanBeNull] string biography = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            await CheckAuthorExistsByName(name);

            return new Author(GuidGenerator.Create(), name, birthday, biography);
        }
        
        public async Task ChangeNameAsync([NotNull] Author author, [NotNull] string newName)
        {
            Check.NotNull(author, nameof(author));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            await CheckAuthorExistsByName(newName);

            author.ChangeName(newName);
        }
        
        private async Task CheckAuthorExistsByName(string name)
        {
            var author = await _authorRepository.FindByNameAsync(name);
            if (author != null)
                throw new AuthorExistsException(name);
        }
    }
}
