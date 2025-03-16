﻿using Microsoft.EntityFrameworkCore;

namespace EgoPrimer.Entities;

public class CoreContext : DbContext
{
    public DbSet<Focus> Focuses { set; get; }
    public DbSet<Diary> Diaries { set; get; }
    public DbSet<Source> Sources { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={Constants.CoreDbPath}", builder =>
        {
            builder.UseNodaTime();
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}

public class EditionContext : DbContext
{
    public DbSet<Edition> Editions { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={Constants.EditionDbPath}", builder =>
        {
            builder.UseNodaTime();
        });
    }
}
