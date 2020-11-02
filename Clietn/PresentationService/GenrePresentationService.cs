using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Clietn.App_Start;
using Clietn.Models.ViewModels;
using Clietn.PresentationService.Interface;
using DomainLogic.DomainService.Interface;
using DomainLogic.Model;

namespace Clietn.PresentationService
{
    public class GenrePresentationService : IGenrePresentationService
    {
        private readonly IGenreDomainService genreDomainService;
        private readonly AutoMapperConfig mappingProfile = new AutoMapperConfig();

        public GenrePresentationService(IGenreDomainService genreDomainService)
        {
            this.genreDomainService = genreDomainService;
        }

        public void AddGenreToDB(Genre genre)
        {
            genreDomainService.AddGenreToDB(genre);
        }

        public List<string> GetAllGenre()
        {
            List<string> genres = genreDomainService.GetAllGenre();
            return genres;
        }

        public Genre GetGenreByName(string genreName)
        {
            return genreDomainService.GetGenreByName(genreName);
        }
    }
}