using Volo.Abp.Application.Dtos;

namespace Mando.App.Store;

public class BookGetListDto : PagedAndSortedResultRequestDto
{
	public string Filter { get; set; }
}
