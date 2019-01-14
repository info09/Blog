using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Models
{
    public class ErrorViewModel
    {
        public Abp.Web.Models.ErrorInfo ErrorInfo { get; set; }

        public Exception Exception { get; set; }
    }
}
