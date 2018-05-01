using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Events
{
    public class Event_Materials
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public List<Raw> Raw { get; set; }
        public List<Manufactured> Manufactured { get; set; }
        public List<Encoded> Encoded { get; set; }
    }
}
