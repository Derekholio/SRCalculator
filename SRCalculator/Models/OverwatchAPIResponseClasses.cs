using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRCalculator.Models
{
    public class Sportsmanship
    {
        public double value { get; set; }
        public int rate { get; set; }
    }

    public class Shotcaller
    {
        public double value { get; set; }
        public int rate { get; set; }
    }

    public class Teammate
    {
        public double value { get; set; }
        public int rate { get; set; }
    }

    public class Endorsement
    {
        public Sportsmanship sportsmanship { get; set; }
        public Shotcaller shotcaller { get; set; }
        public Teammate teammate { get; set; }
        public int level { get; set; }
        public string frame { get; set; }
        public string icon { get; set; }
    }

    public class Quickplay
    {
        public int won { get; set; }
    }

    public class Competitive
    {
        public int won { get; set; }
        public int lost { get; set; }
        public int draw { get; set; }
        public int played { get; set; }
        public double win_rate { get; set; }
    }

    public class Games
    {
        public Quickplay quickplay { get; set; }
        public Competitive competitive { get; set; }
    }

    public class Playtime
    {
        public string quickplay { get; set; }
        public string competitive { get; set; }
    }

    public class Competitive2
    {
        public int rank { get; set; }
        public string rank_img { get; set; }
    }

    public class RootObject
    {
        
    }
}
