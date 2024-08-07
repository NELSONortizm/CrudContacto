using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudContacto.Models
{
    public partial class DBPRUEBASContext : DbContext
    {
        public DBPRUEBASContext()
        {
        }

        public DBPRUEBASContext(DbContextOptions<DBPRUEBASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencium> Agencia { get; set; } = null!;
        public virtual DbSet<Contacto> Contactos { get; set; } = null!;
        public virtual DbSet<Destino> Destinos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Origen> Origens { get; set; } = null!;
        public virtual DbSet<Parametro> Parametros { get; set; } = null!;
        public virtual DbSet<Tarea> Tareas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=CO-DEV-18; DataBase=DBPRUEBAS;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencium>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("agencia");

                entity.Property(e => e.AgencyId)
                    .HasMaxLength(64)
                    .HasColumnName("AgencyID");

                entity.Property(e => e.Departamento).HasMaxLength(64);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre).HasMaxLength(256);
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto)
                    .HasName("PK__Contacto__4B1329C74A29E1BD");

                entity.ToTable("Contacto");

                entity.Property(e => e.IdContacto).HasColumnName("idContacto");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Destino>(entity =>
            {
                entity.ToTable("Destino");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre).HasMaxLength(256);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.ToTable("Empleado");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Origen>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("origen");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre).HasMaxLength(256);
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Parametro");

                entity.Property(e => e.AgenciaId).HasColumnName("Agencia_ID");

                entity.Property(e => e.DestinoId)
                    .HasMaxLength(64)
                    .HasColumnName("Destino_ID");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OrigenId)
                    .HasMaxLength(64)
                    .HasColumnName("Origen_ID");

                entity.Property(e => e.Parametro1)
                    .HasMaxLength(64)
                    .HasColumnName("Parametro");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea)
                    .HasName("PK__Tarea__EADE909803924C6D");

                entity.ToTable("Tarea");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
