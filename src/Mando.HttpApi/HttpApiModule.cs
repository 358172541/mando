using Localization.Resources.AbpUi;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using LocalizationResource = Mando.Localization.LocalizationResource;

namespace Mando
{
    [DependsOn(
        typeof(ApplicationContractsModule),
        typeof(AbpFeatureManagementHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpSettingManagementHttpApiModule),
        typeof(AbpTenantManagementHttpApiModule)
        )]
    public class HttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext cntx)
        {
            Configure<AbpLocalizationOptions>(opts =>
            {
                opts.Resources
                    .Get<LocalizationResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
