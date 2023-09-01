using MusicFestivalApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.Services
{
   public class ArtistService : IArtistService
    {
        private SQLiteAsyncConnection _dbConnection;
        public ArtistService()
        {
            SetUpdb();
        }
        private async void SetUpdb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Festival.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<ArtistModel>();

            }
        }
        public async Task<int> AddArtist(ArtistModel artistModel)
        {
            return await _dbConnection.InsertAsync(artistModel);
        }
        public async Task<List<ArtistModel>> GetArtistList()//(artistModel artist)
        {
            var artistlist = await _dbConnection.Table<ArtistModel>().ToListAsync();
            return artistlist;
        }

        public Task<int> UpdateArtist(ArtistModel artistModel)
        {
            return _dbConnection.UpdateAsync(artistModel);
        }
        public Task<int> DeleteArtist(ArtistModel artistModel)
        {
            return _dbConnection.DeleteAsync(artistModel);
        }

        public Task<ArtistModel> GetArtistById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistModel> GetArtistByName(string name)
        {
            throw new NotImplementedException();
        }


    }
}
