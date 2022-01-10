using Volo.Abp.AspNetCore.Mvc;
using LocalizationResource = Mando.Localization.LocalizationResource;

namespace Mando
{
    public abstract class HttpApiController : AbpController
    {
        public HttpApiController()
        {
            LocalizationResource = typeof(LocalizationResource);
        }
    }
}
