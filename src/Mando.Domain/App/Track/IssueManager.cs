using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Mando.App.Track
{
    public class IssueManager : DomainService
    {
        private readonly IRepository<Issue, Guid> _issueRepository;

        public IssueManager(IRepository<Issue, Guid> issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<Issue> CreateAsync(string title, string description)
        {
            if (await _issueRepository.AnyAsync(x => x.Title == title))
            {
                throw new IssueTitleDulplicatedException(title);
            }

            return new Issue(GuidGenerator.Create(), title, description);
        }
    }
}
