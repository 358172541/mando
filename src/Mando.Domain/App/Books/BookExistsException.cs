using Volo.Abp;

namespace Mando.App.Books
{
    public class BookExistsException : BusinessException
    {
        public BookExistsException(string name) : base(DomainErrorCodes.BookExists)
        {
            WithData("name", name);
        }
    }
}
