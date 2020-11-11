using System.Threading.Tasks;
using Streamer.Domain;

namespace Streamer.Repository
{
    public class StreamerRepository : IStreamerRepository
    {


        private readonly StreamerContext _context;
        public StreamerRepository(StreamerContext context)
        {
            _context = context;

        }




        // GERAIS
        public void Add<T>(T entity) where T : class
        {
            //throw new System.NotImplementedException();
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }




        // COURSE
        public Task<Course> GetCourseAsyncById(int CourseId, bool includeProjects)
        {
            throw new System.NotImplementedException();
        }
        public Task<Course[]> GetAllCourseAsync(bool includeProjects)
        {
            throw new System.NotImplementedException();
        }
        public Task<Course[]> GetAllCourseAsyncByName(string name, bool includeProjects)
        {
            throw new System.NotImplementedException();
        }





        // EVENTO
        public Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }
        public Task<Evento[]> GetAllEventoAsync(bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }
        public Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }





        // PALESTRANTE
        public Task<Palestrante[]> GetAllPalestranteAsyncByName(bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }
        public Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }





        // PROJECT
        public Task<Project[]> GetAllProjectAsyncByName(bool includeProjects)
        {
            throw new System.NotImplementedException();
        }
        public Task<Project> GetProjectAsync(int ProjectId, bool includeProjects)
        {
            throw new System.NotImplementedException();
        }
    }
}