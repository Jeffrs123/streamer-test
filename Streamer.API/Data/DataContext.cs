using Microsoft.EntityFrameworkCore;
using Streamer.API.Model;

namespace Streamer.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Project> Projects { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}