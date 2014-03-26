using System;
using System.Collections;
using System.Collections.Generic;

namespace Zero.Domain.Cates
{
    public class EasyTree
    {
        public string id { get; set; }

        public string text { get; set; }

        public List<EasyTree> children { get; set; }
    }
}
