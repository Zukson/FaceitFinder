using System;
using System.Collections.Generic;
using System.Text;

namespace FaceitFinderUI.Models
{
    public class SegmentModel
    {
        public class Segment
        {
            public string label { get; set; }
            public string img_small { get; set; }
            public string img_regular { get; set; }
            public StatsModel stats { get; set; }
            public string type { get; set; }
            public string mode { get; set; }
        }
    }
}
