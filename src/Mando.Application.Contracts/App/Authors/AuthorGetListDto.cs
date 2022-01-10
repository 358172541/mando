using Volo.Abp.Application.Dtos;

namespace Mando.App.Authors
{
    public class AuthorGetListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
