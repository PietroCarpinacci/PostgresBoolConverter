using Microsoft.EntityFrameworkCore;
using PostgresBoolConverter.Entensions;

namespace PostgresBoolConverter.Model
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TableEntity> TableEntity { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TableEntityConfiguration());

            if (Database.IsNpgsql())
            {
                modelBuilder.HasPostgresExtension("uuid-ossp");
                modelBuilder.SolveNamesToLowerCase();
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
