using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Mando.App.Authors
{
    [Route("api/app/authors")]
    public class AuthorController : HttpApiController, IAuthorAppService
    {
        public IAuthorAppService AuthorAppService { get; }

        public AuthorController(IAuthorAppService authorAppService)
        {
            AuthorAppService = authorAppService;
        }

        [HttpGet("{id}")]
        public Task<AuthorDto> GetAsync(Guid id)
        {
            return AuthorAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AuthorDto>> GetListAsync(AuthorGetListDto input)
        {
            return AuthorAppService.GetListAsync(input);
        }

        [HttpPost]
        public Task<AuthorDto> CreateAsync(AuthorCreateDto input)
        {
            return AuthorAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public Task UpdateAsync(Guid id, AuthorUpdateDto input)
        {
            return AuthorAppService.UpdateAsync(id, input);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return AuthorAppService.DeleteAsync(id);
        }
    }
}
