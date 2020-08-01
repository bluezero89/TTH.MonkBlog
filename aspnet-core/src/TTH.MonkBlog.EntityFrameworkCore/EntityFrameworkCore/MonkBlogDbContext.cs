using TTH.MonkBlog.Pastorals;
using TTH.MonkBlog.StudyHistories;
using TTH.MonkBlog.ReligousLives;
using TTH.MonkBlog.Monks;
using Microsoft.EntityFrameworkCore;
using TTH.MonkBlog.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace TTH.MonkBlog.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See MonkBlogMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class MonkBlogDbContext : AbpDbContext<MonkBlogDbContext>
    {
        public DbSet<Pastoral> Pastorals { get; set; }
        public DbSet<StudyHistory> StudyHistories { get; set; }
        public DbSet<ReligousLife> ReligousLives { get; set; }
        public DbSet<Monk> Monks { get; set; }
        public DbSet<AppUser> Users { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside MonkBlogDbContextModelCreatingExtensions.ConfigureMonkBlog
         */

        public MonkBlogDbContext(DbContextOptions<MonkBlogDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser

                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties.
                 * Also see the MonkBlogEfCoreEntityExtensionMappings class.
                 */
            });

            /* Configure your own tables/entities inside the ConfigureMonkBlog method */

            builder.ConfigureMonkBlog();
        }
    }
}
