using System;
using Volo.Abp.Application.Dtos;

namespace Mando.App.Store
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
