using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.News
{
    public class NewsCate : BaseCate
    {
        public string Intro { get; set; }
        public List<NewsCate> children { get; set; }
    }
}
