using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IngenieriaInversa
{
    public partial class BasePruebaReverseContext : DbContext
    {
        public BasePruebaReverseContext()
        {
        }

        public BasePruebaReverseContext(DbContextOptions<BasePruebaReverseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Continente> Continente { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=RENDER2WEB\\SQLEXPRESS;Database=BasePruebaReverse;User ID=render2web;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.IdCiudad);

                entity.Property(e => e.IdCiudad).ValueGeneratedNever();

                entity.Property(e => e.Altura).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Latitud).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Longitud).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NombreCiudad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Ciudad)
                    .HasForeignKey(d => d.PaisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciudad_Pais");
            });

            modelBuilder.Entity<Continente>(entity =>
            {
                entity.HasKey(e => e.IdContinente);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.IdPais);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePais)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Continente)
                    .WithMany(p => p.Pais)
                    .HasForeignKey(d => d.ContinenteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pais_Continente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
