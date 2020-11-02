using System.Collections.Generic;
using DomainLogic.Model;

namespace DomainLogic.DomainService.Interface
{
    public interface IGenreDomainService
    {
        List<string> GetAllGenre();

        void AddGenreToDB(Genre genre);

        Genre GetGenreByName(string genreName);
    }
}
