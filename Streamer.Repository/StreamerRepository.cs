using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }





        // COURSE
        public Task<Course[]> GetAllCourseAsync(bool includeProjects)
        {
            throw new System.NotImplementedException();
        }
        public Task<Course[]> GetAllCourseAsyncByName(string name, bool includeProjects)
        {
            throw new System.NotImplementedException();
        }
        public Task<Course> GetCourseAsyncById(int CourseId, bool includeProjects)
        {
            throw new System.NotImplementedException();
        }





        // EVENTO
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            // Ir ao BD e já coletar os 'Lotes' e 'Redes Sociais'
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais)
            ;

            // Se parâmetro ativado para também incluir 'Palestrantes', também inserí-los ao retornar os dados ao usuário.
            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante)
                ;
            }

            query = query.OrderByDescending(c => c.DateEvento);

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            // Ir ao BD e já coletar os 'Lotes' e 'Redes Sociais'
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais)
            ;

            // Se parâmetro ativado para também incluir 'Palestrantes', também inserí-los ao retornar os dados ao usuário.
            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante)
                ;
            }

            query = query
                .OrderByDescending(c => c.DateEvento)
                .Where(c => c.Tema.Contains(tema)) // Adicionado apenas para retornar array de objetos, filtrados pelo "tema".
            ;

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes)
        {
            // Ir ao BD e já coletar os 'Lotes' e 'Redes Sociais'
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais)
            ;

            // Se parâmetro ativado para também incluir 'Palestrantes', também inserí-los ao retornar os dados ao usuário.
            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante)
                ;
            }

            query = query
                .OrderByDescending(c => c.DateEvento)
                .Where(c => c.Id == EventoId) // Adicionado apenas para retornar array de objetos, filtrados pelo "tema".
            ;

            return await query.FirstOrDefaultAsync();
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