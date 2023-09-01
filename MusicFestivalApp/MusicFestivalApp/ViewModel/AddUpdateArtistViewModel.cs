using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MusicFestivalApp.Model;
using MusicFestivalApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Provider.MediaStore.Audio;

namespace MusicFestivalApp.ViewModel
{
   // [QueryProperty(nameof(FestivalEventDetail), "FestivalEventDetail")] ArtistDetail
        [QueryProperty(nameof(ArtistListDetail), "ArtistListDetail")] 
    public partial class AddUpdateArtistViewModel : ObservableObject
    {
        [ObservableProperty]
        private ArtistModel _artistListDetail = new ArtistModel();
        private readonly IArtistService _artistsService;

        public AddUpdateArtistViewModel(IArtistService artistsService)
        {
            _artistsService = artistsService;
        }

        [ICommand]
        public async void AddUpdateArtist()
        {
            int response = -1;
            if (_artistListDetail.ArtistID > 0)
            {
                response = await _artistsService.UpdateArtist(ArtistListDetail);

            }
            else
            {

                response = await _artistsService.AddArtist(new ArtistModel
                {
                    ArtistName = _artistListDetail.ArtistName,
                    Country = _artistListDetail.Country,                    
                    Performing = _artistListDetail.Performing,
                    genre = _artistListDetail.genre,
                    dateTime = _artistListDetail.dateTime,
                    Avatar = _artistListDetail.Avatar,

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
