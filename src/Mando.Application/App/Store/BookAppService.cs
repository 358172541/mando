using Mando.App.Store;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Mando.App.Store;

[Authorize("App.Store.Books")]
public class BookAppService : AppService, IBookAppService
{
	private readonly BookManager _bookManager;
	private readonly IRepository<Book, Guid> _bookRepository;
	private readonly IRepository<Author, Guid> _authorRepository;

	public BookAppService(
		BookManager bookManager,
		IRepository<Book, Guid> bookRepository,
		IRepository<Author, Guid> authorRepository)
	{
		_bookManager = bookManager;
		_bookRepository = bookRepository;
		_authorRepository = authorRepository;
	}

	public async Task<BookDto> GetAsync(Guid id)
	{
		var query = from book in (await _bookRepository.GetQueryableAsync())
					join author in (await _authorRepository.GetQueryableAsync()) on book.AuthorId equals author.Id
					where book.Id == id
					select new { book, author };

		var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

		if (queryResult == null)
			throw new EntityNotFoundException(typeof(Book), id);

		var bookDto = ObjectMapper.Map<Book, BookDto>(queryResult.book);

		bookDto.AuthorName = queryResult.author.Name;

		return bookDto;
	}

	public async Task<PagedResultDto<BookDto>> GetListAsync(BookGetListDto input)
	{
		if (input.Sorting.IsNullOrWhiteSpace())
			input.Sorting = nameof(Book.Name);

		var repos = (await _bookRepository
			.GetQueryableAsync())
			.WhereIf(!input.Filter.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Filter));

		var query = from book in repos
					join author in (await _authorRepository.GetQueryableAsync()) on book.AuthorId equals author.Id
					orderby input.Sorting
					select new { book, author };

		query = query.Skip(input.SkipCount).Take(input.MaxResultCount);

		var queryResult = await AsyncExecuter.ToListAsync(query);

		var bookDtos = queryResult.Select(x =>
		{
			var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
			bookDto.AuthorName = x.author.Name;
			return bookDto;
		}).ToList();

		var totalCount = await AsyncExecuter.CountAsync(repos);

		return new PagedResultDto<BookDto>(totalCount, bookDtos);
	}

	[Authorize("App.Store.Books.Create")]
	public async Task<BookDto> CreateAsync(BookCreateDto input)
	{
		var book = await _bookManager.CreateAsync(input.AuthorId, input.Name, input.Type, input.PublishDate, input.Price);

		await _bookRepository.InsertAsync(book);

		return ObjectMapper.Map<Book, BookDto>(book);
	}

	[Authorize("App.Store.Books.Update")]
	public async Task UpdateAsync(Guid id, BookUpdateDto input)
	{
		var book = await _bookRepository.GetAsync(id);

		book.AuthorId = input.AuthorId;
		if (book.Name != input.Name)
			await _bookManager.ChangeNameAsync(book, input.Name);
		book.Type = input.Type;
		book.PublishDate = input.PublishDate;
		book.Price = input.Price;

		await _bookRepository.UpdateAsync(book);
	}

	[Authorize("App.Store.Books.Delete")]
	public async Task DeleteAsync(Guid id)
	{
		await _bookRepository.DeleteAsync(id);
	}

	public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
	{
		var authors = await _authorRepository.GetListAsync();
		var authorLookupDtos = ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors);
		return new ListResultDto<AuthorLookupDto>(authorLookupDtos);
	}
}
