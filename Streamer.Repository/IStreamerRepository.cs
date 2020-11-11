using System.Threading.Tasks;
using Streamer.Domain;

namespace Streamer.Repository
{
    public interface IStreamerRepository
    {
        // GERAL
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

         // EVENTOS
         Task<Evento []> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
         Task<Evento []> GetAllEventoAsync(bool includePalestrantes);
         Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes);


         // PALESTRANTE
         Task<Palestrante []> GetAllPalestranteAsyncByName(bool includePalestrantes);
         Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includePalestrantes);

         // COURSES
         Task<Course []> GetAllCourseAsyncByName(string name, bool includeProjects);
         Task<Course []> GetAllCourseAsync(bool includeProjects);
         Task<Course> GetCourseAsyncById(int CourseId, bool includeProjects);


         // PROJECTS
         Task<Project []> GetAllProjectAsyncByName(bool includeProjects);
         Task<Project> GetProjectAsync(int ProjectId, bool includeProjects);
    }
}