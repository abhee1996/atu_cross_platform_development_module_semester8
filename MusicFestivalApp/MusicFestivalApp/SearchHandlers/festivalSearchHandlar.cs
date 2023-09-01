using MusicFestivalApp.Model;
using MusicFestivalApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.SearchHandlers
{
    public class festivalSearchHandlar : SearchHandler
    {

        public IList<FestivalEventsModel> FestivalEvent { get; set; }

        public string NavigationRoute { get; set; }
        public Type NavigationType { get; set; }
        //public IList<SponsorsModel> sponsor { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }


            else
            {
              
                var itmsrc = FestivalEvent.Where(fs => fs.Title.ToLower().Contains(newValue.ToLower())).ToList<FestivalEventsModel>();

                
                ItemsSource = itmsrc;//[0].Title;
                //Artists.Where(artist => artist.ArtistName.ToLower().Contains(newValue.ToLower())).ToList<ArtistModel>();


                //ItemsSource = Sponsors.Where(fEvent => fEvent.SponsorName.ToLower().Contains(newValue.ToLower())).ToList();
            }
          
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            var navParam = new Dictionary<string, object>();
            navParam.Add("FestivalEventDetail", item);
            if (!string.IsNullOrWhiteSpace(NavigationRoute))
            {
                await Shell.Current.GoToAsync(NavigationRoute, navParam);
            }
            //else if(NavigationType != null)
            //{
            //    await Shell.Current.GoToAsync(GetNavigationPageName(), navParam);
            //}
        }
        //protected override async void OnItemSelected(object item)
        //{
        //    base.OnItemSelected(item);
        //    var navParams = new Dictionary<string, object>();

        //    navParams.Add("ArtistListDetail", item);

        //    if (!string.IsNullOrWhiteSpace(NavigationRoute))
        //    {
        //        await Shell.Current.GoToAsync(NavigationRoute, navParams);
        //       // await Shell.Current.GoToAsync(nameof(AddUpdateArtistList), navParams);

        //    }
        //    //else if(NavigationType != null)
        //    //{
        //    //    await Shell.Current.GoToAsync(GetNavigationPageName(), navParams);
        //    //}
        //}


        //string GetNavigationPageName()
        //{ 
        //    return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(NavigationType)).Key;
        //}
    }
}

