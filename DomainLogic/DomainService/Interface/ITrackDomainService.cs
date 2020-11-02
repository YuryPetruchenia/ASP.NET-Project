using DomainLogic.Model;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DomainLogic.DomainService.Interface
{
    public interface ITrackDomainService
    {
        List<Track> GetTrackByTitle(string TrackTitle);

        List<Track> GetTracksBySongWriter(string SongWriterName);

        List<Track> GetTracksByAlbum(string AlbumTitle);

        List<Track> GetTracksByGenre(string Genres);

        void AddTrackToDB(Track track);

        List<Track> GetAllTracks();

        Track GetTrackById(int id);

        void EditTrack(Track track);

        void DeleteTrack(int id);
    }
}
