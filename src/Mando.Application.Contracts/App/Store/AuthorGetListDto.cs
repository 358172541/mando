using Volo.Abp.Application.Dtos;

namespace Mando.App.Store;

public class AuthorGetListDto : PagedAndSortedResultRequestDto
{
	public string Filter { get; set; }
}
