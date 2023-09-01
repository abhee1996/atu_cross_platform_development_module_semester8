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
    [QueryProperty(nameof(FestivalEventDetail), "FestivalEventDetail")]
    public partial class AddUpdateFestivalEventDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private FestivalEventsModel _festivalEventDetail = new FestivalEventsModel();
        private readonly IFestivalService _festivalService;

        public AddUpdateFestivalEventDetailViewModel(IFestivalService festivalService)
        {
            _festivalService = festivalService;
        }
      

        [ICommand]
        public async void AddUpdateFestival()
        {
            int response = -1;
            if (_festivalEventDetail.FestivalID > 0)
            {
                response = await _festivalService.UpdateFestival(FestivalEventDetail);

            }
            else
            {
                
                response = await _festivalService.AddFestival(new FestivalEventsModel
                {
                    Title = _festivalEventDetail.Title,
                    Description = _festivalEventDetail.Description,
                    StartDateTime = _festivalEventDetail.StartDateTime,
                    EndDateTime = _festivalEventDetail.EndDateTime,
                    BackgroundColor = _festivalEventDetail.BackgroundColor,

                });
            }
            if (response > 0)
            {
                await Shell.Current.DisplayAlert(" Festival Event Record Info", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("failed Adding Record", "Record Adding failed", "OK");

            }

        }


    }
}
