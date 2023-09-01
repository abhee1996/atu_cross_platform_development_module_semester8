//using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    public partial class ArtistListViewModel : ObservableObject
    {
        public static List<ArtistModel> ArtistListForSearch { get; private set; } = new List<ArtistModel>();

        public ObservableCollection<ArtistModel> ArtistsList { get; set; } = new ObservableCollection<ArtistModel>();
        private readonly IArtistService _artistService;

        public ArtistListViewModel(IArtistService artistService)
        {
            _artistService = artistService;
            // AddAllartistEventList();
        }
        [ICommand]
        public async void GetArtistList()
        {
          
            var artistList = await _artistService.GetArtistList();
            if (artistList.Count > 0)
            {

                ArtistsList.Clear();
                foreach (var artist in artistList)
                {
                    ArtistsList.Add(artist);
                }
                ArtistListForSearch.Clear();
                ArtistListForSearch.AddRange(artistList);
            }


        }

        [ICommand]

        public async void AddUpdateArtist() 
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateArtistList));

        }


        [ICommand]
        public async void DisplayActions(ArtistModel artistModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("ArtistListDetail", artistModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateArtistList), navParam);

            }
            else if (response == "Delete")
            {
                var delResponse = await _artistService.DeleteArtist(artistModel);
                if (delResponse > 0)
                {
                    GetArtistList();
                }
            }
        }

    }
}
