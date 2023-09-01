using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MusicFestivalApp.Model;
using MusicFestivalApp.Services;
using MusicFestivalApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.ViewModel
{

    public partial class SponsorsListViewModel: ObservableObject
    {
        public static List<SponsorModel> SponsorListForSearch { get; private set; } = new List<SponsorModel>();


        public ObservableCollection<SponsorModel> SponsorsList { get; set; } = new ObservableCollection<SponsorModel>();
        private readonly ISponsorService _sponsorService;

        public SponsorsListViewModel(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }
        [ICommand]
        public async void GetSponsorsList()
        {

            var sponsorList = await _sponsorService.GetSponsorList();
            if (sponsorList.Count > 0)
            {

                SponsorsList.Clear();
                foreach (var sponsor in sponsorList)
                {
                    SponsorsList.Add(sponsor);
                }
                SponsorListForSearch.Clear();
                SponsorListForSearch.AddRange(sponsorList);
            }
        }

        [ICommand]

        public async void AddUpdateSponsor()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateSponsorList));

        }


        [ICommand]
        public async void DisplayActions(SponsorModel sponsorModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("SponsorListDetail", sponsorModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateSponsorList), navParam);

            }
            else if (response == "Delete")
            {
                var delResponse = await _sponsorService.DeleteSponsor(sponsorModel);
                if (delResponse > 0)
                {
                    GetSponsorsList();
                }
            }
        }


    }
}
