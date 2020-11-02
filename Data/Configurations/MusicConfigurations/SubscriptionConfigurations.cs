using System.Data.Entity.ModelConfiguration;
using DomainLogic.Model;

namespace Data.Configurations.MusicConfigurations
{
    public class SubscriptionConfigurations : EntityTypeConfiguration<Subscription>
    {
        public SubscriptionConfigurations()
        {
            HasKey(x => x.SubscriptionId);
            HasMany(x => x.LikedSongs).WithMany(x => x.SubscriptionsLikedSong);
            HasRequired(x => x.User).WithOptional(x => x.Subscription);
            HasMany(x => x.PlayListDay);
        }
    }
}
