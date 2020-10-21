using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiLibrary.Models
{
    public class FaceitCsgoModel
    {
        public string player_id { get; set; }
        public string game_id { get; set; }
       
        public Lifetime lifetime { get; set; }
        public IList<Segment> segments { get; set; }
    }
}
