using System.Collections.Generic;
using Clietn.Models.ViewModels;
using DomainLogic.Model;

namespace Clietn.PresentationService.Interface
{
    public interface IAlbumPresentationService
    {
        List<AlbumViewModel> GetAlbum(string albumName);

        void AddAlbumToDB(Album album);

        List<string> GetAllAlbums();

        Album GetAlbumByName(string albumName);
    }
}
