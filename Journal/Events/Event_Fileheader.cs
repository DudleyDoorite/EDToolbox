using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Events
{
    public class Event_Fileheader
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public int part { get; set; }
        public string language { get; set; }
        public string gameversion { get; set; }
        public string build { get; set; }
    }
}
