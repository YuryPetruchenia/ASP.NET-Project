using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Model
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string AlbumTitle { get; set; }

        public Genre Genre { get; set; }

        public SongWriter SongWriter { get; set; }

        public string Info { get; set; }
    }
}
