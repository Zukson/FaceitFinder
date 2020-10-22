using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Models
{
  public   class UserModel
    {
        public string player_id { get; set; }
        public string nickname { get; set; }
        public BitmapImage avatar { get; set; }
    }
}
