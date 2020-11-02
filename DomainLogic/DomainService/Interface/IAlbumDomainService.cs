using DomainLogic.Model;
using System.Collections.Generic;

namespace DomainLogic.DomainService.Interface
{
    public interface IAlbumDomainService
    {
        List<Album> GetAlbumsByName(string AlbumName);

        List<Album> GetAlbumsBySongTitle(string SongTitle);

        List<Album> GetAlbumsBySongWriter(string SongWriterName);

        void AddAlbumToDB(Album album);

        List<string> GetAllAlbum();

        Album GetAlbumByName(string AlbumName);
    }
}
