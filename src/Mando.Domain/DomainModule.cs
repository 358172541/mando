using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Mando;

[DependsOn(
	typeof(DomainSharedModule),
	typeof(AbpFeatureManagementDomainModule),
	typeof(AbpIdentityDomainModule),
	typeof(AbpIdentityServerDomainModule),
	typeof(AbpPermissionManagementDomainIdentityModule),
	typeof(AbpPermissionManagementDomainIdentityServerModule),
	typeof(AbpSettingManagementDomainModule),
	typeof(AbpTenantManagementDomainModule)
	)]
public class DomainModule : AbpModule
{
	public override void ConfigureServices(ServiceConfigurationContext cntx)
	{
		Configure<AbpMultiTenancyOptions>(opts =>
		{
			opts.IsEnabled = true;
		});
	}
}
