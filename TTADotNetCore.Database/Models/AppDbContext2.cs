using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TTADotNetCore.Database.Models;

public partial class AppDbContext2 : DbContext
{
    public AppDbContext2()
    {
    }

    public AppDbContext2(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblUser> TBlUser { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=KPayDB;User ID=sa;Password=sa@123;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Tbl_User");

            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.MoobileNumber).HasMaxLength(11);
            entity.Property(e => e.Balance).HasMaxLength(50);
            entity.Property(e => e.Pin).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
