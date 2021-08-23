using System.Collections.Generic;

namespace Code.Models
{
    public class Pattern 
    {
        public Translation Name { get; set; }
        public int MoveCount { get; set; }
    }

    public class Technique
    {
        public Translation Name { get; set; }
    }

    public class Translation 
    {
        public string English { get; set; }
        public string Korean { get; set; }
    }

    public class Grade 
    {
        public int Id { get; set; }
        public Translation Name { get; set; }
        public IEnumerable<Pattern> Patterns { get; set; }
        public IEnumerable<Technique> Techniques { get; set; }
    }
}