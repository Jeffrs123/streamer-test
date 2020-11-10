using Microsoft.EntityFrameworkCore;
using Streamer.Domain;

namespace Streamer.Repository
{
    public class StreamerContext: DbContext
    {
        public StreamerContext(DbContextOptions<StreamerContext> options) : base (options) {}
    
        public DbSet<Project> Projects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseProject> CoursesProjects { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });
            
            modelBuilder.Entity<CourseProject>()
                .HasKey(CP => new { CP.CourseId, CP.ProjectId });
        }
    }
}