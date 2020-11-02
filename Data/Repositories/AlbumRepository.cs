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
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public AlbumRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Album> GetAlbumsByName(string albumTitle)
        {
            using (DataContext db = new DataContext())
            {
                return db.Albums.AsEnumerable().Where(x =>
                {
                    return SearchHelpercs.Helper(albumTitle).Any(y => SearchHelpercs.Helper(x.AlbumTitle).Contains(y));
                }).ToList();
            }
        }

        public List<Album> GetAlbumsBySongTitle(string songTitle)
        {
            using (DataContext db = new DataContext())
            {
                return db.Tracks.AsEnumerable().Where(x =>
                {
                    return SearchHelpercs.Helper(songTitle).Any(y => SearchHelpercs.Helper(x.SongTitle).Contains(y));
                }).ToList().Select(x => x.Album).ToList();
            }
        }

        public List<Album> GetAlbumsBySongWriter(string songWriterName)
        {
            using (DataContext db = new DataContext())
            {
                return db.Tracks.Include(x => x.SongWriter).AsEnumerable().Where(x =>
                {
                    return SearchHelpercs.Helper(songWriterName).Any(y => SearchHelpercs.Helper(x.SongWriter.Name).Contains(y));
                }).ToList().Select(x => x.Album).ToList();
            }
        }

        public void AddAlbumToDB(Album album)
        {
            album = album is null ? throw new NullReferenceException() : album;
            unitOfWork.Set<Album>().Add(album);
        }

        public List<string> GetAllAlbum()
        {
            return unitOfWork.Set<Album>().Select(x => x.AlbumTitle).ToList();
        }

        Album IAlbumRepository.GetAlbumByName(string albumName)
        {
            return unitOfWork.Set<Album>().Where(x => x.AlbumTitle.Equals(albumName)).First();
        }
    }
}
