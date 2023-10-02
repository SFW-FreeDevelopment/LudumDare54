using System;

namespace LD54.Models
{
    public class HighscoreDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double TimeTaken { get; set; }
        public DateTime TimeFinished { get; set; }
        public int Items { get; set; }
    }
}