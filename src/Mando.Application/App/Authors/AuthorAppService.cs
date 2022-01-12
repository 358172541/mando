using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Mando.App.Authors
{
    [Authorize("App.Authors")]
    public class AuthorAppService : AppService, IAuthorAppService
    {
        private readonly AuthorManager _authorManager;
        private readonly IAuthorRepository _authorRepository;

        public AuthorAppService(AuthorManager authorManager, IAuthorRepository authorRepository)
        {
            _authorManager = authorManager;
            _authorRepository = authorRepository;
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Author, AuthorDto>(await _authorRepository.GetAsync(id));
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(AuthorGetListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
                input.Sorting = nameof(Author.Name);

            var authors = await _authorRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);

            var authorsQueryable = _authorRepository.WhereIf(!input.Filter.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Filter));

            var authorsCount = await AsyncExecuter.CountAsync(authorsQueryable);

            return new PagedResultDto<AuthorDto>(
                items: ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors),
                totalCount: authorsCount
            );
        }

        [Authorize("App.Authors.Create")]
        public async Task<AuthorDto> CreateAsync(AuthorCreateDto input)
        {
            var author = await _authorManager.CreateAsync(input.Name, input.Birthday, input.Biography);

            await _authorRepository.InsertAsync(author);

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        [Authorize("App.Authors.Update")]
        public async Task UpdateAsync(Guid id, AuthorUpdateDto input)
        {
            var author = await _authorRepository.GetAsync(id);

            if (author.Name != input.Name)
                await _authorManager.ChangeNameAsync(author, input.Name);
            author.Birthday = input.Birthday;
            author.Biography = input.Biography;

            await _authorRepository.UpdateAsync(author);
        }

        [Authorize("App.Authors.Delete")]
        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }
    }
}
