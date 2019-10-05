using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public string Text { get; set; }

        public ApplicationUserModel User { get; set; }
        public PostModel Post { get; set; }
    }
}
