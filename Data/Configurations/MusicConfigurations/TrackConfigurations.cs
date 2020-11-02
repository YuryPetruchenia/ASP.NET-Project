using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using DomainLogic.Model;

namespace Data.Configurations.MusicConfigurations
{
    public class TrackConfigurations : EntityTypeConfiguration<Track>
    {
       public TrackConfigurations()
        {
            HasKey(k => k.TrackId);
            HasRequired(x => x.Genre);
            HasRequired(x => x.Album);
            HasRequired(x => x.SongWriter);
            Property(p => p.SongTitle).IsRequired().HasMaxLength(30);
        }
    }
}
