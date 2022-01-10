using Mando.App.Authors;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Mando
{
    [ConnectionStringName("Default")]
    public class DefaultDbContext : AbpDbContext<DefaultDbContext>
    {
        public DefaultDbContext(
            DbContextOptions<DefaultDbContext> opts)
            : base(opts)
        {
        }

        public DbSet<Author> Authors { get; set; }
        private static void ConfigureAuthor(ModelBuilder budr)
        {
            budr.Entity<Author>(budr =>
            {
                budr.ToTable(DomainConsts.DbTablePrefix + "Authors", DomainConsts.DbSchema);
                budr.ConfigureByConvention();
                budr.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(AuthorConsts.NameMaxLength);
                budr.HasIndex(x => x.Name);
            });
        }

        protected override void OnModelCreating(ModelBuilder budr)
        {
            base.OnModelCreating(budr);

            budr.ConfigureFeatureManagement();
            budr.ConfigureIdentity();
            budr.ConfigureIdentityServer();
            budr.ConfigurePermissionManagement();
            budr.ConfigureSettingManagement();
            budr.ConfigureTenantManagement();

            ConfigureAuthor(budr);
        }
    }
}
