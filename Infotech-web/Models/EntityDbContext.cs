using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;
using System.Reactive.Linq;

namespace Infotech_web.Models;

public partial class EntityDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public EntityDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public virtual DbSet<MonthlyRevenue> MonthlyRevenues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MyDB"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<MonthlyRevenue>(entity =>
        {
            entity.HasKey(e => e.RevenueId)
            .HasName("PK__MonthlyR__275F16DD82E9F235");

            entity.ToTable("MonthlyRevenue");

            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MonthYear).HasColumnType("date");
            entity.Property(e => e.Revenue).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
