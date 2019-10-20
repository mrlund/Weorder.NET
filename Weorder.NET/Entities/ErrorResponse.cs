using System;
using System.Collections.Generic;
using System.Text;

namespace Weorder.NET.Entities
{
    public class ErrorResponse
    {
        public string message { get; set; }
        public int code { get; set; }
        public bool client { get; set; }

    }

}
