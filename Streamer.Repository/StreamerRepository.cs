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
        public async Task<Course[]> GetAllCourseAsync(bool includeProjects = false)
        {
            // Ir ao BD e já coletar os 'Lotes' e 'Redes Sociais'
            IQueryable<Course> query = _context.Courses;
                //.Include(c => c..Lotes)
                //.Include(c => c.RedesSociais)

            // Se parâmetro ativado para também incluir 'Palestrantes', também inserí-los ao retornar os dados ao usuário.
            if (includeProjects)
            {
                query = query
                    .Include(cp => cp.CourseProjects)
                    .ThenInclude(p => p.Project)
                ;
            }

            query = query.OrderBy(c => c.Name);

            return await query.ToArrayAsync();
        }
        public async Task<Course[]> GetAllCourseAsyncByName(string name, bool includeProjects = false)
        {
            // Ir ao BD e já coletar os 'Lotes' e 'Redes Sociais'
            IQueryable<Course> query = _context.Courses;
                //.Include(c => c..Lotes)
                //.Include(c => c.RedesSociais)

            // Se parâmetro ativado para também incluir 'Palestrantes', também inserí-los ao retornar os dados ao usuário.
            if (includeProjects)
            {
                query = query
                    .Include(cp => cp.CourseProjects)
                    .ThenInclude(p => p.Project)
                ;
            }

            query = query
                .OrderBy(c => c.Name)
                .Where(c => c.Name.ToLower().Contains(name.ToLower())) // Adicionado apenas para retornar array de objetos, filtrados pelo "tema".
            ;

            return await query.ToArrayAsync();
        }
        public async Task<Course> GetCourseAsyncById(int CourseId, bool includeProjects = false)
        {
            // Ir ao BD e já coletar os 'Lotes' e 'Redes Sociais'
            IQueryable<Course> query = _context.Courses;
                //.Include(c => c..Lotes)
                //.Include(c => c.RedesSociais)

            // Se parâmetro ativado para também incluir 'Palestrantes', também inserí-los ao retornar os dados ao usuário.
            if (includeProjects)
            {
                query = query
                    .Include(cp => cp.CourseProjects)
                    .ThenInclude(p => p.Project)
                ;
            }

            query = query
                .OrderBy(c => c.Name)
                .Where(c => c.Id == CourseId) // Adicionado apenas para retornar array de objetos, filtrados pelo "tema".
            ;

            return await query.FirstOrDefaultAsync();
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
        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes = false)
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
                .Where(c => c.Tema.ToLower().Contains(tema.ToLower())) // Adicionado apenas para retornar array de objetos, filtrados pelo "tema".
            ;

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes = false)
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
        public async Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos = false)
        {
            // Ir ao BD e já coletar os 'Lotes' e 'Redes Sociais'
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais)
            ;

            // Se parâmetro ativado para também incluir 'Palestrantes', também inserí-los ao retornar os dados ao usuário.
            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.Evento)
                ;
            }

            query = query
                .OrderBy(p => p.Nome)
                .Where(p => p.Id == PalestranteId) // Adicionado apenas para retornar array de objetos, filtrados pelo "tema".
            ;

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetAllPalestranteAsyncByName(string name, bool includeEventos = false)
        {
            // Ir ao BD e já coletar os 'Lotes' e 'Redes Sociais'
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais)
            ;

            // Se parâmetro ativado para também incluir 'Palestrantes', também inserí-los ao retornar os dados ao usuário.
            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.Evento)
                ;
            }

            query = query
                .Where(p => p.Nome.ToLower().Contains(name.ToLower())) // Adicionado apenas para retornar array de objetos, filtrados pelo "tema".
            ;

            return await query.ToArrayAsync();
        }






        // PROJECT
        public async Task<Project> GetProjectAsync(int ProjectId, bool includeCourse = false)
        {
            // Ir ao BD e já coletar os 'Lotes' e 'Redes Sociais'
            IQueryable<Project> query = _context.Projects
                //.Include(c => c.RedesSociais)
            ;

            // Se parâmetro ativado para também incluir 'Palestrantes', também inserí-los ao retornar os dados ao usuário.
            if (includeCourse)
            {
                query = query
                    .Include(cp => cp.Course)
                ;
            }

            query = query
                .OrderBy(p => p.Name)
                .Where(p => p.Id == ProjectId) // Adicionado apenas para retornar array de objetos, filtrados pelo "tema".
            ;

            //return await query.ToArrayAsync();
            return await query.FirstOrDefaultAsync();

        }
        public async Task<Project[]> GetAllProjectAsyncByName(string name, bool includeCourse = false)
        {
            // Ir ao BD e já coletar os 'Lotes' e 'Redes Sociais'
            IQueryable<Project> query = _context.Projects
                //.Include(c => c.RedesSociais)
            ;

            // Se parâmetro ativado para também incluir 'Palestrantes', também inserí-los ao retornar os dados ao usuário.
            if (includeCourse)
            {
                query = query
                    .Include(cp => cp.Course)
                ;
            }

            query = query
                .Where(p => p.Name.ToLower().Contains(name.ToLower())) // Adicionado apenas para retornar array de objetos, filtrados pelo "tema".
            ;

            return await query.ToArrayAsync();
        }
    }
}