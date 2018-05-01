using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Events
{
    public class JournalEventArg : EventArgs
    {
        public JournalEvents EventType { get; set; }
        public string JournalEntry { get; set; }
    }
}
