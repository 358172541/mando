using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Mando.App.Store;

[Route("api/app/store/books")]
public class BookController : HttpApiController, IBookAppService
{
	public IBookAppService BookAppService { get; }

	public BookController(IBookAppService bookAppService)
	{
		BookAppService = bookAppService;
	}

	[HttpGet("{id}")]
	public Task<BookDto> GetAsync(Guid id)
	{
		return BookAppService.GetAsync(id);
	}

	[HttpGet]
	public virtual Task<PagedResultDto<BookDto>> GetListAsync(BookGetListDto input)
	{
		return BookAppService.GetListAsync(input);
	}

	[HttpPost]
	public Task<BookDto> CreateAsync(BookCreateDto input)
	{
		return BookAppService.CreateAsync(input);
	}

	[HttpPut("{id}")]
	public Task UpdateAsync(Guid id, BookUpdateDto input)
	{
		return BookAppService.UpdateAsync(id, input);
	}

	[HttpDelete("{id}")]
	public Task DeleteAsync(Guid id)
	{
		return BookAppService.DeleteAsync(id);
	}

	[HttpGet("lookup/authors")]
	public Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
	{
		return BookAppService.GetAuthorLookupAsync();
	}
}
