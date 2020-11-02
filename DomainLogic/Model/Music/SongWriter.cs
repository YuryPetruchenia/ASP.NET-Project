using System.Collections.Generic;

namespace DomainLogic.Model
{
    public class SongWriter
    {
        public int SongWriterId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Info { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
