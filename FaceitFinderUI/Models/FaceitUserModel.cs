using ApiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Models
{
  public  class FaceitUserModel
    {
        public string player_id { get; set; }
        public string game_id { get; set; }

        public LifetimeModel lifetime { get; set; }

        public string FavoriteMap  { get; set; }
        //public byte[] MapImg { get; set; }
        public string MapImg { get; set; }
         
    }
}
