using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Streamer.API.Data;
using Streamer.API.Model;

namespace Streamer.API.Controllers
{
    [ApiController]
    [Route("teste")] //
    //[Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {

        public readonly StreamerContext _context;

        public WeatherForecastController(StreamerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Projects.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bando de dados falhou");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bando de dados falhou");
            }
        }
    
    }

    /*
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
    */

    /* PROJETO STREAMER


        // COURSE

        // http://localhost:5000/cursos/{CourseId}/projects
        GetByCourse
        [HttpGet]
        Recebe um ID de um 'Course'.
        Retorna uma lista genérica de 'Project'.


        // PROJECT

        // http://localhost:5000/projetos/{ProjectId}
        GetById
        [HttpGet("{ProjectId}")]
        Recebe um ID de um 'Project'.
        Retorna um objeto do tipo 'Project'.

        // http://localhost:5000/projetos/{ProjectId}
        Update
        [HttpPut("{ProjectId}")]
        Recebe um objeto do tipo 'Project' e realiza a atualização do mesmo.
        Retorna um valor booleano.

        // http://localhost:5000/projetos/{ProjectId}
        Delete
        [HttpDelete("{ProjectId}")]
        Recebe um ID de um 'Project' e realizar a remoção do mesmo.
        Retorna um valor booleano.

        // http://localhost:5000/projetos
        Create
        [HttpPost]
        Recebe um objeto do tipo Project e realiza a inserção no banco de dados. Retorna o Id do 'Project' inserido.

    */
}
