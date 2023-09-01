using MusicFestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.Services
{
    public interface IArtistService
    {
        Task<List<ArtistModel>> GetArtistList();//(ArtistModel Artist);

        Task<int> AddArtist(ArtistModel ArtistModel);
        Task<int> DeleteArtist(ArtistModel ArtistModel);

        Task<int> UpdateArtist(ArtistModel ArtistModel);
        Task<ArtistModel> GetArtistById(int id);
        Task<ArtistModel> GetArtistByName(string name);
    }
}
