using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapDominio.Entity;

namespace CapInfraestructura.Context
{
    public class ContextoDB : DbContext
    {
        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Encuesta> Encuenta { get; set; }
        public DbSet<Preguntas> Preguntas { get; set; }
        public DbSet<Respuestas> Respuestas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(Usu =>
            {
                Usu.HasKey(u => u.IdUsuario);
                Usu.Property(Usu => Usu.IdUsuario).UseIdentityColumn().ValueGeneratedOnAdd();
                Usu.Property(u => u.Nombre).HasMaxLength(50).IsRequired();
                Usu.Property(u => u.Correo).HasMaxLength(50).IsRequired();
                Usu.Property(u => u.Contrasena).HasMaxLength(255).IsRequired();
                Usu.Property(u => u.Rol).HasMaxLength(50).IsRequired();
                Usu.Property(u => u.FechaRegistro).IsRequired();

                Usu.ToTable("Usuarios");


            });

            modelBuilder.Entity<Encuesta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.EsPublica).IsRequired();
                entity.Property(e => e.FechaCreacion).IsRequired();
                entity.HasOne(e => e.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioId);

                entity.ToTable("Encuestas");
            });

            // Configuración de Preguntas
            modelBuilder.Entity<Preguntas>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Texto).IsRequired().HasMaxLength(250);
                entity.HasOne(p => p.Encuesta)
                      .WithMany(e => e.Preguntas)
                      .HasForeignKey(p => p.EncuestaId);
            });

            // Configuración de Respuestas
            modelBuilder.Entity<Respuestas>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.HasOne(r => r.Pregunta)
                      .WithMany(p => p.Respuestas)
                      .HasForeignKey(r => r.PreguntaId);
                entity.HasOne(r => r.Usuario)
                      .WithMany()
                      .HasForeignKey(r => r.UsuarioId);
            });

        }
    }
}
