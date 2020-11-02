using Data.Repositories.RepositoryService;
using DomainLogic.Model;
using DomainLogic.Repositories;
using DomainLogic.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class TrackRepository : BaseRepository<Track>, ITrackRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public TrackRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Track> GetTracksByAlbum(string AlbumTitle)
        {
            AlbumTitle = AlbumTitle is null ? throw new NullReferenceException() : AlbumTitle;

            using (DataContext db = new DataContext())
            {
                return db.Tracks.Include(x => x.Album).Include(x => x.SongWriter).AsEnumerable().Where(x => SearchHelpercs.Helper(AlbumTitle)
                    .Any(y => SearchHelpercs.Helper(x.Album.AlbumTitle).Contains(y))).ToList();
            }
        }

        public List<Track> GetTracksByGenre(string Genres)
        {
            Genres = Genres is null ? throw new NullReferenceException() : Genres;

            return unitOfWork.Set<Track>()
                .Where(x => Genres.Contains(x.Genre.Name)).ToList();
        }

        public List<Track> GetTracksBySongWriter(string SongWriterName)
        {
            SongWriterName = SongWriterName is null ? throw new NullReferenceException() : SongWriterName;
            using (DataContext db = new DataContext())
            {
                return db.Tracks.Include(x => x.SongWriter).AsEnumerable().Where(x => SearchHelpercs.Helper(SongWriterName)
                      .Any(y => SearchHelpercs.Helper(x.SongWriter.Name).Contains(y))).ToList();
            }
        }

        public List<Track> GetTracksByTitle(string TrackTitle)
        {
            TrackTitle = TrackTitle is null ? throw new NullReferenceException() : TrackTitle;

            using (DataContext db = new DataContext())
            {
                return db.Tracks.Include(x => x.SongWriter).Include(x => x.Album).AsEnumerable().Where(x => SearchHelpercs.Helper(TrackTitle)
                    .Any(y => SearchHelpercs.Helper(x.SongTitle).Contains(y))).ToList();
            }
        }

        public void AddTrackToDB(Track track)
        {
            track = track is null ? throw new NullReferenceException() : track;
            unitOfWork.Set<Track>().Add(track);
            unitOfWork.SaveChanges();
        }
    }
}
