using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using LocalizationResource = Mando.Localization.LocalizationResource;

namespace Mando
{
    [DependsOn(
        typeof(ApplicationContractsModule)
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

/*
 <ItemGroup>
    <PackageReference Include="Volo.Abp.FeatureManagement.HttpApi" Version="4.4.4" />
    <PackageReference Include="Volo.Abp.Identity.HttpApi" Version="4.4.4" />
    <PackageReference Include="Volo.Abp.PermissionManagement.HttpApi" Version="4.4.4" />
    <PackageReference Include="Volo.Abp.SettingManagement.HttpApi" Version="4.4.4" />
    <PackageReference Include="Volo.Abp.TenantManagement.HttpApi" Version="4.4.4" />
  </ItemGroup>
*/