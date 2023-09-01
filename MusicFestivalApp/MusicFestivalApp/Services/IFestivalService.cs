using MusicFestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.Services
{
    public interface IFestivalService
    {
        Task<List<FestivalEventsModel>> GetFestivalList();//(FestivalModel Festival);

        Task<int> AddFestival(FestivalEventsModel FestivalModel);
        Task<int> DeleteFestival(FestivalEventsModel FestivalModel);
        
        Task<int> UpdateFestival(FestivalEventsModel FestivalModel);
        Task<FestivalEventsModel> GetFestivalById(int id);
        Task<FestivalEventsModel> GetFestivalByName(string name);
    }
}
