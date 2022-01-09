using Volo.Abp.Modularity;

namespace Mando
{
    [DependsOn(
        typeof(ApplicationModule),
        typeof(MandoDomainTestModule)
        )]
    public class MandoApplicationTestModule : AbpModule
    {

    }
}