using Volo.Abp;

namespace Mando.App.Track;

public class IssueTitleDulplicatedException : BusinessException
{
	public IssueTitleDulplicatedException(string title) : base("IssueTitleDulplicated")
	{
		WithData("title", title);
	}
}
