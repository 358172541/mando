using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Mando;

[DependsOn(
	typeof(DomainSharedModule),
	typeof(AbpFeatureManagementApplicationContractsModule),
	typeof(AbpIdentityApplicationContractsModule),
	typeof(AbpPermissionManagementApplicationContractsModule),
	typeof(AbpSettingManagementApplicationContractsModule),
	typeof(AbpTenantManagementApplicationContractsModule)
	)]
public class ApplicationContractsModule : AbpModule
{
}
