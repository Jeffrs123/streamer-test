using Microsoft.EntityFrameworkCore;
using Streamer.API.Model;

namespace Streamer.API.Data
{
    public class StreamerContext: DbContext
    {
        public StreamerContext(DbContextOptions<StreamerContext> options) : base (options) {}
    
        public DbSet<Project> Projects { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}