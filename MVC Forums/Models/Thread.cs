using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Forums.Models
{
    public class Thread
    {
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public int ForumId { get; set; }

        public virtual Forum Forum { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}