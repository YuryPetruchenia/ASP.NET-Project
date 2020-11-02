using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Clietn.App_Start;
using Clietn.Models.ViewModels;
using Clietn.PresentationService.Interface;
using DomainLogic.DomainService.Interface;
using DomainLogic.Model;

namespace Clietn.PresentationService
{
    public class SongWriterPresentationService : ISongWriterPresentationService
    {
        private readonly ISongWriterDomainService songWriterDomainService;
        private readonly AutoMapperConfig mappingProfile = new AutoMapperConfig();

        public SongWriterPresentationService(ISongWriterDomainService songWriterDomainService)
        {
            this.songWriterDomainService = songWriterDomainService;
        }

        public void AddSongWriterToDB(SongWriter songWriter)
        {
            songWriterDomainService.AddSongWriterToDB(songWriter);
        }

        public List<string> GetAllSongWriters()
        {
            return songWriterDomainService.GetAllSongWriter();
        }

        public List<AutorViewModel> GetSongWriter(string songWriterName)
        {
            var songWriterByName = songWriterDomainService.GetSongWritersByName(songWriterName);
            var songWriterByTrackTitle = songWriterDomainService.GetSongWritersByTracksTitle(songWriterName);
            var songWriterByAlbum = songWriterDomainService.GetSongWritersByAlbumTitle(songWriterName);
            var songWriter = songWriterByAlbum.Union(songWriterByTrackTitle).Union(songWriterByName).ToList();
            var sonhWriterView = mappingProfile.Mapper.Map<List<SongWriter>, List<AutorViewModel>>(songWriter);
            return sonhWriterView;
        }

        public List<SongWriter> GetSongWriterByGenre(string genre)
        {
            return songWriterDomainService.GetSongWritersByGenres(genre);
        }

        public SongWriter GetSongWriterByName(string songWriterName)
        {
            return songWriterDomainService.GetSongWriterByName(songWriterName);
        }
    }
}