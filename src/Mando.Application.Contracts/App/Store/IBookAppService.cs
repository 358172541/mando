using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Mando.App.Store;

public interface IBookAppService : IApplicationService
{
	Task<BookDto> GetAsync(Guid id);

	Task<PagedResultDto<BookDto>> GetListAsync(BookGetListDto input);

	Task<BookDto> CreateAsync(BookCreateDto input);

	Task UpdateAsync(Guid id, BookUpdateDto input);

	Task DeleteAsync(Guid id);

	Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
}
