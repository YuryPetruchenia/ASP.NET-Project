using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Clietn.PresentationService;
using Clietn.PresentationService.Interface;
using Data;
using Data.Context;
using Data.Repositories;
using Data.UnitOfWork;
using DomainLogic.DomainService;
using DomainLogic.DomainService.Interface;
using DomainLogic.Repositories;
using DomainLogic.UnitOfWork;

namespace Clietn.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<TrackDomainService>().As<ITrackDomainService>();
            builder.RegisterType<SongWriterDomainService>().As<ISongWriterDomainService>();
            builder.RegisterType<GenreDomainService>().As<IGenreDomainService>();
            builder.RegisterType<AlbumDomainService>().As<IAlbumDomainService>();

            builder.RegisterType<AlbumRepository>().As<IAlbumRepository>();
            builder.RegisterType<TrackRepository>().As<ITrackRepository>();
            builder.RegisterType<SongWriterRepository>().As<ISongWriterRepository>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();

            builder.RegisterType<TrackPresentationService>().As<ITrackPresentationService>();
            builder.RegisterType<SongWriterPresentationService>().As<ISongWriterPresentationService>();
            builder.RegisterType<AlbumPresentationService>().As<IAlbumPresentationService>();
            builder.RegisterType<GenrePresentationService>().As<IGenrePresentationService>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DataContext>().As<IDataContext>().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}