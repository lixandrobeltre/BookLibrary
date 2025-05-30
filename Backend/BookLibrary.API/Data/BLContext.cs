﻿using BookLibrary.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.API.Data;

public class BLContext : DbContext
{
    public BLContext(DbContextOptions<BLContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Books");
            entity.HasKey(b => b.BookId);
            entity.Property(b => b.Title).IsRequired().HasMaxLength(100);
            entity.Property(b => b.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(b => b.LastName).IsRequired().HasMaxLength(50);
            entity.Property(b => b.TotalCopies).HasDefaultValue(0);
            entity.Property(b => b.CopiesInUse).HasDefaultValue(0);
            entity.Property(b => b.GenderType).HasMaxLength(50);
            entity.Property(b => b.Isbn).HasMaxLength(80);
            entity.Property(b => b.Category).HasMaxLength(50);
            entity.Property(b => b.MarkAs).HasDefaultValue((short)0);
            entity.Property(b => b.CreatedDate).HasDefaultValueSql("GETDATE()");
            entity.Property(b => b.RowId).HasDefaultValueSql("NEWID()");
        });
    }
}
