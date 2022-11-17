using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aduanas.Models
{
    public partial class AduanasContext : DbContext
    {
        public AduanasContext()
        {
        }

        public AduanasContext(DbContextOptions<AduanasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencia> Agencias { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Paise> Paises { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sexo> Sexos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost; database=Aduanas; integrated security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencia>(entity =>
            {
                entity.HasKey(e => e.IdAgencia)
                    .HasName("PK__agencias__2F17429241844231");

                entity.ToTable("agencias");

                entity.Property(e => e.IdAgencia).HasColumnName("idAgencia");

                entity.Property(e => e.Direccion)
                    .HasColumnType("text")
                    .HasColumnName("direccion");

                entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.Property(e => e.NombreAgencia)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombreAgencia");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Agencia)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("FK__agencias__idPais__3C69FB99");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__empleado__5295297CF37A231A");

                entity.ToTable("empleados");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.Clave)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.IdAgencia).HasColumnName("idAgencia");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdAgenciaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdAgencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__empleados__idAge__2A4B4B5E");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__empleados__idPer__29572725");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__empleados__idRol__2B3F6F97");
            });

            modelBuilder.Entity<Paise>(entity =>
            {
                entity.ToTable("paises");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Habilitado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("habilitado")
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__personas__A478814175BD1575");

                entity.ToTable("personas");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Correo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.IdPaisNaturalizacion).HasColumnName("idPaisNaturalizacion");

                entity.Property(e => e.IdPaisOrigen).HasColumnName("idPaisOrigen");

                entity.Property(e => e.IdSexo).HasColumnName("idSexo");

                entity.Property(e => e.Identidad)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("identidad")
                    .HasDefaultValueSql("('0000000000000')");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdPaisNaturalizacionNavigation)
                    .WithMany(p => p.PersonaIdPaisNaturalizacionNavigations)
                    .HasForeignKey(d => d.IdPaisNaturalizacion)
                    .HasConstraintName("FK__personas__idPais__3E52440B");

                entity.HasOne(d => d.IdPaisOrigenNavigation)
                    .WithMany(p => p.PersonaIdPaisOrigenNavigations)
                    .HasForeignKey(d => d.IdPaisOrigen)
                    .HasConstraintName("FK__personas__idPais__3D5E1FD2");

                entity.HasOne(d => d.IdSexoNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdSexo)
                    .HasConstraintName("FK__personas__idSexo__3F466844");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__roles__3C872F7637E27B5F");

                entity.ToTable("roles");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.ToTable("sexos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
