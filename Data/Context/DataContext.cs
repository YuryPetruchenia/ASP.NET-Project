using Data.Configurations.MusicConfigurations;
using Data.Context;
using DomainLogic.Model;
using DomainLogic.Model.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace Data
{
    public class DataContext : IdentityDbContext , IDataContext
    {
        public DataContext()
            : base("IMusic")
        {
        }

        public DbSet<SongWriter> SongWriters { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TrackConfigurations());
            modelBuilder.Configurations.Add(new AlbumConfigurations());
            modelBuilder.Configurations.Add(new SongWriterConfigurations()); 
            modelBuilder.Configurations.Add(new SubscriptionConfigurations());
        }

    }
}