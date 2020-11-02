namespace DomainLogic.DomainService
{
    using System.Collections.Generic;
    using DomainLogic.DomainService.Interface;
    using DomainLogic.Model;
    using DomainLogic.Repositories;

    public class GenreDomainService : IGenreDomainService
    {
        private readonly IGenreRepository genreRepository;

        public GenreDomainService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public void AddGenreToDB(Genre genre)
        {
            this.genreRepository.AddGenreToDB(genre);
        }

        public List<string> GetAllGenre()
        {
            return this.genreRepository.GetAllGenre();
        }

        public Genre GetGenreByName(string GenreName)
        {
            return this.genreRepository.GetGenreByName(GenreName);
        }
    }
}
