using System.Collections.Generic;
using System.Linq;
using Clietn.App_Start;
using Clietn.Models.ViewModels;
using Clietn.PresentationService.Interface;
using DomainLogic.DomainService.Interface;
using DomainLogic.Model;

namespace Clietn.PresentationService
{
    public class AlbumPresentationService : IAlbumPresentationService
    {
        private readonly IAlbumDomainService albumDomainService;
        private readonly AutoMapperConfig mappingProfile = new AutoMapperConfig();

        public AlbumPresentationService(IAlbumDomainService albumDomainService)
        {
            this.albumDomainService = albumDomainService;
        }

        public void AddAlbumToDB(Album album)
        {
            albumDomainService.AddAlbumToDB(album);
        }

        public List<AlbumViewModel> GetAlbum(string albumName)
        {
            var albumByName = albumDomainService.GetAlbumsByName(albumName);
            var albumByTrackTitle = albumDomainService.GetAlbumsBySongTitle(albumName);
            var albumBySongWriter = albumDomainService.GetAlbumsBySongWriter(albumName);
            var album = albumByName.Union(albumBySongWriter).Union(albumByTrackTitle).ToList();
            var viewAlbum = mappingProfile.Mapper.Map<List<Album>, List<AlbumViewModel>>(album);
            return viewAlbum;
        }

        public Album GetAlbumByName(string albumName)
        {
           return albumDomainService.GetAlbumByName(albumName);
        }

        public List<string> GetAllAlbums()
        {
            return albumDomainService.GetAllAlbum();
        }
    }
}