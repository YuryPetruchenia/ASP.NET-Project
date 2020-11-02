using System.Collections.Generic;
using DomainLogic.DomainService.Interface;
using DomainLogic.Model;
using DomainLogic.Repositories;

namespace DomainLogic.DomainService
{
    public class SongWriterDomainService : ISongWriterDomainService
    {
        private readonly ISongWriterRepository songWriterRepository;

        public SongWriterDomainService(ISongWriterRepository songWriterRepository)
        {
            this.songWriterRepository = songWriterRepository;
        }

        public void AddSongWriterToDB(SongWriter songWriter)
        {
            songWriterRepository.AddSongWriterToDB(songWriter);
        }

        public List<string> GetAllSongWriter()
        {
           return songWriterRepository.GetAllSongWriter();
        }

        public SongWriter GetSongWriterByName(string songWriterName)
        {
            return songWriterRepository.GetSongWriterByName(songWriterName);
        }

        public List<SongWriter> GetSongWritersByAlbumTitle(string albumTitle)
        {
            return songWriterRepository.GetSongWritersByAlbumTitle(albumTitle);
        }

        public List<SongWriter> GetSongWritersByGenres(string genres)
        {
            return songWriterRepository.GetSongWritersByGenres(genres);
        }

        public List<SongWriter> GetSongWritersByName(string songWriterName)
        {
            return songWriterRepository.GetSongWritersByName(songWriterName);
        }

        public List<SongWriter> GetSongWritersByTracksTitle(string songTitle)
        {
            return songWriterRepository.GetSongWritersByTracksTitle(songTitle);
        }
    }
}
