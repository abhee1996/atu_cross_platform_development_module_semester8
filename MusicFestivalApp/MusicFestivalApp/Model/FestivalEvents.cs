using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.Model
{
    //[Table("")]
    public class FestivalEventsModel


    {
        [PrimaryKey,AutoIncrement]
        public int FestivalID { get; set; }

       
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string BackgroundColor { get; set; }
        // public Color BackgroundColor { get; set; }
        //public ArtistModel ArtistName{ get; set; }





    }
}
