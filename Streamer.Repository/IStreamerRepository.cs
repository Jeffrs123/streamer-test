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
    }
}