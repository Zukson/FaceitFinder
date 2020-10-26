using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace FaceitFinderUI.Models
{
  public   class UserModel
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Avatar { get; set; }
      
        public string Playerid { get; set; }
    }
}
