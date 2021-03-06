using Mando.App;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Mando;

[DependsOn(
	typeof(DomainModule),
	typeof(AbpEntityFrameworkCoreSqlServerModule),
	typeof(AbpIdentityEntityFrameworkCoreModule),
	typeof(AbpIdentityServerEntityFrameworkCoreModule),
	typeof(AbpFeatureManagementEntityFrameworkCoreModule),
	typeof(AbpPermissionManagementEntityFrameworkCoreModule),
	typeof(AbpSettingManagementEntityFrameworkCoreModule),
	typeof(AbpTenantManagementEntityFrameworkCoreModule)
	)]
public class EntityFrameworkCoreModule : AbpModule
{
	public override void ConfigureServices(ServiceConfigurationContext cntx)
	{
		cntx.Services
			.AddAbpDbContext<AppDbContext>(opts =>
			{
				opts.AddDefaultRepositories(includeAllEntities: true);
			});

		Configure<AbpDbContextOptions>(opts =>
		{
			opts.UseSqlServer();
		});
	}
}
