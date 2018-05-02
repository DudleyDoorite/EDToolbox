using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Events
{
    class Event_Bounty
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public List<Reward> Rewards { get; set; }
        public string Target { get; set; }
        public int TotalReward { get; set; }
        public string VictimFaction { get; set; }
    }
}
