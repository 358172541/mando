using Mando.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Mando.Controllers
{
    public abstract class MandoController : AbpController
    {
        protected MandoController()
        {
            LocalizationResource = typeof(LocalizationResource);
        }
    }
}
