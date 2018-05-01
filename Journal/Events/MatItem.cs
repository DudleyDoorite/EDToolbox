using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Events
{
    class MatItem
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public MaterialTypes Type { get; set; }
        public int Count { get; set; }
    }
}
