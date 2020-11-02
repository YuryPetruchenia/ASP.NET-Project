using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Model
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }

        public DateTime SubscriptionIsValidUntil { get; set; }

        public ICollection<Track> PlayListDay { get; set; }

        public ICollection<Track> LikedSongs { get; set; }

        public User User { get; set; }
    }
}
