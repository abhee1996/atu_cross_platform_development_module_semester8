using MusicFestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.ViewModel
{
    [QueryProperty(nameof(ArtistDetail), "ArtistDetailObj")]
    public  class ArtistDetailViewModel: BaseViewModel
    {
        private ArtistModel _artistDetails;
        public ArtistModel ArtistDetail
        {
            get=> _artistDetails;
            set => SetProperty(ref _artistDetails, value);
        }
    }
}
