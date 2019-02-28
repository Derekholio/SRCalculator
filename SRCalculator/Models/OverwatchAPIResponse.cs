using Newtonsoft.Json;

namespace SRCalculator.Models
{
    public class OverwatchAPIResponse
    {
        public string username { get; set; }
        public int level { get; set; }
        public string portrait { get; set; }
        public Endorsement endorsement { get; set; }
        [JsonProperty("private")]
        public bool isPrivate { get; set; }
        public Games games { get; set; }
        public Playtime playtime { get; set; }
        public Competitive2 competitive { get; set; }
        public string levelFrame { get; set; }
        public string star { get; set; }
    }
}
