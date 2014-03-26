using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Category.Model
{
    public class EasyTreeInfo
    {
        public string id { get; set; }

        public string text { get; set; }

        public List<EasyTreeInfo> children { get; set; }
    }
}
