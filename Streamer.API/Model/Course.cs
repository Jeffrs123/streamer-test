using System.ComponentModel.DataAnnotations;

namespace Streamer.API.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}