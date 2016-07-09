using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticChat.Models
{
    public class IndexViewModel
    {
        public List<Message> Messages { set; get; }
        public List<Comment> Comments { set; get; }
        public string Text { get; set; }
        public string Sign { get; set; }
    }
}
