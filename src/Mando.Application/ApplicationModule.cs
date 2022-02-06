using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Mando;

[DependsOn(
	typeof(DomainModule),
	typeof(ApplicationContractsModule),
	typeof(AbpFeatureManagementApplicationModule),
	typeof(AbpIdentityApplicationModule),
	typeof(AbpPermissionManagementApplicationModule),
	typeof(AbpSettingManagementApplicationModule),
	typeof(AbpTenantManagementApplicationModule)
	)]
public class ApplicationModule : AbpModule
{
	public override void ConfigureServices(ServiceConfigurationContext cntx)
	{
		Configure<AbpAutoMapperOptions>(opts =>
		{
			opts.AddMaps<ApplicationModule>();
		});
	}
}
