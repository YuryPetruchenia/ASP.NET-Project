using System.Collections.Generic;

namespace Clietn.Models.ViewModels
{
    public class SearchViewModel
    {
        public List<TrackViewModel> Songs { get; set; }

        public List<AutorViewModel> Autors { get; set; }

        public List<AlbumViewModel> Albums { get; set; }
    }
}