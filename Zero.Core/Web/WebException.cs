using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zero.Core.Web
{
    public class WebException : Exception
    {
        public WebException()
            : base()
        {
            Exception ex = new Exception();
        }

        public WebException(string msg)
            : base(msg)
        {
        }
    }

    public class FormException : WebException
    {
        public FormException()
            : base()
        {
        }

        public FormException(string msg)
            : base(msg)
        {
        }
    }
}
