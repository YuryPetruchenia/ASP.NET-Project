using System.Collections.Generic;
using DomainLogic.Model;

namespace Clietn.PresentationService.Interface
{
    public interface IGenrePresentationService
    {
        List<string> GetAllGenre();

        void AddGenreToDB(Genre genre);

        Genre GetGenreByName(string genreName);
    }
}
