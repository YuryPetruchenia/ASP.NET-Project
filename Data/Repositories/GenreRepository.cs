using DomainLogic.Model;
using DomainLogic.Repositories;
using DomainLogic.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public GenreRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<string> GetAllGenre()
        {
            return unitOfWork.Set<Genre>().Select(x => x.Name).ToList();
        }

        public void AddGenreToDB(Genre genre)
        {
            genre = genre is null ? throw new NullReferenceException() : genre;
            unitOfWork.Set<Genre>().Add(genre);
            unitOfWork.SaveChanges();
        }

        public Genre GetGenreByName(string GenreName)
        {
            return unitOfWork.Set<Genre>().Where(x => x.Name.Equals(GenreName)).First();
        }
    }  
}
