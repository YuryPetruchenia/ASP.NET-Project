using DomainLogic.Model;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configurations.MusicConfigurations
{
    class SubscriptionConfigurations: EntityTypeConfiguration<Subscription>
    {
        public SubscriptionConfigurations()
        {
            HasKey(x => x.SubscriptionId);
            HasMany(x => x.LikedSongs).WithMany(x=>x.SubscriptionsLikedSong);
            HasRequired(x => x.User).WithOptional(x=>x.Subscription);
            HasMany(x => x.PlayListDay);
        }
    }
}
