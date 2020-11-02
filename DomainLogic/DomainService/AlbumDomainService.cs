using DomainLogic.DomainService.Interface;
using DomainLogic.Model;
using DomainLogic.Repositories;
using System.Collections.Generic;

namespace DomainLogic.DomainService
{
    public class AlbumDomainService : IAlbumDomainService
    {
        private readonly IAlbumRepository albumRepository;

        public AlbumDomainService(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        public void AddAlbumToDB(Album album)
        {
            albumRepository.AddAlbumToDB(album);
        }

        public List<Album> GetAlbumsByName(string AlbumName)
        {
            return albumRepository.GetAlbumsByName(AlbumName);
        }

        public List<Album> GetAlbumsBySongTitle(string SongTitle)
        {
            return albumRepository.GetAlbumsBySongTitle(SongTitle);
        }

        public List<Album> GetAlbumsBySongWriter(string SongWriterName)
        {
            return albumRepository.GetAlbumsBySongWriter(SongWriterName);
        }

        public List<string> GetAllAlbum()
        {
            return albumRepository.GetAllAlbum();
        }

        Album IAlbumDomainService.GetAlbumByName(string AlbumName)
        {
            return albumRepository.GetAlbumByName(AlbumName);
        }
    }
}
