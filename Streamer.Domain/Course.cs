using System.Collections.Generic;

namespace Streamer.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<CourseProject> CourseProjects { get; set; }
    }
}