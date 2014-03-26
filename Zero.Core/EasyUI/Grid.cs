using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.EasyUI
{
    public class Grid<T>
    {
        public long total
        {
            get;
            set;
        }

        public List<T> rows
        {
            get;
            set;
        }
    }
}
