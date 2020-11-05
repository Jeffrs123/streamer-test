using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamer.API.Model;

namespace Streamer.API.Controllers
{    
    [ApiController]
    [Route("cursos")] //[Route("[controller]")]

    public class Courses : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return new Course[] {
                new Course() {
                    Id = 1,
                    Name = "Angular - Novo"
                },
                new Course() {
                    Id = 2,
                    Name = ".Net Core - Novo"
                }
            };
        }


        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            return new Course[] {
                new Course() {
                    Id = 1,
                    Name = "Angular - Novo"
                },
                new Course() {
                    Id = 2,
                    Name = ".Net Core - Novo"
                }
            }.FirstOrDefault(x => x.Id == id);
        }
    }
}