using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace Mando.App.Track
{
    public class IssueInactiveSpecification : Specification<Issue>
    {
        public override Expression<Func<Issue, bool>> ToExpression()
        {
            throw new NotImplementedException();
        }
    }
}
