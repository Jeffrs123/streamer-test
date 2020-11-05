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
    [Route("cursos")] //[Route("[controller]")]

    public class CourseController : ControllerBase
    {

        public readonly StreamerContext _context;

        public CourseController(StreamerContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        //public ActionResult<IEnumerable<Course>> Get()
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Courses.ToListAsync();
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
                var results = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bando de dados falhou");
            }
        }
    }
}