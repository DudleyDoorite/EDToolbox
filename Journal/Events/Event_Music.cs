using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Events
{
    public class Event_Music
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public string MusicTrack { get; set; }
    }
}
