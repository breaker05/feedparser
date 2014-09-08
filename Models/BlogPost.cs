using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breaker.Models
{
    public class BlogPost
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }    
}