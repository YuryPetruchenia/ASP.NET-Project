using DomainLogic.Model;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Configurations.MusicConfigurations
{
    class TrackConfigurations : EntityTypeConfiguration<Track>
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
