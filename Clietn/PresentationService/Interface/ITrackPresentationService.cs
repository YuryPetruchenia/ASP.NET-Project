using System.Collections.Generic;
using Clietn.Models.ViewModels;
using DomainLogic.Model;

namespace Clietn.PresentationService.Interface
{
    public interface ITrackPresentationService
    {
        List<TrackViewModel> GetTrack(string trackTitle);

        List<TrackViewModel> GetTracksByGenre(string genre);

        List<TrackViewModel> GetTracksByAlbum(string album);

        List<TrackViewModel> GetTracksByAutor(string autor);

        void AddTrackToDB(Track track);
    }
}
