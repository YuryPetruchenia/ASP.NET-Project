using DomainLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.DomainService.Interface
{
    public interface IGenreDomainService
    {
        List<string> GetAllGenre();

        void AddGenreToDB(Genre genre);

        Genre GetGenreByName(string GenreName);
    }
}
