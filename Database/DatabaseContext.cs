using Microsoft.EntityFrameworkCore;

namespace KeyRotation.Database;

internal sealed class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }

    public DbSet<MyEntity> MyEntities => Set<MyEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyEntity>(entity =>
        {
            entity.ToTable("MyEntities");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).HasMaxLength(256).IsRequired();
            entity.Property(t => t.Date).IsRequired();
        });

        modelBuilder.Entity<MyEntity>().HasData(
            new MyEntity(Guid.Parse("258492AE-0133-47FC-B3F1-75C0AC33A291"), "Fund 1", DateTime.Now.AddDays(15)),
            new MyEntity(Guid.Parse("F55ADD9C-350A-4B14-BD1D-F13ACA067846"), "Fund 2", DateTime.Now.AddDays(30)),
            new MyEntity(Guid.Parse("E867C517-CE35-4FE5-8CAE-B944DBFD9D54"), "Fund 3", DateTime.Now.AddDays(45)),
            new MyEntity(Guid.Parse("F2B16552-389A-442C-A176-EE46B3CE53A7"), "Fund 4", DateTime.Now.AddDays(60)),
            new MyEntity(Guid.Parse("952347F8-11AF-4BF3-AB62-91E9794D56EC"), "Fund 5", DateTime.Now.AddDays(75)),
            new MyEntity(Guid.Parse("59D1E381-5484-4580-9EB4-8FC364075225"), "Fund 6", DateTime.Now.AddDays(90))
        );
    }
}
