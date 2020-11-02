using DomainLogic.Model;
using System.Collections.Generic;

namespace DomainLogic.Repositories
{
    public interface ITrackRepository : IBaseRepository<Track>
    {
        List<Track> GetTracksByTitle(string TrackTitle);

        List<Track> GetTracksBySongWriter(string SongWriterName);

        List<Track> GetTracksByAlbum(string AlbumTitle);

        List<Track> GetTracksByGenre(string Genres);

        void AddTrackToDB(Track track);
    }
}
