using System;
using Volo.Abp.Application.Dtos;

namespace Mando.App.Books
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
