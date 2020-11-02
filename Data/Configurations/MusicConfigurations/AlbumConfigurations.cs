using System.Data.Entity.ModelConfiguration;
using DomainLogic.Model;

namespace Data.Configurations.MusicConfigurations
{
    public class AlbumConfigurations : EntityTypeConfiguration<Album>
    {
        public AlbumConfigurations()
        {
            HasKey(s => s.AlbumId);
            HasRequired(c => c.Genre).WithOptional().WillCascadeOnDelete(false);
            HasRequired(c => c.SongWriter).WithOptional().WillCascadeOnDelete(false);
        }
    }
}
