using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiLibrary.Models
{
    [DataContract]
    public class Lifetime
    {
        [DataMember(Name = "Average Headshots %")]
        public string AverageHeadshots { get; set; }
        // [JsonPropertyName("Average K/D Ratio")]
        [DataMember(Name = "Average K/D Ratio")]
        public string Kd { get; set; }
        [DataMember(Name = "Longest Win Streak")]
    
      
        public string Longest_Win_Streak { get; set; }  
       
            [DataMember(Name = "Matches")]
        public string Matches { get; set; }
        [DataMember(Name = "Win Rate %")]
        public string WR { get; set; }
      [DataMember(Name = "Wins")] 
        public string Wins { get; set; }
      
    }
}
