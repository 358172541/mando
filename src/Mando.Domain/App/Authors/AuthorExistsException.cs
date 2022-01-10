using Volo.Abp;

namespace Mando.App.Authors
{
    public class AuthorExistsException : BusinessException
    {
        public AuthorExistsException(string name) : base(DomainErrorCodes.AuthorExists)
        {
            WithData("name", name);
        }
    }
}
