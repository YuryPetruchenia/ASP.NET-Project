using System.Collections.Generic;
using DomainLogic.Model;

namespace DomainLogic.Repositories
{
    public interface ITrackRepository : IBaseRepository<Track>
    {
        List<Track> GetTracksByTitle(string trackTitle);

        List<Track> GetTracksBySongWriter(string songWriterName);

        List<Track> GetTracksByAlbum(string albumTitle);

        List<Track> GetTracksByGenre(string genres);

        void AddTrackToDB(Track track);
    }
}
