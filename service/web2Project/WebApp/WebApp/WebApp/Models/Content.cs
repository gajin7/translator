using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Content
    { 
        public string value { get; set; }

        public Content(string v)
        {
            this.value = v;
        }
    }
}