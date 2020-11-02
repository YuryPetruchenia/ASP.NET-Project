using System.Collections.Generic;
using DomainLogic.Model;

namespace DomainLogic.DomainService.Interface
{
    public interface ISongWriterDomainService
    {
       List<SongWriter> GetSongWritersByName(string songWriterName);

       List<SongWriter> GetSongWritersByTracksTitle(string songTitle);

       List<SongWriter> GetSongWritersByAlbumTitle(string albumTitle);

       List<SongWriter> GetSongWritersByGenres(string genres);

       void AddSongWriterToDB(SongWriter songWriter);

       List<string> GetAllSongWriter();

       SongWriter GetSongWriterByName(string songWriterName);
    }
}
