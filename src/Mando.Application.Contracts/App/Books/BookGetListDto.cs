using Volo.Abp.Application.Dtos;

namespace Mando.App.Books
{
    public class BookGetListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
