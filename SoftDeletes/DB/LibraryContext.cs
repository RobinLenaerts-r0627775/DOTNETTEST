using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore;
namespace SoftDeletes.DB;

public class LibraryContext : DbContext
{
    public DbSet<Book> Book { get; set; }

    public DbSet<Publisher> Publisher { get; set; }

    protected readonly IConfiguration Configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(Configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(Configuration.GetConnectionString("Default")))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Publisher>(entity =>
        {
        entity.HasKey(e => e.ID);
        entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<Book>(entity =>
        {
        entity.HasKey(e => e.ISBN);
        entity.Property(e => e.Title).IsRequired();
        entity.HasOne(d => d.Publisher)
            .WithMany(p => p.Books);
        });
    }
}