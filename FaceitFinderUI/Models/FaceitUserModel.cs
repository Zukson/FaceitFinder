using ApiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.Models
{
  public  class FaceitUserModel
    {
        public string player_id { get; set; }
        public string game_id { get; set; }

        public LifetimeModel lifetime { get; set; }
        public IList<SegmentModel> segments { get; set; }
    }
}
