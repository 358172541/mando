using Volo.Abp;

namespace Mando.App.Store;

public class BookNameDulplicatedException : BusinessException
{
	public BookNameDulplicatedException(string name) : base("BookNameDulplicated")
	{
		WithData("name", name);
	}
}
