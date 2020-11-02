using System.Collections.Generic;
using System.Web.Mvc;
using Client.Models.AdminViewModel;
using Clietn.Models.AdminViewModel;
using Clietn.PresentationService.Interface;
using DomainLogic.Model;
using Microsoft.Ajax.Utilities;

namespace Clietn.Controllers
{
    public partial class AdminController : Controller
    {
        private readonly ITrackPresentationService trackPresentationService;
        private readonly ISongWriterPresentationService songWriterPresentationService;
        private readonly IGenrePresentationService genrePresentationService;
        private readonly IAlbumPresentationService albumPresentationService;

        public AdminController(
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

        [Authorize(Roles = "Subscription")]
        [HttpGet]
        public virtual ActionResult AddAlbum()
        {
            SelectList genres = new SelectList(genrePresentationService.GetAllGenre());
            ViewBag.Genres = genres;

            SelectList songWriters = new SelectList(songWriterPresentationService.GetAllSongWriters());
            ViewBag.SongWriters = songWriters;

            return View();
        }

        [Authorize(Roles = "Subscription")]
        [HttpPost]
        public virtual ActionResult AddAlbum(AlbumAdminModel albumAdminModel)
        {
            var genre = genrePresentationService.GetGenreByName(albumAdminModel.Genre);
            var songWriter = songWriterPresentationService.GetSongWriterByName(albumAdminModel.SongWriter);
            Album album = new Album()
            {
                Genre = genre,
                AlbumTitle = albumAdminModel.AlbumName,
                Info = albumAdminModel.Comment,
                SongWriter = songWriter
            };
            albumPresentationService.AddAlbumToDB(album);
            return RedirectToAction("/StartAdmin");
        }

        [Authorize(Roles = "Subscription")]
        [HttpGet]
        public virtual ActionResult AddGenre()
        {
            return View();
        }

        [Authorize(Roles = "Subscription")]
        [HttpPost]
        public virtual ActionResult AddGenre(GenreAdminModel genreAdminModel)
        {
            // mapping
            Genre genre = new Genre()
            {
                Name = genreAdminModel.GenreName
            };
            genrePresentationService.AddGenreToDB(genre);
            return RedirectToAction("/StartAdmin");
        }

        [Authorize(Roles = "Subscription")]
        [HttpGet]
        public virtual ActionResult AddSongWriter()
        {
            SelectList genres = new SelectList(genrePresentationService.GetAllGenre());
            ViewBag.Genres = genres;

            return View();
        }

        [Authorize(Roles = "Subscription")]
        [HttpPost]
        public virtual ActionResult AddSongWriter(SongWriterAdminModel songWriterAdminModel)
        {
            SongWriter songWriter = new SongWriter()
            {
                Age = songWriterAdminModel.Age,
                Genres = new List<Genre>()
                {
                    genrePresentationService.GetGenreByName(songWriterAdminModel.Genre)
                },
                Name = songWriterAdminModel.Name,
                Info = songWriterAdminModel.Info
            };
            songWriterPresentationService.AddSongWriterToDB(songWriter);
            return RedirectToAction("/StartAdmin");
        }

        [Authorize(Roles = "Subscription")]
        [HttpGet]
        public virtual ActionResult AddTrack()
        {
            SelectList genres = new SelectList(genrePresentationService.GetAllGenre());
            ViewBag.Genres = genres;

            SelectList songWriters = new SelectList(songWriterPresentationService.GetAllSongWriters());
            ViewBag.SongWriters = songWriters;

            SelectList albums = new SelectList(albumPresentationService.GetAllAlbums());
            ViewBag.Albums = albums;
            return View();
        }

        [Authorize(Roles = "Subscription")]
        [HttpPost]
        public virtual ActionResult AddTrack(TrackAdminModel trackAdminModel)
        {
            // Mapping
            Track track = new Track()
            {
                Genre = genrePresentationService.GetGenreByName(trackAdminModel.Genre),
                SongTitle = trackAdminModel.SongTitle,
                SongWriter = songWriterPresentationService.GetSongWriterByName(trackAdminModel.SongWriter),
                Album = albumPresentationService.GetAlbumByName(trackAdminModel.Album)
            };
            trackPresentationService.AddTrackToDB(track);
            return RedirectToAction("/StartAdmin");
        }

        [Authorize(Roles = "Subscription")]
        public virtual ActionResult StartAdmin()
        {
            return View();
        }

        public virtual ActionResult Edit()
        {
            List<TrackAdminModel> allTrackAdmins = trackPresentationService.GetAllTracks();
            return View(allTrackAdmins);
        }

        [HttpPost]
        public virtual ActionResult EditTrackPost(TrackAdminModel trackAdminModel)
        {
            Track track = new Track()
            {
                Genre = genrePresentationService.GetGenreByName(trackAdminModel.Genre),
                SongTitle = trackAdminModel.SongTitle,
                SongWriter = songWriterPresentationService.GetSongWriterByName(trackAdminModel.SongWriter),
                Album = albumPresentationService.GetAlbumByName(trackAdminModel.Album),
                TrackId = trackAdminModel.TrackId
            };
            trackPresentationService.EditTrack(track);
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public virtual ActionResult EditTrackGet (int id)
        {
            SelectList genres = new SelectList(genrePresentationService.GetAllGenre());
            ViewBag.Genres = genres;

            SelectList songWriters = new SelectList(songWriterPresentationService.GetAllSongWriters());
            ViewBag.SongWriters = songWriters;

            SelectList albums = new SelectList(albumPresentationService.GetAllAlbums());
            ViewBag.Albums = albums;


            var trackAdminModel = trackPresentationService.GetTrackById(id);

            return View(trackAdminModel);
        }
        

        public virtual ActionResult Delete (int id)
        {
            trackPresentationService.DeleteTrack(id);
            return RedirectToAction("Edit");
        }
    }
}