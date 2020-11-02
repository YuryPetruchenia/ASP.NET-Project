using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Repositories.RepositoryService;
using DomainLogic.Model;
using DomainLogic.Repositories;
using DomainLogic.UnitOfWork;

namespace Data.Repositories
{
    public class TrackRepository : BaseRepository<Track>, ITrackRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public TrackRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Track> GetTracksByAlbum(string albumTitle)
        {
            albumTitle = albumTitle is null ? throw new NullReferenceException() : albumTitle;

            using (DataContext db = new DataContext())
            {
                return db.Tracks.Include(x => x.Album).Include(x => x.SongWriter).AsEnumerable().Where(x => SearchHelpercs.Helper(albumTitle)
                    .Any(y => SearchHelpercs.Helper(x.Album.AlbumTitle).Contains(y))).ToList();
            }
        }

        public List<Track> GetTracksByGenre(string genres)
        {
            genres = genres is null ? throw new NullReferenceException() : genres;

            return unitOfWork.Set<Track>()
                .Where(x => genres.Contains(x.Genre.Name)).ToList();
        }

        public List<Track> GetTracksBySongWriter(string songWriterName)
        {
            songWriterName = songWriterName is null ? throw new NullReferenceException() : songWriterName;
            using (DataContext db = new DataContext())
            {
                return db.Tracks.Include(x => x.SongWriter).AsEnumerable().Where(x => SearchHelpercs.Helper(songWriterName)
                      .Any(y => SearchHelpercs.Helper(x.SongWriter.Name).Contains(y))).ToList();
            }
        }

        public List<Track> GetTracksByTitle(string trackTitle)
        {
            trackTitle = trackTitle is null ? throw new NullReferenceException() : trackTitle;

            using (DataContext db = new DataContext())
            {
                return db.Tracks.Include(x => x.SongWriter).Include(x => x.Album).AsEnumerable().Where(x => SearchHelpercs.Helper(trackTitle)
                    .Any(y => SearchHelpercs.Helper(x.SongTitle).Contains(y))).ToList();
            }
        }

        public void AddTrackToDB(Track track)
        {
            track = track is null ? throw new NullReferenceException() : track;
            unitOfWork.Set<Track>().Add(track);
        }
    }
}
