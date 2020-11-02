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
    public class SongWriterRepository : BaseRepository<SongWriter>, ISongWriterRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public SongWriterRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<SongWriter> GetSongWritersByAlbumTitle(string AlbumTitle)
        {
            using (DataContext db = new DataContext())
            {
               return db.Tracks.Include(x => x.Album).Include(x=>x.SongWriter).AsEnumerable().Where(x =>
                 {
                     return SearchHelpercs.Helper(AlbumTitle).Any(y => SearchHelpercs.Helper(x.Album.AlbumTitle).Contains(y));
                 }).ToList().Select(x=>x.SongWriter).ToList();
            }
        }

        public List<SongWriter> GetSongWritersByGenres(string Genres)
        {
            using (DataContext db = new DataContext())
            {
                return  db.Tracks.Where(x => Genres.Contains(x.Genre.Name)).Select(x=>x.SongWriter).ToList();
            }
        }

        public List<SongWriter> GetSongWritersByName(string SongWriterName)
        {
            using (DataContext db = new DataContext())
            {
                return  db.SongWriters.AsEnumerable().Where(x =>
                {
                    return SearchHelpercs.Helper(SongWriterName).Any(y => SearchHelpercs.Helper(x.Name).Contains(y));
                }).ToList();
            }
        }

        public List<SongWriter> GetSongWritersByTracksTitle(string SongTitle)
        {
            using (DataContext db = new DataContext())
            {
                return db.Tracks.Include(x=>x.SongWriter).AsEnumerable().Where(x =>
                {
                    return SearchHelpercs.Helper(SongTitle).Any(y => SearchHelpercs.Helper(x.SongTitle).Contains(y));
                }).ToList().Select(x => x.SongWriter).ToList();
            }
        }

        public void AddSongWriterToDB (SongWriter songWriter)
        {
            songWriter = songWriter is null ? throw new NullReferenceException() : songWriter;
            unitOfWork.Set<SongWriter>().Add(songWriter);
            unitOfWork.SaveChanges();
        }

        public List<string> GetAllSongWriter()
        {
            return unitOfWork.Set<SongWriter>().Select(x => x.Name).ToList();
        }

        public SongWriter GetSongWriterByName(string SongWriterName)
        {
            return unitOfWork.Set<SongWriter>().Where(x=>x.Name.Equals(SongWriterName)).First();
        }
    }
}
