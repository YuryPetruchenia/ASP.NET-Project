using System.Collections.Generic;
using DomainLogic.DomainService.Interface;
using DomainLogic.Model;
using DomainLogic.Repositories;

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

        public List<Album> GetAlbumsByName(string albumName)
        {
            return albumRepository.GetAlbumsByName(albumName);
        }

        public List<Album> GetAlbumsBySongTitle(string songTitle)
        {
            return albumRepository.GetAlbumsBySongTitle(songTitle);
        }

        public List<Album> GetAlbumsBySongWriter(string songWriterName)
        {
            return albumRepository.GetAlbumsBySongWriter(songWriterName);
        }

        public List<string> GetAllAlbum()
        {
            return albumRepository.GetAllAlbum();
        }

        Album IAlbumDomainService.GetAlbumByName(string albumName)
        {
            return albumRepository.GetAlbumByName(albumName);
        }
    }
}
