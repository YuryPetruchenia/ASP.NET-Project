namespace Data.Migrations
{
    using DomainLogic.Model;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            #region Add Genre
            Genre nuMetal = new Genre() { Name = "Nu-Metal" };
            Genre metal = new Genre() { Name = "Metal" };
            Genre rock = new Genre() { Name = "Rock" };
            Genre punkRock = new Genre() { Name = "Punk-Rock" };
            Genre rapMetal = new Genre() { Name = "Rap-Metal"};
            #endregion

            #region Add SongWriter
            SongWriter serj = new SongWriter()
            {
                Name = "Serj Tankian",
                Age = 53,
                Genres = new List<Genre>() { metal, nuMetal, rapMetal },
                Info = ""
            };

            SongWriter corey = new SongWriter()
            { 
                Name = "Corey Todd Taylor",
                Age = 46,
                Genres = new List<Genre>() { metal, nuMetal },
                Info = "" 
            };

            SongWriter egorLetov = new SongWriter() 
            {
                Name = "Егор Летов",
                Age = 43,
                Genres = new List<Genre>() { rock, punkRock },
                Info = "All going according to plan" 
            };
            #endregion

            #region Add Album
            Album toxicity = new Album()
            {
                AlbumTitle = "Toxicity",
                Genre = rapMetal,
                SongWriter = serj,
                Info = "Toxicity"
            };

            Album grayChapter = new Album()
            {
                AlbumTitle = ".5: The Gray Chapter",
                Genre = nuMetal,
                SongWriter = corey,
                Info = ".5: The Gray Chapter"
            };

            Album vseidetpoplanu = new Album()
            {
                AlbumTitle = "Всё идет по плану",
                Genre = punkRock,
                SongWriter = egorLetov,
                Info = "Всё идет по плану"
            };
            #endregion

            #region Add Track
            Track system = new Track() { SongTitle = "Система", SongWriter = egorLetov, Genre = punkRock, Album = vseidetpoplanu };
            Track killpop = new Track() { SongTitle = "Killpop", SongWriter = corey, Genre = nuMetal, Album = grayChapter };            
            Track atva = new Track() { SongTitle = "Atva", SongWriter = serj, Genre = nuMetal, Album = toxicity };
            #endregion

            context.Set<Genre>().Add(nuMetal);
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
