using Mando.App.Store;
using Mando.App.Track;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiScopes;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.Devices;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.IdentityServer.Grants;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Mando.App
{
	[ConnectionStringName("Default")]
	[ReplaceDbContext(
		typeof(IIdentityDbContext),
		typeof(IIdentityServerDbContext),
		typeof(IFeatureManagementDbContext),
		typeof(IPermissionManagementDbContext),
		typeof(ISettingManagementDbContext),
		typeof(ITenantManagementDbContext)
		)]
	public class AppDbContext :
		AbpDbContext<AppDbContext>,
		IIdentityDbContext,
		IIdentityServerDbContext,
		IFeatureManagementDbContext,
		IPermissionManagementDbContext,
		ISettingManagementDbContext,
		ITenantManagementDbContext
	{
		public AppDbContext(
			DbContextOptions<AppDbContext> opts)
			: base(opts)
		{
		}

		#region IIdentityDbContext
		public DbSet<IdentityUser> Users { get; set; }
		public DbSet<IdentityRole> Roles { get; set; }
		public DbSet<IdentityClaimType> ClaimTypes { get; set; }
		public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
		public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
		public DbSet<IdentityLinkUser> LinkUsers { get; set; }
		#endregion
		#region IIdentityServerDbContext
		public DbSet<ApiResource> ApiResources { get; set; }
		public DbSet<ApiResourceSecret> ApiResourceSecrets { get; set; }
		public DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }
		public DbSet<ApiResourceScope> ApiResourceScopes { get; set; }
		public DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }
		public DbSet<ApiScope> ApiScopes { get; set; }
		public DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }
		public DbSet<ApiScopeProperty> ApiScopeProperties { get; set; }
		public DbSet<IdentityResource> IdentityResources { get; set; }
		public DbSet<IdentityResourceClaim> IdentityClaims { get; set; }
		public DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<ClientGrantType> ClientGrantTypes { get; set; }
		public DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }
		public DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }
		public DbSet<ClientScope> ClientScopes { get; set; }
		public DbSet<ClientSecret> ClientSecrets { get; set; }
		public DbSet<ClientClaim> ClientClaims { get; set; }
		public DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }
		public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }
		public DbSet<ClientProperty> ClientProperties { get; set; }
		public DbSet<PersistedGrant> PersistedGrants { get; set; }
		public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
		#endregion
		#region IFeatureManagementDbContext
		public DbSet<FeatureValue> FeatureValues { get; set; }
		#endregion
		#region IPermissionManagementDbContext
		public DbSet<PermissionGrant> PermissionGrants { get; set; }
		#endregion
		#region ISettingManagementDbContext
		public DbSet<Setting> Settings { get; set; }
		#endregion
		#region ITenantManagementDbContext
		public DbSet<Tenant> Tenants { get; set; }
		public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
		#endregion

		#region Store
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
		private static void ConfigureStore(ModelBuilder budr)
		{
			budr.Entity<Author>(budr =>
			{
				budr.ToTable("AppStoreAuthors");
				budr.ConfigureByConvention();
				budr.Property(x => x.Name)
					.IsRequired()
					.HasMaxLength(AuthorConsts.NameMaxLength);
				budr.HasIndex(x => x.Name);
			});

			budr.Entity<Book>(budr =>
			{
				budr.ToTable("AppStoreBooks");
				budr.ConfigureByConvention();
				budr.Property(x => x.Name)
					.IsRequired()
					.HasMaxLength(BookConsts.NameMaxLength);
				budr.HasIndex(x => x.Name);
				budr.HasOne<Author>()
					.WithMany()
					.HasForeignKey(x => x.AuthorId)
					.IsRequired();
			});
		}
		#endregion

		#region Track
		public DbSet<Issue> Issues { get; set; }

		private static void ConfigureTrack(ModelBuilder budr)
		{
			budr.Entity<Issue>(budr =>
			{
				budr.ToTable("AppTrackIssues");
				budr.ConfigureByConvention();
				budr.Property(x => x.Title)
					.IsRequired()
					.HasMaxLength(IssueConsts.TitleMaxLength);
			});
		}
		#endregion

		protected override void OnModelCreating(ModelBuilder budr)
		{
			base.OnModelCreating(budr);

			budr.ConfigureFeatureManagement();
			budr.ConfigureIdentity();
			budr.ConfigureIdentityServer();
			budr.ConfigurePermissionManagement();
			budr.ConfigureSettingManagement();
			budr.ConfigureTenantManagement();

			ConfigureStore(budr);
			ConfigureTrack(budr);
		}
	}
}
