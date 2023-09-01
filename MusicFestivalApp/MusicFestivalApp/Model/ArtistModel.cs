using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFestivalApp.Model
{
    public class ArtistModel
    {

        [PrimaryKey, AutoIncrement]
        public int ArtistID { get; set; }

        public string ArtistName { get; set; }
        public string Country { get; set; }
        public string Performing { get; set; }
        public string genre { get; set; }

        // public DateTime dateTime { get; set; }
        public string   dateTime { get; set; }
        public string Avatar { get; set; }
    }
}
