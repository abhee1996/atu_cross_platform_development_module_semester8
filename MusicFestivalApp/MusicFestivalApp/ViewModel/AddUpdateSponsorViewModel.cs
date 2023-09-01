using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MusicFestivalApp.Model;
using MusicFestivalApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.ViewModel
{
    
    [QueryProperty(nameof(SponsorListDetail), "SponsorListDetail")]
   
    public partial class AddUpdateSponsorViewModel : ObservableObject
    {
        [ObservableProperty]
        private SponsorModel _sponsorListDetail = new SponsorModel();
        private readonly ISponsorService _sponsorsService;

        public AddUpdateSponsorViewModel(ISponsorService sponsorService)
        {
            _sponsorsService = sponsorService;
        }

        [ICommand]
        public async void AddUpdateSponsor()
        {
            int response = -1;
            if (_sponsorListDetail.SponsorID > 0)
            {
                response = await _sponsorsService.UpdateSponsor(SponsorListDetail);

            }
            else
            {

                response = await _sponsorsService.AddSponsor(new SponsorModel
                {
                    SponsorName = _sponsorListDetail.SponsorName,
                    Description = _sponsorListDetail.Description,



                });
            }
            if (response > 0)
            {
                await Shell.Current.DisplayAlert(" Artist Record Info", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("failed Adding Record", "Record Adding failed", "OK");

            }

        }


    }
}
