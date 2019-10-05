using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Models
{
    public class PostModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public ApplicationUserModel ApplicationUser { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
    }
}
