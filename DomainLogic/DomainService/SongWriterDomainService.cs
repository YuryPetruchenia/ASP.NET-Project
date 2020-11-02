using DomainLogic.DomainService.Interface;
using DomainLogic.Model;
using DomainLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public SongWriter GetSongWriterByName(string SongWriterName)
        {
            return songWriterRepository.GetSongWriterByName(SongWriterName);
        }

        public List<SongWriter> GetSongWritersByAlbumTitle(string AlbumTitle)
        {
            return songWriterRepository.GetSongWritersByAlbumTitle(AlbumTitle);
        }

        public List<SongWriter> GetSongWritersByGenres(string Genres)
        {
            return songWriterRepository.GetSongWritersByGenres(Genres);
        }

        public List<SongWriter> GetSongWritersByName(string SongWriterName)
        {
            return songWriterRepository.GetSongWritersByName(SongWriterName);
        }

        public List<SongWriter> GetSongWritersByTracksTitle(string SongTitle)
        {
            return songWriterRepository.GetSongWritersByTracksTitle(SongTitle);
        }
    }
}
