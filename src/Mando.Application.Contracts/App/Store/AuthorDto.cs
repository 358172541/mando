using System;
using Volo.Abp.Application.Dtos;

namespace Mando.App.Store
{
    public class AuthorDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Biography { get; set; }
    }
}
