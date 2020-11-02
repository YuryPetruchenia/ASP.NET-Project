using System.Collections.Generic;
using Clietn.Models.ViewModels;
using DomainLogic.Model;

namespace Clietn.PresentationService.Interface
{
    public interface ISongWriterPresentationService
    {
        List<AutorViewModel> GetSongWriter(string songWriterName);

        List<SongWriter> GetSongWriterByGenre(string genre);

        void AddSongWriterToDB(SongWriter songWriter);

        List<string> GetAllSongWriters();

        SongWriter GetSongWriterByName(string songWriterName);
    }
}
