using DomainLogic.DomainService.Interface;
using DomainLogic.Model;
using DomainLogic.Repositories;
using System.Collections.Generic;

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

        public void DeleteTrack(int id)
        {
            trackRepository.DeleteTrack(id);
        }

        public void EditTrack(Track track)
        {
            trackRepository.EditTrack(track);
        }

        public List<Track> GetAllTracks()
        {
            return trackRepository.GetAllTracks();
        }

        public Track GetTrackById(int id)
        {
            return trackRepository.GetTrackById(id);
        }

        public  List<Track> GetTrackByTitle(string TrackTitle)
        {
             return  trackRepository.GetTracksByTitle(TrackTitle);
        }

        public List<Track> GetTracksByAlbum(string AlbumTitle)
        {
            return  trackRepository.GetTracksByAlbum(AlbumTitle);
        }

        public List<Track> GetTracksByGenre(string Genres)
        {
            return  trackRepository.GetTracksByGenre(Genres);
        }

        public  List<Track> GetTracksBySongWriter(string SongWriterName)
        {
            return  trackRepository.GetTracksBySongWriter(SongWriterName); 
        }
    }
}
