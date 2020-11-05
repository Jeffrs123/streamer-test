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
    [Route("cursos")] //[Route("[controller]")]

    public class CourseController : ControllerBase
    {

        public readonly StreamerContext _context;

        public CourseController(StreamerContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return _context.Courses.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }
    }
}