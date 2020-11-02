using System.Collections.Generic;
using DomainLogic.Model;

namespace DomainLogic.DomainService.Interface
{
    public interface IAlbumDomainService
    {
        List<Album> GetAlbumsByName(string albumName);

        List<Album> GetAlbumsBySongTitle(string songTitle);

        List<Album> GetAlbumsBySongWriter(string songWriterName);

        void AddAlbumToDB(Album album);

        List<string> GetAllAlbum();

        Album GetAlbumByName(string albumName);
    }
}
