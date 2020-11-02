using DomainLogic.Model;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configurations.MusicConfigurations
{
    class AlbumConfigurations :EntityTypeConfiguration<Album>
    {
        public AlbumConfigurations()
        {
            HasKey(s => s.AlbumId);
            HasRequired(c => c.Genre).WithOptional().WillCascadeOnDelete(false) ;
            HasRequired(c => c.SongWriter).WithOptional().WillCascadeOnDelete(false);
        }
    }
}
