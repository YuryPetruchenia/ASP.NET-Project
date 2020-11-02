namespace Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using DomainLogic.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            Genre numetal = new Genre() { Name = "Nu-Metal" };
            Genre metal = new Genre() { Name = "Metal" };
            Genre rock = new Genre() { Name = "Rock" };
            Genre punkRock = new Genre() { Name = "Punk-Rock" };
            Genre rapMetal = new Genre() { Name = "Rap-Metal" };

            SongWriter serj = new SongWriter()
            {
                Name = "Serj Tankian",
                Age = 53,
                Genres = new List<Genre>() { metal, numetal, rapMetal },
                Info = string.Empty,
            };

            SongWriter corey = new SongWriter()
            {
                Name = "Corey Todd Taylor",
                Age = 46,
                Genres = new List<Genre>() { metal, numetal },
                Info = string.Empty,
            };

            SongWriter egorLetov = new SongWriter()
            {
                Name = "Егор Летов",
                Age = 43,
                Genres = new List<Genre>() { rock, punkRock },
                Info = "All going according to plan",
            };

            Album toxicity = new Album()
            {
                AlbumTitle = "Toxicity",
                Genre = rapMetal,
                SongWriter = serj,
                Info = "Toxicity",
            };

            Album grayChapter = new Album()
            {
                AlbumTitle = ".5: The Gray Chapter",
                Genre = numetal,
                SongWriter = corey,
                Info = ".5: The Gray Chapter",
            };

            Album vseidetpoplanu = new Album()
            {
                AlbumTitle = "Всё идет по плану",
                Genre = punkRock,
                SongWriter = egorLetov,
                Info = "Всё идет по плану",
            };
            Track system = new Track() { SongTitle = "Система", SongWriter = egorLetov, Genre = punkRock, Album = vseidetpoplanu };
            Track killpop = new Track() { SongTitle = "Killpop", SongWriter = corey, Genre = numetal, Album = grayChapter };
            Track atva = new Track() { SongTitle = "Atva", SongWriter = serj, Genre = numetal, Album = toxicity };

            context.Set<Genre>().Add(numetal);
            context.Set<Genre>().Add(metal);
            context.Set<Genre>().Add(rock);
            context.Set<Genre>().Add(punkRock);
            context.Set<Genre>().Add(rapMetal);

            context.Set<SongWriter>().Add(serj);
            context.Set<SongWriter>().Add(corey);
            context.Set<SongWriter>().Add(egorLetov);

            context.Set<Album>().Add(toxicity);
            context.Set<Album>().Add(grayChapter);
            context.Set<Album>().Add(vseidetpoplanu);

            context.Set<Track>().Add(killpop);
            context.Set<Track>().Add(system);
            context.Set<Track>().Add(atva);
        }
    }
}
