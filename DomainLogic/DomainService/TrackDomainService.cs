using System.Collections.Generic;
using DomainLogic.DomainService.Interface;
using DomainLogic.Model;
using DomainLogic.Repositories;

namespace DomainLogic.DomainService
{
    public class TrackDomainService : ITrackDomainService
    {
        private readonly ITrackRepository trackRepository;

        public TrackDomainService(ITrackRepository trackRepository)
        {
            this.trackRepository = trackRepository;
        }

        public void AddTrackToDB(Track track)
        {
            trackRepository.AddTrackToDB(track);
        }

        public List<Track> GetTrackByTitle(string trackTitle)
        {
             return trackRepository.GetTracksByTitle(trackTitle);
        }

        public List<Track> GetTracksByAlbum(string albumTitle)
        {
            return trackRepository.GetTracksByAlbum(albumTitle);
        }

        public List<Track> GetTracksByGenre(string genres)
        {
            return trackRepository.GetTracksByGenre(genres);
        }

        public List<Track> GetTracksBySongWriter(string songWriterName)
        {
            return trackRepository.GetTracksBySongWriter(songWriterName);
        }
    }
}
