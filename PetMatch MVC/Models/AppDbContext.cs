using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Projeto_PetMatch_MVC.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<animai> animais { get; set; }

    public virtual DbSet<usuario> usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PetMatchDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<animai>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__animais__3213E83F94D3AE57");

            entity.Property(e => e.criado_em).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.especie).HasMaxLength(20);
            entity.Property(e => e.foto_url).HasMaxLength(255);
            entity.Property(e => e.idade).HasMaxLength(40);
            entity.Property(e => e.localizacao).HasMaxLength(100);
            entity.Property(e => e.nome).HasMaxLength(80);
            entity.Property(e => e.status)
                .HasMaxLength(20)
                .HasDefaultValue("disponivel");
            entity.Property(e => e.vacinado).HasDefaultValue(true);

            entity.HasOne(d => d.usuario).WithMany(p => p.animais)
                .HasForeignKey(d => d.usuario_id)
                .HasConstraintName("FK_Animais_Usuarios");
        });

        modelBuilder.Entity<usuario>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__usuarios__3213E83F171C5165");

            entity.HasIndex(e => e.email, "UQ__usuarios__AB6E6164111560EE").IsUnique();

            entity.Property(e => e.criado_em).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.email).HasMaxLength(120);
            entity.Property(e => e.nome).HasMaxLength(100);
            entity.Property(e => e.perfil)
                .HasMaxLength(20)
                .HasDefaultValue("usuario");
            entity.Property(e => e.senha).HasMaxLength(255);
            entity.Property(e => e.telefone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
