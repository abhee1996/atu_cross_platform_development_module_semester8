using MusicFestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.Services
{
    public interface ISponsorService
    {
        Task<List<SponsorModel>> GetSponsorList();//(SponsorModel Sponsor);

        Task<int> AddSponsor(SponsorModel sponsorModel);
        Task<int> DeleteSponsor(SponsorModel sponsorModel);

        Task<int> UpdateSponsor(SponsorModel sponsorModel);
        Task<SponsorModel> GetSponsorById(int id);
        Task<SponsorModel> GetSponsorByName(string name);
    }
}
