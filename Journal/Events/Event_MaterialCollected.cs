using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Events
{
    class Event_MaterialCollected
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }
}
