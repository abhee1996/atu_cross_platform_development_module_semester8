using MusicFestivalApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.Services
{
   public class SponsorService : ISponsorService
    {
        private SQLiteAsyncConnection _dbConnection;
        public SponsorService()
        {
            SetUpdb();
        }
        private async void SetUpdb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Festival.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<SponsorModel>();

            }
        }
        public async Task<int> AddSponsor(SponsorModel sponsorModel)
        {
            return await _dbConnection.InsertAsync(sponsorModel);
        }
        public async Task<List<SponsorModel>> GetSponsorList()//(SponsorModel Sponsor)
        {
            var artistlist = await _dbConnection.Table<SponsorModel>().ToListAsync();
            return artistlist;
        }

        public Task<int> UpdateSponsor(SponsorModel sponsorModel)
        {
            return _dbConnection.UpdateAsync(sponsorModel);
        }
        public Task<int> DeleteSponsor(SponsorModel sponsorModel)
        {
            return _dbConnection.DeleteAsync(sponsorModel);
        }

        public Task<SponsorModel> GetSponsorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SponsorModel> GetSponsorByName(string name)
        {
            throw new NotImplementedException();
        }


    }
}
