using DomainLogic.Model;
using System.Collections.Generic;

namespace DomainLogic.Repositories
{
    public interface ISongWriterRepository
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
