using Mando.App.Authors;
using Mando.App.Books;
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
    public class AppDbContext : AbpDbContext<AppDbContext>
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> opts)
            : base(opts)
        {
        }

        public DbSet<Author> Authors { get; set; }
        private static void ConfigureAuthor(ModelBuilder budr)
        {
            budr.Entity<Author>(budr =>
            {
                budr.ToTable("AppAuthors");
                budr.ConfigureByConvention();
                budr.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(AuthorConsts.NameMaxLength);
                budr.HasIndex(x => x.Name);
            });
        }

        public DbSet<Book> Books { get; set; }
        private static void ConfiguureBook(ModelBuilder budr)
        {
            budr.Entity<Book>(budr =>
            {
                budr.ToTable("AppBooks");
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
            ConfiguureBook(budr);
        }
    }
}
