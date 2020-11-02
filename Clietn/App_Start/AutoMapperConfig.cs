using AutoMapper;
using Clietn.Models.AdminViewModel;
using Clietn.Models.ViewModels;
using DomainLogic.Model;

namespace Clietn.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public IMapper Mapper { get; set; }

#pragma warning disable SA1201 // Elements should appear in the correct order
        public AutoMapperConfig()
#pragma warning restore SA1201 // Elements should appear in the correct order
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Track, TrackViewModel>()
                    .ForMember("SongWriter", opt => opt.MapFrom(c => c.SongWriter.Name));
                cfg.CreateMap<Genre, GenreViewModel>()
                   .ForMember("GenreName", opt => opt.MapFrom(c => c.Name));
                cfg.CreateMap<Album, AlbumViewModel>()
                  .ForMember("AlbumSongWriter", opt => opt.MapFrom(c => c.SongWriter.Name))
                    .ForMember("AlbumName", opt => opt.MapFrom(c => c.AlbumTitle));
                cfg.CreateMap<SongWriter, AutorViewModel>()
                  .ForMember("AutorId", opt => opt.MapFrom(c => c.SongWriterId))
                    .ForMember("AutorName", opt => opt.MapFrom(c => c.Name));
                cfg.CreateMap<Track, TrackAdminModel>()
                   .ForMember("SongWriter", opt => opt.MapFrom(c => c.SongWriter.Name))
                   .ForMember("SongTitle", opt => opt.MapFrom(c => c.SongTitle))
                   .ForMember("Genre", opt => opt.MapFrom(c => c.Genre.Name))
                   .ForMember("Album", opt => opt.MapFrom(c => c.Album.AlbumTitle));
            });
            Mapper = config.CreateMapper();
        }
    }
}
