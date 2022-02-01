using Volo.Abp;

namespace Mando.App.Track
{
    public class IssueStateException : BusinessException
    {
        public IssueStateException(string code) : base(code)
        {

        }
    }
}
