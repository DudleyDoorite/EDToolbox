using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    public class JSONObject
    {
        public List<JSONMemeber> Members { get; set; }
        public List<JSONObject> Objects { get; set; }
        public List<JSONArray> Arrays { get; set; }
    }
}
