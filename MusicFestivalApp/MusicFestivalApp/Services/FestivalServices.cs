using MusicFestivalApp.Model;
using MusicFestivalApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.Services
{
    public class FestivalServices : IFestivalService
    {
        private SQLiteAsyncConnection _dbConnection;
        public FestivalServices()
        {
            SetUpdb();
        }
        private async void SetUpdb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Festival.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<FestivalEventsModel>();

            }
        }
        public async Task<int> AddFestival(FestivalEventsModel festivalModel)
        {
           return  await _dbConnection.InsertAsync(festivalModel);
        }
        public async Task<List<FestivalEventsModel>> GetFestivalList()//(FestivalModel Festival)
        {
            var festivallist = await _dbConnection.Table<FestivalEventsModel>().ToListAsync();
            return festivallist;
        }

        public Task<int> UpdateFestival(FestivalEventsModel festivalModel)
        {
            return _dbConnection.UpdateAsync(festivalModel);
        }
        public Task<int> DeleteFestival(FestivalEventsModel festivalModel)
        {
            return  _dbConnection.DeleteAsync(festivalModel);
        }

        public Task<FestivalEventsModel> GetFestivalById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FestivalEventsModel> GetFestivalByName(string name)
        {
            throw new NotImplementedException();
        }

        
    }
}
