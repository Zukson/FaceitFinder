using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.Models
{
 public   class SearchedFaceitUserModel
    {
        public string player_id { get; set; }
        public string game_id { get; set; }

        public LifetimeModel lifetime { get; set; }

        public string FavoriteMap { get; set; }
     
        public string MapImg { get; set; }
    }
}
