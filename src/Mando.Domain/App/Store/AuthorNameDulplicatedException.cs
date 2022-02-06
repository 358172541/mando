using Volo.Abp;

namespace Mando.App.Store;

public class AuthorNameDulplicatedException : BusinessException
{
	public AuthorNameDulplicatedException(string name) : base("AuthorNameDulplicated")
	{
		WithData("name", name);
	}
}
