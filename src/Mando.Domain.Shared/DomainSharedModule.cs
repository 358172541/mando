using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using LocalizationResource = Mando.Localization.LocalizationResource;

namespace Mando
{
    [DependsOn(
        typeof(AbpFeatureManagementDomainSharedModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpPermissionManagementDomainSharedModule),
        typeof(AbpSettingManagementDomainSharedModule),
        typeof(AbpTenantManagementDomainSharedModule)
        )]
    public class DomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext cntx)
        {
            Configure<AbpVirtualFileSystemOptions>(opts =>
            {
                opts.FileSets.AddEmbedded<DomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(opts =>
            {
                opts.Resources
                    .Add<LocalizationResource>()
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Resources");
                opts.DefaultResourceType = typeof(LocalizationResource);
            });

            Configure<AbpExceptionLocalizationOptions>(opts =>
            {
                opts.MapCodeNamespace("Mando", typeof(LocalizationResource));
            });
        }
    }
}
