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
       List<Album> GetAlbumsByName(string albumName);

       List<Album> GetAlbumsBySongTitle(string songTitle);

       List<Album> GetAlbumsBySongWriter(string songWriterName);

       void AddAlbumToDB(Album album);

       List<string> GetAllAlbum();

       Album GetAlbumByName(string albumName);
    }
}
