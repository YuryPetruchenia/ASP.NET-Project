﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Clietn.App_Start;
using Clietn.Models.ViewModels;
using Clietn.PresentationService.Interface;
using DomainLogic.DomainService.Interface;
using DomainLogic.Model;

namespace Clietn.PresentationService
{
    public class TrackPresentationService : ITrackPresentationService
    {
        private readonly ITrackDomainService trackDomainService;
        private AutoMapperConfig mappingProfile = new AutoMapperConfig();

        public TrackPresentationService(ITrackDomainService trackDomainService)
        {
            this.trackDomainService = trackDomainService;
        }

        public void AddTrackToDB(Track track)
        {
            trackDomainService.AddTrackToDB(track);
        }

        public List<TrackViewModel> GetTrack(string trackSearch)
        {
            var tracksByAlbum = trackDomainService.GetTracksByAlbum(trackSearch);
            var tracksBySongWriter = trackDomainService.GetTracksBySongWriter(trackSearch);
            var tracksByTitle = trackDomainService.GetTrackByTitle(trackSearch);
            var tracks = tracksByAlbum.Union(tracksBySongWriter).Union(tracksByTitle).ToList();
            var viewTracks = mappingProfile.Mapper.Map<List<Track>, List<TrackViewModel>>(tracks);
            return viewTracks;
        }

        public List<TrackViewModel> GetTracksByAlbum(string album)
        {
            var tracksByAlbum = trackDomainService.GetTracksByAlbum(album);
            var viewTracks = mappingProfile.Mapper.Map<List<Track>, List<TrackViewModel>>(tracksByAlbum);
            return viewTracks;
        }

        public List<TrackViewModel> GetTracksByAutor(string autor)
        {
            var tracksByAutor = trackDomainService.GetTracksBySongWriter(autor);
            var viewTracks = mappingProfile.Mapper.Map<List<Track>, List<TrackViewModel>>(tracksByAutor);
            return viewTracks;
        }

        public List<TrackViewModel> GetTracksByGenre(string genre)
        {
            var tracksByGenre = trackDomainService.GetTracksByGenre(genre);
            var viewTracks = mappingProfile.Mapper.Map<List<Track>, List<TrackViewModel>>(tracksByGenre);
            return viewTracks;
        }
    }
}