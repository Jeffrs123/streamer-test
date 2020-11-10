namespace Streamer.Domain
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Why { get; set; }

        public string What { get; set; }

        public string WhatWillWeDo { get; set; }

        //public enum ProjectStatus { get; set; }
        public string ProjectStatus { get; set; }

        //public string Course { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}