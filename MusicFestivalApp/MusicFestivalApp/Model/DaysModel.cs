using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.Model
{
    public partial class DaysModel :ObservableObject
    {
        public char DayName { get; set; }
        public DateTime DateTime { get; set; }
        [ObservableProperty]
        private bool _isSelected;
    }
}
