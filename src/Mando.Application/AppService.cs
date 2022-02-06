using Volo.Abp.Application.Services;
using LocalizationResource = Mando.Localization.LocalizationResource;

namespace Mando;

public abstract class AppService : ApplicationService
{
	protected AppService()
	{
		LocalizationResource = typeof(LocalizationResource);
	}
}
