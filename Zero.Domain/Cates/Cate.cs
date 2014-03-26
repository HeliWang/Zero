using System;
using System.Collections;
using System.Collections.Generic;

namespace Zero.Domain.Cates
{
    public class Cate : BaseCate
    {
        public string Intro { get; set; }
        public List<Cate> children { get; set; }
    }
}
