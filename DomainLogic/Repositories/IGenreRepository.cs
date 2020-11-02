using DomainLogic.Model;
using System.Collections.Generic;

namespace DomainLogic.Repositories
{
    public interface IGenreRepository
    {
        List<string> GetAllGenre();
        void AddGenreToDB(Genre genre);

        Genre GetGenreByName(string GenreName);
    }
}
