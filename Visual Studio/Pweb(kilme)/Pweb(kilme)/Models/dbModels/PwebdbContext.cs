using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pweb_kilme_.Models.dbModels;

public partial class PwebdbContext : IdentityDbContext<ApplicationUser, ApplicationRol, int>
{
    public PwebdbContext()
    {
    }

    public PwebdbContext(DbContextOptions<PwebdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Datosreservacion> Datosreservacions { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Imgsquintum> Imgsquinta { get; set; }

    public virtual DbSet<Quintum> Quinta { get; set; }

    public virtual DbSet<Redessociale> Redessociales { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Datosreservacion>(entity =>
        {
            entity.HasKey(e => e.IdReservacion).HasName("PK_datosreservacion_IdReservacion");

            entity.Property(e => e.IdReservacion).ValueGeneratedNever();

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Datosreservacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("datosreservacion$datosreservacion_ibfk_3");

            entity.HasOne(d => d.IdQuintaNavigation).WithMany(p => p.Datosreservacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("datosreservacion$datosreservacion_ibfk_4");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Datosreservacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("datosreservacion$datosreservacion_ibfk_2");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK_estado_IdEstado");

            entity.Property(e => e.IdEstado).ValueGeneratedNever();
        });

        modelBuilder.Entity<Imgsquintum>(entity =>
        {
            entity.HasKey(e => e.IdImg).HasName("PK_imgsquinta_IdImg");

            entity.Property(e => e.IdImg).ValueGeneratedNever();
        });

        modelBuilder.Entity<Quintum>(entity =>
        {
            entity.HasKey(e => e.IdQuinta).HasName("PK_quinta_IdQuinta");

            entity.Property(e => e.IdQuinta).ValueGeneratedNever();

            entity.HasOne(d => d.IdImagenNavigation).WithMany(p => p.Quinta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quinta$quinta_ibfk_1");

            entity.HasOne(d => d.IdRedesNavigation).WithMany(p => p.Quinta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quinta$quinta_ibfk_2");
        });

        modelBuilder.Entity<Redessociale>(entity =>
        {
            entity.HasKey(e => e.IdRedes).HasName("PK_redessociales_IdRedes");

            entity.Property(e => e.IdRedes).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
