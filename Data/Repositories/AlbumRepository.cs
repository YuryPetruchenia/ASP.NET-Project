using Data.Repositories.RepositoryService;
using DomainLogic.Model;
using DomainLogic.Repositories;
using DomainLogic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace Data.Repositories
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public AlbumRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public  List<Album> GetAlbumsByName(string AlbumTitle)
        {
            using (DataContext db = new DataContext())
            {
                return db.Albums.Include(x=>x.Genre).Include(x=>x.SongWriter).AsEnumerable().Where(x =>
                {
                    return SearchHelpercs.Helper(AlbumTitle).Any(y => SearchHelpercs.Helper(x.AlbumTitle).Contains(y));
                }).ToList();
            }
        }

        public List<Album> GetAlbumsBySongTitle(string SongTitle)
        {
            using (DataContext db = new DataContext())
            {
                var e = db.Tracks.Include(x=>x.Album).Include(x=>x.SongWriter).AsEnumerable().Where(x =>
                {
                    return SearchHelpercs.Helper(SongTitle).Any(y => SearchHelpercs.Helper(x.SongTitle).Contains(y));
                }).ToList();
                var c = e.Select(x => x.Album).ToList();
                return c;
            }
        }

        public  List<Album> GetAlbumsBySongWriter(string SongWriterName)
        {
            using (DataContext db = new DataContext())
            {
                return db.Tracks.Include(x=>x.SongWriter).AsEnumerable().Where(x =>
                {
                    return SearchHelpercs.Helper(SongWriterName).Any(y => SearchHelpercs.Helper(x.SongWriter.Name).Contains(y));
                }).ToList().Select(x => x.Album).ToList();
            }
        }

        public void AddAlbumToDB(Album album)
        {
            album = album is null ? throw new NullReferenceException() : album;
            unitOfWork.Set<Album>().Add(album);
            unitOfWork.SaveChanges();
        }

        public List<string> GetAllAlbum()
        {
            return unitOfWork.Set<Album>().Select(x => x.AlbumTitle).ToList();
        }

        Album IAlbumRepository.GetAlbumByName(string AlbumName)
        {
            return unitOfWork.Set<Album>().Where(x => x.AlbumTitle.Equals(AlbumName)).First();
        }
    }
}
