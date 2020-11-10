namespace Streamer.Domain
{
    public class CourseProject
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int Project { get; set; }
        public Project Project { get; set; }
    }
}