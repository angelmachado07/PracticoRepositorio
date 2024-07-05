using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticoRepositorio.Models;

public partial class PruebaEntityContext : DbContext
{
    public PruebaEntityContext()
    {
    }

    public PruebaEntityContext(DbContextOptions<PruebaEntityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=ANGELMACHADO;Initial Catalog=PruebaEntity;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curso__3213E83F20B8A639");

            entity.ToTable("Curso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreCurso");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3213E83FD42D9D55");

            entity.ToTable("Estudiante");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.IdCurso).HasColumnName("idCurso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK__Estudiant__idCur__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
