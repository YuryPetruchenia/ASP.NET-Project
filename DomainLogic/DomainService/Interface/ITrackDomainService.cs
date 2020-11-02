using System.Collections.Generic;
using DomainLogic.Model;

namespace DomainLogic.DomainService.Interface
{
    public interface ITrackDomainService
    {
        List<Track> GetTrackByTitle(string trackTitle);

        List<Track> GetTracksBySongWriter(string songWriterName);

        List<Track> GetTracksByAlbum(string albumTitle);

        List<Track> GetTracksByGenre(string genres);

        void AddTrackToDB(Track track);
    }
}
