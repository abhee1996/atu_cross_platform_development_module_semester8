using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Input;
using MusicFestivalApp.Model;
using MusicFestivalApp.Services;
using MusicFestivalApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.ViewModel
{
    public partial class FestivalListViewModel : ObservableObject
    {

        //   public ObservableCollection<DaysModel> FestivalEventWeekDays { get; set; } = new ObservableCollection<DaysModel>();
        public static List<FestivalEventsModel> FestivalEventForSearch { get; private set; } = new List<FestivalEventsModel>();

        public ObservableCollection<FestivalEventsModel> GeilFestivalEvents { get; set; } = new ObservableCollection<FestivalEventsModel>();
        private readonly IFestivalService _festivalService;

        public FestivalListViewModel(IFestivalService festivalService)
        {
            _festivalService =   festivalService;
           // AddAllFestivalEventList();
        }
        [ICommand]
        public async void GetFestivalList()
        {
          
            var festivalList = await _festivalService.GetFestivalList();

            if (festivalList.Count > 0)
            {

                GeilFestivalEvents.Clear();
                foreach (var festival in festivalList)
                {
                    GeilFestivalEvents.Add(festival);
                  
                }
            }


        }

         [ICommand]
        public async void AddUpdateFestival()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateFestivalEventDetail));

        }


        [ICommand]
        public async void DisplayActions(FestivalEventsModel festivalModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("FestivalEventDetail", festivalModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateFestivalEventDetail), navParam);

            }
            else if (response == "Delete")
            {
                var delResponse = await _festivalService.DeleteFestival(festivalModel);
                if (delResponse > 0)
                {
                    GetFestivalList();
                }
            }
        }







    }
}






//private List<FestivalEventsModel> _allFestivalEvents = new List<FestivalEventsModel>();

//[ObservableProperty]
//private DateTime _currentDateTime = DateTime.Now;
//[ObservableProperty]
//private bool _isBusy;

//private void AddAllFestivalEventList()
//{
//    var events = new List<FestivalEventsModel>();
//    events.Add(new FestivalEventsModel   
//    {
//        Title = "Ruth Music Performance",
//        Description = "Ruth new Songs Music Performance",
//        //StartDateTime = DateTime.Now,
//        StartDateTime = new DateTime(2023,08,11),
//        EndDateTime = DateTime.Now.AddHours(5),
//        //StartDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(17,0,0)),
//        //EndDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(18, 0, 0)),
//        //BackgroundColor = Color.FromArgb("#68c6da"),

//    });
//    events.Add(new FestivalEventsModel
//    {
//        Title = "Michael jackson Music and Dance Performance",
//        Description = "Michael jackson new Songs and Dance Performance",
//        StartDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(13, 0, 0)),
//        EndDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(14, 0, 0)),
//      //  BackgroundColor = Color.FromArgb("#e87a3d")
//    });
//    events.Add(new FestivalEventsModel
//    {
//        Title = "Atif Aslam Song Performance",
//        Description = "Atif Aslam new Songs Performance",
//        StartDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(15,0,0)),
//        EndDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(16, 0, 0)),
//      //  BackgroundColor = Color.FromArgb("#9a6ead")
//    });
//    events.Add(new FestivalEventsModel
//    {
//        Title = "Madona Music Performance",
//        Description = "Madona new Songs Music Performance",
//      StartDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(17,0,0)),
//        EndDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(18, 0, 0)),
//       // BackgroundColor = Color.FromArgb("#eaab43")
//    });

//    _allFestivalEvents.AddRange(events);
//    BindDataToFestivalEventList();
//}
//public void BindDataToFestivalEventList()
//{
//    IsBusy = true;
//    Task.Run(async  () =>
//    {
//        await Task.Delay(500);
//        var filterFestivalEventList = _allFestivalEvents.Where(festival => festival.StartDateTime.Date == CurrentDateTime.Date).ToList();
//        App.Current.Dispatcher.Dispatch(() =>
//        {
//            GeilFestivalEvents.Clear();
//            foreach (var festival in filterFestivalEventList)
//            {
//                GeilFestivalEvents.Add(festival);
//            }
//            GetWeekDaysInfo();
//            IsBusy = false;
//        });
//    });

//}
//private void GetWeekDaysInfo()
//{
//    DateTime startDateofWeek = CurrentDateTime.AddDays((int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
//        (int)CurrentDateTime.DayOfWeek);
//    FestivalEventWeekDays.Clear();
//    for(int i = 0; i < 7; i++)
//    {
//        var recordToAddWeek = new DaysModel
//        {   

//            DayName = DayOfWeekChar((int)startDateofWeek.DayOfWeek),
//            DateTime = startDateofWeek.Date,
//            IsSelected = startDateofWeek.Date == CurrentDateTime.Date,
//        };
//        FestivalEventWeekDays.Add(recordToAddWeek);
//        startDateofWeek = startDateofWeek.AddDays(1);
//    }
//}

//private char DayOfWeekChar(int dayofWeek)
//{
//    switch (dayofWeek)
//    {
//        case 0:
//            return 'S';
//        case 1:
//            return 'M';
//        case 2:
//            return 'T';
//        case 3:
//            return 'W';
//        case 4:
//            return 'T';
//        case 5:
//            return 'F';
//        case 6:
//            return 'S';
//    }
//    return ' ';
//}

//[RelayCommand]
//public void WeekDaysSelected(DaysModel item)
//{
//    Console.WriteLine("item", item);
//    FestivalEventWeekDays.ToList().ForEach(f => f.IsSelected = false);
//    item.IsSelected = true;
//    CurrentDateTime = item.DateTime;
//    BindDataToFestivalEventList();
//}