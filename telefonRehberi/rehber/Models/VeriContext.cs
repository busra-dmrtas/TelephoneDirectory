using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace rehber.Models;

public partial class VeriContext : DbContext
{
    public VeriContext()
    {
    }

    public VeriContext(DbContextOptions<VeriContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kisiler> Kisilers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=.\\Data\\veri.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kisiler>(entity =>
        {
            entity.ToTable("Kisiler");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
