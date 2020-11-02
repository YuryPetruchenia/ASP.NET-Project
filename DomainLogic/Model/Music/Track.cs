using System.Collections.Generic;

namespace DomainLogic.Model
{
    public class Track
    {
        public ICollection<Subscription> SubscriptionsLikedSong { get; set; }

        public int TrackId { get; set; }

        public string SongTitle { get; set; }

        public SongWriter SongWriter { get; set; }

        public Album Album { get; set; }

        public Genre Genre { get; set; }
    }
}
