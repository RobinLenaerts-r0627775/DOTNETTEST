using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore;
using Soft_Deletes_2.Models;

namespace SoftDeletes.DB;

public class LibraryContext : EasiDbContext
{
    public DbSet<Book> Book { get; set; }

    public DbSet<Publisher> Publisher { get; set; }

    protected readonly IConfiguration Configuration;

    public LibraryContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public LibraryContext() { } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(Configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(Configuration.GetConnectionString("Default")))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var builder = modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasQueryFilter(p => !p.IsDeleted);
        });
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasQueryFilter(p => !p.IsDeleted);
            entity.HasOne(d => d.Publisher)
                .WithMany(p => p.Books);
        });
    }
}