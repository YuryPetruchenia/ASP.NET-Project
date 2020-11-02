namespace DomainLogic.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DomainLogic.Model;

    public interface IAlbumRepository : IBaseRepository<Album>
    {
       List<Album> GetAlbumsByName(string AlbumName);

        List<Album> GetAlbumsBySongTitle(string SongTitle);

       List<Album> GetAlbumsBySongWriter(string SongWriterName);

        void AddAlbumToDB(Album album);

        List<string> GetAllAlbum();

        Album GetAlbumByName(string AlbumName);
    }
}
