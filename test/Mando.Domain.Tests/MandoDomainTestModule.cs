using Mando.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Mando
{
    [DependsOn(
        typeof(MandoEntityFrameworkCoreTestModule)
        )]
    public class MandoDomainTestModule : AbpModule
    {

    }
}