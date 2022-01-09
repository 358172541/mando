using Volo.Abp.Application.Services;
using LocalizationResource = Mando.Localization.LocalizationResource;

namespace Mando
{
    public abstract class MandoAppService : ApplicationService
    {
        protected MandoAppService()
        {
            LocalizationResource = typeof(LocalizationResource);
        }
    }
}
