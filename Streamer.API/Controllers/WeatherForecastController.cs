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
    //[Route("projetos")] //
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {

        public readonly StreamerContext _context;

        public WeatherForecastController(StreamerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            return new Project[] {
                new Project() {
                    Id = 1,
                    Name = "Angular e .Net Core",
                    Image = "link da imagem",
                    Why = "Porque eu quero",
                    What = "retornar um array",
                    WhatWillWeDo = "retornar projeto",
                    ProjectStatus = "status",
                    Course = "curso",
                    CourseId = 1233
                },
                new Project() {
                    Id = 2,
                    Name = "Angular e Só",
                    Image = "link da imagem",
                    Why = "Porque eu quero",
                    What = "retornar um array",
                    WhatWillWeDo = "retornar projeto",
                    ProjectStatus = "status",
                    Course = "curso",
                    CourseId = 6521
                }
            };
        }


        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            return new Project[] {
                new Project() {
                    Id = 1,
                    Name = "Angular e .Net Core",
                    Image = "link da imagem",
                    Why = "Porque eu quero",
                    What = "retornar um array",
                    WhatWillWeDo = "retornar projeto",
                    ProjectStatus = "status",
                    Course = "curso",
                    CourseId = 1233
                },
                new Project() {
                    Id = 2,
                    Name = "Angular e Só",
                    Image = "link da imagem",
                    Why = "Porque eu quero",
                    What = "retornar um array",
                    WhatWillWeDo = "retornar projeto",
                    ProjectStatus = "status",
                    Course = "curso",
                    CourseId = 6521
                }
            }.FirstOrDefault(x => x.Id == id);
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
}
