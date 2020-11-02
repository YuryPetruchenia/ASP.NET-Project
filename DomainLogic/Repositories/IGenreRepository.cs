using System.Collections.Generic;
using DomainLogic.Model;

namespace DomainLogic.Repositories
{
    public interface IGenreRepository
    {
        List<string> GetAllGenre();

        void AddGenreToDB(Genre genre);

        Genre GetGenreByName(string genreName);
    }
}
