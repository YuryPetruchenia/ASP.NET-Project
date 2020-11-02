using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Clietn.App_Start;
using Clietn.Models.ViewModels;
using Clietn.PresentationService;
using Clietn.PresentationService.Interface;
using DomainLogic.DomainService.Interface;

namespace Clietn.Controllers
{
    public partial class TrackController : Controller
    {
        private readonly ITrackPresentationService trackPresentationService;
        private readonly ISongWriterPresentationService songWriterPresentationService;
        private readonly IGenrePresentationService genrePresentationService;
        private readonly IAlbumPresentationService albumPresentationService;

        public TrackController(
            ITrackPresentationService trackPresentationService,
            IGenrePresentationService genrePresentationService,
            ISongWriterPresentationService songWriterPresentationService,
            IAlbumPresentationService albumPresentationService)
        {
            this.genrePresentationService = genrePresentationService;
            this.songWriterPresentationService = songWriterPresentationService;
            this.trackPresentationService = trackPresentationService;
            this.albumPresentationService = albumPresentationService;
        }

        public virtual ActionResult GetTracks(string titleList)
        {
            SearchViewModel searchViewModel = new SearchViewModel();
            searchViewModel.Songs = trackPresentationService.GetTrack(titleList);
            searchViewModel.Albums = albumPresentationService.GetAlbum(titleList);
            searchViewModel.Autors = songWriterPresentationService.GetSongWriter(titleList);

            TempData["searchViewModel"] = searchViewModel;

            return RedirectToAction("Search", "Track");
        }

        public virtual ActionResult GetUserPlayList(string info)
        {
            var tracks = TempData[info];
            return View(tracks);
        }

        [Authorize(Roles = "Subscription")]
        [HttpGet]
        public virtual ActionResult GetGenresList()
        {
            var allGenres = genrePresentationService.GetAllGenre();
            return View(allGenres);
        }

        [Authorize(Roles = "Subscription")]
        [HttpPost]
        public virtual ActionResult GetGenresList(string genreName)
        {
            var tracks = trackPresentationService.GetTracksByGenre(genreName);
            TempData["genre"] = tracks;
            return RedirectToAction(MVC.Track.GetUserPlayList("genre"));
        }

        [Authorize(Roles = "Subscription")]
        [HttpGet]
        public virtual ActionResult GetAutorsList()
        {
            return View();
        }

        [Authorize(Roles = "Subscription")]
        [HttpPost]
        public virtual ActionResult GetAutorsList(string autor)
        {
            var tracks = trackPresentationService.GetTracksByAutor(autor);
            TempData["autor"] = tracks;
            return RedirectToAction(MVC.Track.GetUserPlayList("autor"));
        }

        [Authorize(Roles = "Subscription")]
        [HttpGet]
        public virtual ActionResult GetAlbumsList() // здесь нужно вывести все альбомы
        {
            return View();
        }

        [Authorize(Roles = "Subscription")]
        [HttpPost]
        public virtual ActionResult GetAlbumsList(string album)
        {
            var tracks = trackPresentationService.GetTracksByAlbum(album);
            TempData["album"] = tracks;
            return RedirectToAction(MVC.Track.GetUserPlayList("album"));
        }

        [Authorize(Roles = "Subscription")]
        public virtual ActionResult Search()
        {
            var searchViewModel = TempData["searchViewModel"];
            return View(searchViewModel);
        }

        [Authorize(Roles = "Subscription")]
        public virtual ActionResult PlayerPartial()
        {
            var songTitle = "Toxicity";

            return PartialView(songTitle);
        }

        [Authorize(Roles = "Subscription")]
        public virtual ActionResult IMusic()
        {
            return View();
        }
    }
}