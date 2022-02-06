using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Mando.App.Store;

[Authorize("App.Store.Authors")]
public class AuthorAppService : AppService, IAuthorAppService
{
	private readonly AuthorManager _authorManager;
	private readonly IRepository<Author, Guid> _authorRepository;

	public AuthorAppService(
		AuthorManager authorManager,
		IRepository<Author, Guid> authorRepository)
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

		var repos = (await _authorRepository
			.GetQueryableAsync())
			.WhereIf(!input.Filter.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Filter));

		var query = from author in repos
					orderby input.Sorting
					select new { author };

		query = query.Skip(input.SkipCount).Take(input.MaxResultCount);

		var queryResult = await AsyncExecuter.ToListAsync(query);

		var authorDtos = queryResult.Select(x =>
		{
			var authorDto = ObjectMapper.Map<Author, AuthorDto>(x.author);
			return authorDto;
		}).ToList();

		var totalCount = await AsyncExecuter.CountAsync(repos);

		return new PagedResultDto<AuthorDto>(totalCount, authorDtos);
	}

	[Authorize("App.Store.Authors.Create")]
	public async Task<AuthorDto> CreateAsync(AuthorCreateDto input)
	{
		var author = await _authorManager.CreateAsync(input.Name, input.Birthday, input.Biography);

		await _authorRepository.InsertAsync(author);

		return ObjectMapper.Map<Author, AuthorDto>(author);
	}

	[Authorize("App.Store.Authors.Update")]
	public async Task UpdateAsync(Guid id, AuthorUpdateDto input)
	{
		var author = await _authorRepository.GetAsync(id);

		if (author.Name != input.Name)
			await _authorManager.ChangeNameAsync(author, input.Name);
		author.Birthday = input.Birthday;
		author.Biography = input.Biography;

		await _authorRepository.UpdateAsync(author);
	}

	[Authorize("App.Store.Authors.Delete")]
	public async Task DeleteAsync(Guid id)
	{
		await _authorRepository.DeleteAsync(id);
	}
}
