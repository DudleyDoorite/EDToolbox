using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Events
{
    public partial class Reward
    {
        [JsonProperty("Faction")]
        public string Faction { get; set; }

        [JsonProperty("Reward")]
        public long RewardReward { get; set; }
    }

}
