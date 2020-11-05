using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamer.API.Data;
using Streamer.API.Model;

namespace Streamer.API.Controllers
{
    [ApiController]
    [Route("projetos")] //[Route("[controller]")]

    public class ProjectController : ControllerBase
    {
        public readonly StreamerContext _context;

        public ProjectController(StreamerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = _context.Projects.ToList();
                return Ok(results);            
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bando de dados falhou");
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            return _context.Projects.FirstOrDefault(x => x.Id == id);
        }

        /*
        public readonly DataContext _context;

        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }

        
        // GET eventos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bando de dados falhou");
            }
        }

        // GET eventos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _context.Eventos.FirstOrDefaultAsync( x => x.EventoId == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bando de dados falhou");
            }
        }

        */
    
    }
}