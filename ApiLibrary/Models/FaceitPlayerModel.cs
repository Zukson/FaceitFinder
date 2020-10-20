using ApiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ApiLibrary.Models
{

    public class FaceitPlayerModel
    {
        public string player_id { get; set; }
        public string nickname { get; set; }
        public string avatar { get; set; }
    }
   

}
